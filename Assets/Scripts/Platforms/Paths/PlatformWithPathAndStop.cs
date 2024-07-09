using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformWithPathAndStop : PlatformBase
{
    public Transform[] paths;
    private int currentPath = 1;
    public float[] timeToStop;
    private bool isMoving = false;

    protected override void Start()
    {
        base.Start();
        gameObject.transform.position = paths[0].position;
    }
    public override void BehaviourPlatform()
    {
        if (paths.Length == 0 || timeToStop.Length == 0) return;

        if (!isMoving)
        {
            StartCoroutine(TimeToStopInPaths());
        }
    }
 
    IEnumerator TimeToStopInPaths()
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, paths[currentPath].position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, paths[currentPath].position, speed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(timeToStop[currentPath]);

        currentPath = (currentPath + 1) % paths.Length;

        isMoving = false;
    }
}