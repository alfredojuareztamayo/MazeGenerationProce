using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPathAtoBTime : PlatformBase
{
    private Vector3[] direccionAtoB = new Vector3[2];
    public Transform directionA;
    public Transform directionB;
    private int currentDirection = 0;
    private float[] timeToStop = new float[2];
    public float timeA;
    public float timeB;
    private bool isMoving = false;
    protected override void Start()
    {
        base.Start();
        direccionAtoB[0] = directionA.position;
        direccionAtoB[1] = directionB.position;
        gameObject.transform.position = directionA.position;
        timeToStop[0] = timeA;
        timeToStop[1] = timeB;
    }

    public override void BehaviourPlatform()
    {
 
        if (direccionAtoB.Length == 0) return;
        if (!isMoving)
        {
            StartCoroutine(TimeStop());
        }
       

    }
    public override void ChangeMaterialStart()
    {
        if (material != null)
        {

            GetComponent<MeshRenderer>().material = material;
        }
    }

    IEnumerator TimeStop()
    {
        isMoving = true;
        while(Vector3.Distance(transform.position, direccionAtoB[currentDirection]) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, direccionAtoB[currentDirection], speed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(timeToStop[currentDirection]);
        currentDirection = (currentDirection + 1) % direccionAtoB.Length;
        isMoving = false;
    }
}