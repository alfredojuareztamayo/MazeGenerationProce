using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

/// <summary>
/// EN: Handles procedural generation of a dungeon with start tiles, branching paths, doors, and optional debugging visuals.  
/// Supports dynamic creation of tiles, connection via connectors, collision checking, and light debugging.  
/// ES: Gestiona la generación procedural de un dungeon con tiles iniciales, caminos ramificados, puertas y opciones de depuración visual.  
/// Soporta creación dinámica de tiles, conexión mediante conectores, chequeo de colisiones y depuración de luces.  
/// </summary>
public class DungeonGenerator : MonoBehaviour
{
    /// <summary>EN: Prefabs for the starting rooms. ES: Prefabs para las habitaciones iniciales.</summary>
    public GameObject[] startPrefabs;

    /// <summary>EN: Prefabs for the main dungeon tiles. ES: Prefabs para los tiles principales del dungeon.</summary>
    public GameObject[] TilesPrefabs;

    /// <summary>EN: Prefabs for exit tiles. ES: Prefabs para los tiles de salida.</summary>
    public GameObject[] exitPrefabs;

    /// <summary>EN: Prefabs for blocked tiles. ES: Prefabs para tiles bloqueados.</summary>
    public GameObject[] blockedPrefabs;

    /// <summary>EN: Prefabs for doors. ES: Prefabs para puertas.</summary>
    public GameObject[] doorPrefabs;



    [Header("Debugging Options")]
    /// <summary>EN: Enable/disable BoxColliders for debugging. ES: Activar/desactivar BoxColliders para depuración.</summary>
    public bool useBoxColliders;

    /// <summary>EN: Enable/disable lighting for debugging. ES: Activar/desactivar iluminación para depuración.</summary>
    public bool useLightingForDebugging;

    /// <summary>EN: Restore original lighting after debugging. ES: Restaurar iluminación original después de la depuración.</summary>
    public bool restoreLightsAfterDebugging;

    [Header("Key Blindings")]
    /// <summary>EN: Key to reload the scene. ES: Tecla para recargar la escena.</summary>
    public KeyCode reloadScene = KeyCode.Backspace;

    /// <summary>EN: Key to toggle the map camera. ES: Tecla para alternar la cámara del mapa.</summary>
    public KeyCode mapToggle = KeyCode.M;

    [Header("Generation limits")]
    /// <summary>EN: Delay between tile construction. ES: Retardo entre la construcción de tiles.</summary>
    [Range(0, 1)] public float constructionDelay;

    /// <summary>EN: Length of the main path. ES: Longitud del camino principal.</summary>
    [Range(2, 100)] public int mainLength = 10;

    /// <summary>EN: Length of branches. ES: Longitud de los caminos ramificados.</summary>
    [Range(0, 50)] public int branchLength = 5;

    /// <summary>EN: Number of branches to generate. ES: Número de caminos ramificados a generar.</summary>
    [Range(0, 25)] public int numBranch = 10;

    /// <summary>EN: Probability of doors appearing. ES: Probabilidad de aparición de puertas.</summary>
    [Range(0, 100)] public int doorPorcent = 25;

    [Header("Avalible until Running")]
    /// <summary>EN: List of generated tiles for reference. ES: Lista de tiles generados para referencia.</summary>
    public List<Tile> generatedTiles = new List<Tile>();

    GameObject goCamera, goPlayer;
    Color startLightingColor = Color.white;
    List<Connector> avalibleConnectors = new List<Connector>();
    Transform tileFrom, tileTo, tileRoot;
    Transform conteiner;
    int attemps;
    int maxAttemps = 50;

    /// <summary>EN: Initialize dungeon generation, find camera and player. ES: Inicializa la generación del dungeon, encuentra la cámara y el jugador.</summary>

    void Start()
    {
        goCamera = GameObject.Find("OverHeadCamera");
        goPlayer = GameObject.FindWithTag("Player");
        
        StartCoroutine(DungeonBuild());
    }
    /// <summary>EN: Handles input for scene reload and camera toggle. ES: Maneja la entrada para recargar la escena y alternar la cámara.</summary>

    private void Update()
    {
        if (Input.GetKeyDown(reloadScene)) 
        {
            SceneManager.LoadScene("GameDungeon");
        }
        if (Input.GetKeyDown(mapToggle))
        {
            goCamera.SetActive(!goCamera.activeInHierarchy);
            goPlayer.SetActive(!goPlayer.activeInHierarchy);
        }
    }

