using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRoomBehaviour : MonoBehaviour
{
    public List<GameObject> Buffs;
    public GameObject coinPrefab;
    private int enemyCount = 0;

    private bool EnemyIn = false;

    private int playerCount = 0;

    private bool enemyGenereted = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyCount++;
            EnemyIn = true;
            Debug.Log(enemyCount);
        }
        if(other.CompareTag("Player"))
        {
            playerCount = 1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerCount = 1;
            EnemyIn = true;
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

    public bool EnemyGenerated()
    {
        return enemyGenereted;
    }

    public void EnemyGenerateSet()
    {
        enemyGenereted = true;
    }


}
