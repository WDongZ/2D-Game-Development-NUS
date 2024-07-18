using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Merchant : MonoBehaviour
{

    private bool InRange = false;

    public GameObject FButton;

    private int currentCost = 0;

    private int playerMouny;

    public TMP_Text costText;

    void Start()
    {
        FButton.SetActive(false);
    }

    void Update()
    {
        costText.text = currentCost <= 3 ? (currentCost + " $") : ("Sellout");
        playerMouny = GameObject.Find("Player").GetComponent<PlayerAttribute>().goldCoinNum;
        if (InRange && Input.GetKeyDown(KeyCode.F) && playerMouny >= currentCost && currentCost <= 3)
        {
            GameObject.Find("Player").GetComponent<PlayerAttribute>().goldCoinNum -= currentCost;
            currentCost++;
            Reroll();
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

    private void Reroll()
    {
        GetComponentInParent<RandomItemSpawner>().ReRollItem();
    }
}
