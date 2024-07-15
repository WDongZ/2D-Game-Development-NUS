using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoinCollision : MonoBehaviour
{
    private PlayerAttribute player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerAttribute>();

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);

        if (collision.gameObject.tag == "Player")
        {
            player.goldCoinNum++;
            Destroy(gameObject);
        }
    }

}
