using UnityEngine;

/// <summary>
/// EN: Allows real-time "painting" on a 3D object using a RenderTexture.
/// Uses a custom shader and UV coordinates to draw with a brush.
/// ES: Permite "pintar" en tiempo real sobre un objeto 3D usando un RenderTexture.
/// Usa un shader personalizado y coordenadas UV para dibujar con un pincel.
/// </summary>
public class Painter : MonoBehaviour
{
    /// <summary>
    /// EN: Camera from which rays are cast to detect paintable surfaces.
    /// ES: Cámara desde la cual se lanzan rayos para detectar superficies pintables.
    /// </summary>
    public Camera cam;
    /// <summary>
    /// EN: Texture used as the brush when painting on the surface.
    /// ES: Textura usada como pincel al pintar sobre la superficie.
    /// </summary>
    public Texture2D brushTexture;
    /// <summary>
    /// EN: Brush size in pixels of the texture.
    /// ES: Tamaño del pincel en píxeles de la textura.
    /// </summary>
    public float brushSize = 1.0f;
    /// <summary>
    /// EN: Layer mask that defines which objects can be painted.
    /// ES: Máscara de capas que define qué objetos pueden ser pintados.
    /// </summary>
    public LayerMask paintableLayer;
    /// <summary>
    /// EN: RenderTexture where the painting result will be drawn.
    /// ES: Textura de renderizado donde se dibujará el resultado de la pintura.
    /// </summary>

    private RenderTexture renderTexture;
    /// <summary>
    /// EN: Material that applies the custom paint shader.
    /// ES: Material que aplica el shader de pintura personalizado.
    /// </summary>
    private Material paintMaterial;
    /// <summary>
    /// EN: Initializes the RenderTexture and paint material, 
    /// and assigns the texture to the object's material.
    /// ES: Inicializa el RenderTexture y el material de pintura,
    /// y asigna la textura al material del objeto.
    /// </summary>
    void Start()
    {
        renderTexture = new RenderTexture(1024, 1024, 24);
        paintMaterial = new Material(Shader.Find("Custom/Paintable"));
        GetComponent<Renderer>().material.mainTexture = renderTexture;
    }
    /// <summary>
    /// EN: Detects left mouse click and casts a ray from the camera to paint on the object
    /// if it collides with a surface inside the paintable layer.
    /// ES: Detecta clic izquierdo y lanza un rayo desde la cámara para pintar en el objeto
    /// si colisiona con una superficie dentro de la capa pintable.
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, paintableLayer))
            {
                Paint(hit.textureCoord);
            }
        }
    }
    /// <summary>
    /// EN: Paints onto the RenderTexture at the given UV position.
    /// ES: Pinta sobre el RenderTexture en la posición UV recibida.
    /// </summary>
    /// <param name="uv">
    /// EN: UV coordinates of the hit point on the surface.
    /// ES: Coordenadas UV del impacto en la superficie.
    /// </param>
    void Paint(Vector2 uv)
    {
        RenderTexture.active = renderTexture;

        GL.PushMatrix();
        GL.LoadPixelMatrix(0, renderTexture.width, renderTexture.height, 0);

        Graphics.DrawTexture(
            new Rect(uv.x * renderTexture.width - brushSize / 2, (1 - uv.y) * renderTexture.height - brushSize / 2, brushSize, brushSize),
            brushTexture);

        GL.PopMatrix();
        RenderTexture.active = null;
    }
}