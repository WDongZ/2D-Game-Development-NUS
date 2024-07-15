using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombspace : MonoBehaviour
{
    private Bomb bomb;

    void Start()
    {
        bomb = GetComponentInParent<Bomb>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bomb.SetPInRange();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bomb.SetPInRange();
        }
    }
}
