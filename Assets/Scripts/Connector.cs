using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class Connector : MonoBehaviour
{
    public Vector2 size = Vector2.one * 4f;
    public bool isConnected;

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
