using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAltar : MonoBehaviour
{
    private GameObject playerGameObject;

    private PlayerController player;

    private BulletControl bulletControl;

    public GameObject floatingItems;

    private bool InRange = false;

    public GameObject FButton;

    void Start()
    {
        playerGameObject = GameObject.Find("Player");
        player = playerGameObject.GetComponent<PlayerController>();
        FButton.SetActive(false);
    }

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
            FButton.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = true;
            FButton.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = false;
            FButton.SetActive(false);
        }
    }

    void PickUp()
    {
        Debug.Log("Picked up Item");
        if(floatingItems != null)
        {
            floatingItems.GetComponent<Buff>().GetBuff(player.gameObject);
            Destroy(floatingItems);
            Destroy(FButton);
        }
    }
}
