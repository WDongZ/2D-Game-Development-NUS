using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class BuyItem : MonoBehaviour
{
    private GameObject playerGameObject;

    private PlayerController player;

    [SerializeField] private bool InRange = false;

    public GameObject FButton;

    public int itemPrice;

    [SerializeField] private TMP_Text priceText;

    void Start()
    {
        playerGameObject = GameObject.Find("Player");
        player = playerGameObject.GetComponent<PlayerController>();
        FButton.SetActive(false);
    }

    void Update()
    {
        priceText.text = itemPrice + " $";
        if (InRange && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Buy Item");
            if (playerGameObject.GetComponent<PlayerAttribute>().goldCoinNum >= itemPrice)
            {
                playerGameObject.GetComponent<PlayerAttribute>().goldCoinNum -= itemPrice;
                PickUp();
            }
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

    public abstract void PickUp();
}
