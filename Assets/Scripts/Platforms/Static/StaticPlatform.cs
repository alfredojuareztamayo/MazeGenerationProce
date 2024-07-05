using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPlatform : PlatformBase
{
    public override void BehaviourPlatform()
    {
        // La plataforma estática no hace nada en el método BehaviourPlatform
    }
    public override void ChangeMaterialStart()
    {
        GetComponent<MeshRenderer>().material = material;
    }
}
