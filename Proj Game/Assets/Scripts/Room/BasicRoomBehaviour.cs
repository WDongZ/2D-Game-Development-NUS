using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRoomBehaviour : MonoBehaviour
{
    private int enemyCount = 0;

    private int playerCount = 0;

    private void Update()
    {
        Debug.Log(playerCount);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyCount++;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerCount = 1;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyCount--;
        }
        if (other.CompareTag("Player"))
        {
            playerCount = 0;
        }
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }

    public int GetPlayerCount()
    {
        return playerCount;
    }


}
