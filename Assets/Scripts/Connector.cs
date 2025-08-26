using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

/// <summary>
/// EN: Represents a connector component in the scene that can be visually displayed using Gizmos.  
/// Allows defining a rectangular area and drawing lines from the center to the corners, helping visualize connections in the editor.  
/// ES: Representa un componente conector en la escena que se muestra visualmente usando Gizmos.  
/// Permite definir un área rectangular y dibujar líneas desde el centro a las esquinas, ayudando a visualizar conexiones en el editor.  
/// </summary>
public class Connector : MonoBehaviour
{
    /// <summary>
    /// EN: Size of the connector's area (width and height).  
    /// ES: Tamaño del área del conector (ancho y alto).  
    /// </summary>
    public Vector2 size = Vector2.one * 4f;
    /// <summary>
    /// EN: Indicates whether the connector is currently connected.  
    /// ES: Indica si el conector está actualmente conectado.  
    /// </summary>
    public bool isConnected;
    /// <summary>
    /// EN: Draws the connector's Gizmos in the editor, including the rectangle and lines from the center to corners.  
    /// ES: Dibuja los Gizmos del conector en el editor, incluyendo el rectángulo y líneas desde el centro hacia las esquinas.  
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Vector2 halfSize = size * 0.5f;
        Vector3 offset = transform.position + transform.up * halfSize.y;
        Gizmos.DrawLine(offset, offset + transform.forward);
        //difene
        Vector3 top = transform.up * size.y;
        Vector3 side = transform.right * halfSize.x;
        //define corner vector
        Vector3 topRight = transform.position + top + side;
        Vector3 topLeft = transform.position + top - side;
        Vector3 bottomRight = transform.position  + side;
        Vector3 bottomLeft = transform.position  - side;
        Gizmos.DrawLine(topRight,topLeft);
        Gizmos.DrawLine(topLeft,bottomLeft);
        Gizmos.DrawLine(bottomLeft,bottomRight);
        Gizmos.DrawLine(bottomRight,topRight);

        //draw diagonal lines
        Gizmos.color *= 0.8f;
        Gizmos.DrawLine(topRight,offset);
        Gizmos.DrawLine(topLeft,offset);
        Gizmos.DrawLine(bottomRight,offset);
        Gizmos.DrawLine(bottomLeft,offset);
    }
}
