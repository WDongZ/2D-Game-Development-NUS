using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAltar : MonoBehaviour
{
    public GameObject floatingItems;

    private bool InRange = false;

    void Update()
    {
        if(InRange && Input.GetKeyDown(KeyCode.F))
        {
            PickUp();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = false;
        }
    }

    void PickUp()
    {
        Debug.Log("Picked up Item");
        if(floatingItems != null)
        {
            Destroy(floatingItems);
            Debug.Log("Floating item destroyed.");
        }
    }
}
