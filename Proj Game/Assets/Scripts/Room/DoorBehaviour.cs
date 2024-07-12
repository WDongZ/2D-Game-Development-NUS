using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public GameObject room;
    private bool isOpen = false;

    public void OpenDoor()
    {
        if(!isOpen)
        {
            isOpen = true;
            GetComponent<Collider2D>().isTrigger = true;
        }
    }

    public void CloseDoor()
    {
        if(isOpen)
        {
            isOpen = false;
            GetComponent<Collider2D>().isTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.parent.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Exit");
            
            if (room.GetComponent<BasicRoomBehaviour>().GetEnemyCount() != 0)
            {
                CloseDoor();
            }
            else
            {
                OpenDoor();
            }
        }
    }



}

