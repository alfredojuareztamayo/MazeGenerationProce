using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public int idDoor = 0;
   
    public bool isOpenDoor = false;
    public UnityEvent OpenDoorEvent = new UnityEvent();
    public UnityEvent closeDoorEvent = new UnityEvent();

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag =="Player")
        {
            AttempOpenDoor();
        }
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AttempOpenDoor();
        }
    }

    public void AttempOpenDoor()
    {
        if (Keyschain.HasKeyPlayer(this) && !isOpenDoor)
        {
            Open();
        }
    }

    public void Open()
    {
        isOpenDoor = true;
        OpenDoorEvent.Invoke();
    }
    public void Close()
    {
        isOpenDoor = false;
        closeDoorEvent.Invoke();

    }

}