    /// <summary>
    /// EN: Coroutine that procedurally generates the dungeon with main path and branches, applies lighting for debugging, and handles collision checks.
    /// ES: Corrutina que genera proceduralmente el dungeon con camino principal y ramificaciones, aplica iluminación para depuración y maneja colisiones.
    /// </summary>
    /// <returns>EN: IEnumerator for coroutine. ES: IEnumerator para la corrutina.</returns>

    IEnumerator DungeonBuild()
    {
        goCamera.SetActive(true);
        goPlayer.SetActive(false);
        GameObject goConteiner = new GameObject("Main Path");
        conteiner = goConteiner.transform;
        conteiner.SetParent(transform);
        tileRoot = CreateStartTile();
        DebuggingLighting(tileRoot, Color.cyan);
        tileTo = tileRoot;
        for (int i = 0; i < mainLength -1; i++)
        {
            yield return new WaitForSeconds(constructionDelay);
            tileFrom = tileTo;
            tileTo = CreateTile();
            DebuggingLighting(tileTo, Color.yellow);
            ConnectTiles();
            CollisionCheck();
            if (attemps >= maxAttemps) { break; }
        }
        //Get all connectors within container that no already connected
        foreach(Connector connector in conteiner.GetComponentsInChildren<Connector>())
        {
            if (!connector.isConnected)
            {
                if (!avalibleConnectors.Contains(connector))
                {
                    avalibleConnectors.Add(connector);
                }
            }
        }
        //Branching
       for(int b= 0; b< numBranch; b++)
        {
            if (avalibleConnectors.Count > 0)
            {
                goConteiner = new GameObject("Branch " + (b + 1));
                conteiner = goConteiner.transform;
                conteiner.SetParent(transform);
                int availIndex = Random.Range(0, avalibleConnectors.Count);
                tileRoot = avalibleConnectors[availIndex].transform.parent.parent;
                avalibleConnectors.RemoveAt(availIndex);
                tileTo = tileRoot;
                for (int i = 0; i < branchLength - 1; i++)
                {
                    yield return new WaitForSeconds(constructionDelay);
                    tileFrom = tileTo;
                    tileTo = CreateTile();
                    DebuggingLighting(tileTo, Color.green);
                    ConnectTiles();
                    CollisionCheck();
                    if (attemps >= maxAttemps) { break; }
                }
            }
            else
            {
                break;
            }
        }
        LightRestoration();
        CleanBoxes();
        goCamera.SetActive(false);
        goPlayer.SetActive(true);
    }

    void CollisionCheck()
    {
        BoxCollider box = tileTo.GetComponent<BoxCollider>();
        if (box == null)
        {
            box = tileTo.gameObject.AddComponent<BoxCollider>();
            box.isTrigger = true;
        }
        Vector3 offset = (tileTo.right * box.center.x) + (tileTo.up * box.center.y) + (tileTo.forward * box.center.z);
        Vector3 halfExtents = box.bounds.extents;
        List<Collider> hits = Physics.OverlapBox(tileTo.position+offset,halfExtents,Quaternion.identity,LayerMask.GetMask("Tile")).ToList();
        if (hits.Count > 0)
        {
            if (hits.Exists(x => x.transform != tileFrom && x.transform != tileTo))
            { //hit Something
                attemps++;
                int toIndex = generatedTiles.FindIndex(x => x.tile == tileTo);
                if (generatedTiles[toIndex].connector != null)
                {
                    generatedTiles[toIndex].connector.isConnected = false;
                }
                generatedTiles.RemoveAt(toIndex);
                DestroyImmediate(tileTo.gameObject);
                //backtracking

                if(attemps >= maxAttemps)
                {
                    int fromIndex = generatedTiles.FindIndex(x => x.tile == tileFrom);
                    Tile myTileFrom = generatedTiles[fromIndex];
                    if (tileFrom != tileRoot)
                    {
                        if(myTileFrom.connector != null)
                        {
                            myTileFrom.connector.isConnected = false;
                        }
                        avalibleConnectors.RemoveAll(x => x.transform.parent.parent == tileFrom);
                        generatedTiles.RemoveAt(fromIndex);
                        DestroyImmediate(tileFrom.gameObject);
                        if (myTileFrom.origin != tileRoot)
                        {
                            tileFrom = myTileFrom.origin;
                        }
                        else if (conteiner.name.Contains("Main"))
                        {
                            if(myTileFrom.origin != null)
                            {
                                tileRoot = myTileFrom.origin;
                                tileFrom = tileRoot;
                            }
                        }
                        else if (avalibleConnectors.Count > 0)
                        {
                            int availIndex = Random.Range(0, avalibleConnectors.Count);
                            tileRoot = avalibleConnectors[availIndex].transform.parent.parent;
                            avalibleConnectors.RemoveAt(availIndex);
                            tileFrom = tileRoot;
                        }
                        else { return; }
                    }
                    else if (conteiner.name.Contains("Main"))
                    {
                        if(myTileFrom.origin != null)
                        {
                            tileRoot = myTileFrom.origin;
                            tileFrom = tileRoot;
                        }
                    }
                    else if (avalibleConnectors.Count > 0)
                    {
                        int availIndex = Random.Range(0, avalibleConnectors.Count);
                        tileRoot = avalibleConnectors[availIndex].transform.parent.parent;
                        avalibleConnectors.RemoveAt(availIndex);
                        tileFrom = tileRoot;
                    }
                    else { return; }
                }
                //re again
                if (tileFrom != null)
                {
                    tileTo = CreateTile();
                    Color retryColor = conteiner.name.Contains("Branch") ? Color.green : Color.yellow;
                    DebuggingLighting(tileTo, retryColor * 2f);
                    ConnectTiles();
                    CollisionCheck();
                }

            }
            else
            { attemps = 0; }

        }
        
    }
    void LightRestoration()
    {
        if(useLightingForDebugging && restoreLightsAfterDebugging && Application.isEditor)
        {
            Light[] lights = transform.GetComponentsInChildren<Light>();
            foreach (Light light in lights)
            {
                light.color = startLightingColor;
            }
        }
    }

