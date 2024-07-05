using UnityEngine;

public class Painter : MonoBehaviour
{
    public Camera cam;
    public Texture2D brushTexture;
    public float brushSize = 1.0f;
    public LayerMask paintableLayer;

    private RenderTexture renderTexture;
    private Material paintMaterial;

    void Start()
    {
        renderTexture = new RenderTexture(1024, 1024, 24);
        paintMaterial = new Material(Shader.Find("Custom/Paintable"));
        GetComponent<Renderer>().material.mainTexture = renderTexture;
    }

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