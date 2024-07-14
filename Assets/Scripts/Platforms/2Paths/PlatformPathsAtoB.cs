using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformPathsAtoB : PlatformBase
{
    private Vector3[] direccionAtoB = new Vector3[2];
    public Transform directionA;
    public Transform directionB;
    private int currentDirection = 0;
    
    protected override void Start()
    {
        base.Start();
        direccionAtoB[0] = directionA.position;
        direccionAtoB[1] = directionB.position;
        gameObject.transform.position =  directionA.position;
    }
    
    public override void BehaviourPlatform()
    {
        // Mueve la plataforma en la dirección especificada a la velocidad dada
        if (direccionAtoB.Length == 0) return;

        transform.position = Vector3.MoveTowards(transform.position, direccionAtoB[currentDirection], speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, direccionAtoB[currentDirection]) < 0.1f)
        {
            currentDirection = (currentDirection + 1) % direccionAtoB.Length;
        }
    }
    
}
