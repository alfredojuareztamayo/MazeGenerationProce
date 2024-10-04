using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int keyId;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Keyschain.AddKeyPlayer(keyId);
        }
        Destroy(this.gameObject);
    }
}
