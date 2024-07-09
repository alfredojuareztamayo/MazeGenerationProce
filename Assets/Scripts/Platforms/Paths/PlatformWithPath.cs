using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformWithPath : PlatformBase
{
    public Transform[] paths;
    private int currentPath = 1;

    protected override void Start()
    {
        base.Start();
        gameObject.transform.position = paths[0].position;
    }
    public override void BehaviourPlatform()
    {
        if (paths.Length == 0) return;

        transform.position = Vector3.MoveTowards(transform.position, paths[currentPath].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, paths[currentPath].position) < 0.1f)
        {
            currentPath = (currentPath + 1) % paths.Length;
        }
    }
   
}
