using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAltar : MonoBehaviour
{
    public BuffData buffData;
    public GameObject playerGameObject;

    private Player player;

    private BuffManager buffManager;

    public GameObject floatingItems;

    private bool InRange = false;

    void Start()
    {
        player = playerGameObject.GetComponent<Player>();
        buffManager = playerGameObject.GetComponent<BuffManager>();
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
            if(floatingItems.name == "ShotgunStuff")
            {
                player.wands[1].SetActive(true);
                player.wands[0].SetActive(false);
            }
            if(floatingItems.name == "BurnBuff")
            {
                buffManager.BuffAdd(buffData);
            }
            Debug.Log("Floating item destroyed.");
            Destroy(floatingItems);
        }
    }
}
