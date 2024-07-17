using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private GameObject room;
    private float timer = 0;
    private bool isOpen = true;

    private void Awake()
    {
        room = transform.parent.gameObject;
    }

    public void OpenDoor()
    {
        if (!isOpen)
        {
            isOpen = true;
            GetComponent<Collider2D>().isTrigger = true;
        }
    }

    public void CloseDoor()
    {
        if (isOpen)
        {
            isOpen = false;
            GetComponent<Collider2D>().isTrigger = false;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(room.GetComponent<BasicRoomBehaviour>().GetPlayerCount() == 1 && room.GetComponent<BasicRoomBehaviour>().GetEnemyCount() != 0)
        {
            CloseDoor();
            timer = 0;
        }
        else
        {
            if (timer > .1f) { OpenDoor(); }
        }

        GetComponent<Animator>().SetBool("isOpen", isOpen);
    }
    
}


