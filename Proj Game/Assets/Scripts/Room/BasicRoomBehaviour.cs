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
            TryDrop(other.transform.position);

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

    private void TryDrop(Vector3 position)
    {
        if (Random.value <= 0.45f)
        {
            Instantiate(coinPrefab, position, coinPrefab.transform.rotation);
        }
        if(Random.value >= 2)
        {
            int i =Random.Range(0, Buffs.Count);
            Instantiate(Buffs[i], position, Quaternion.identity);
        }
    }


}