    void DebuggingLighting(Transform tile, Color lightColor)
    {
        if(useLightingForDebugging && Application.isEditor)
        {
            Light[] lights = tile.GetComponentsInChildren<Light>();
            if (lights.Length > 0)
            {
                if (startLightingColor == Color.white)
                {
                    startLightingColor = lights[0].color;
                }
                foreach (Light light in lights)
                {
                    light.color = lightColor;
                }
            }
        }
    }

    void CleanBoxes()
    {
        if (!useBoxColliders)
        {
            foreach (Tile mytile in generatedTiles)
            {
                BoxCollider box = mytile.tile.GetComponent<BoxCollider>();
                if (box != null) { Destroy(box); }
            }
        }
    }

    void ConnectTiles()
    {
        Transform connectFrom = GetRandomConector(tileFrom);
        if (connectFrom == null ) {return; }
        Transform connectTo = GetRandomConector(tileTo);
        if (connectTo == null) { return; }
        connectTo.SetParent(connectFrom);
        tileTo.SetParent(connectTo);
        connectTo.localPosition = Vector3.zero;
        connectTo.localRotation = Quaternion.identity;
        connectTo.Rotate(0, 180f, 0);
        tileTo.SetParent(conteiner);
        connectTo.SetParent(tileTo.Find("Connectors"));
        generatedTiles.Last().connector = connectFrom.GetComponent<Connector>();
    }

   Transform GetRandomConector(Transform tile)
    {
        if( tile == null ) {return null;}
        List<Connector> connectorList = tile.GetComponentsInChildren<Connector>().ToList().FindAll(x=>x.isConnected == false);
        if (connectorList.Count > 0)
        {
            int connectorIndex = Random.Range(0, connectorList.Count);
            connectorList[connectorIndex].isConnected = true;
            if(tile==tileFrom)
            {
                BoxCollider box = tile.GetComponent<BoxCollider>();
                if (box == null)
                {
                    box = tile.gameObject.AddComponent<BoxCollider>();
                    box.isTrigger = true;
                }
            }
            return connectorList[connectorIndex].transform;
        }
        return null;
    }
    Transform CreateTile()
    {
        int index = Random.Range(0, TilesPrefabs.Length);
        GameObject goTile = Instantiate(TilesPrefabs[index], Vector3.zero, Quaternion.identity, conteiner) as GameObject;
        goTile.name = TilesPrefabs[index].name;
        Transform origin = generatedTiles[generatedTiles.FindIndex(x=>x.tile == tileFrom)].tile;
        generatedTiles.Add(new Tile(goTile.transform, origin));
        return goTile.transform;
    }
    Transform CreateStartTile()
    {
        int index = Random.Range(0, startPrefabs.Length);
        GameObject goTile = Instantiate(startPrefabs[index], Vector3.zero, Quaternion.identity, conteiner) as GameObject;
        goTile.name = "Start Room";
        float yRot = Random.Range(0, 4) * 90f;
        goTile.transform.Rotate(0, yRot, 0);
        goPlayer.transform.LookAt(goTile.GetComponentInChildren<Connector>().transform);
        generatedTiles.Add(new Tile(goTile.transform, null));
        return goTile.transform;
    }
}
