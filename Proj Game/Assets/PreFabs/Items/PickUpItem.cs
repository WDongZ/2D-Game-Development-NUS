using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpItem : MonoBehaviour
{
    protected GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    public abstract void PickUp();

    public abstract bool PickCondition();

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            if (PickCondition()) { PickUp(); }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            if (PickCondition()) { PickUp(); }
    }
}
