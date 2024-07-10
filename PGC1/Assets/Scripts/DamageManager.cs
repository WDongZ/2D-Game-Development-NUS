/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public GameObject playergameObject;
    private BuffManager buffManager;
    private Player player;

    void Start()
    {
        player = playergameObject.GetComponent<Player>();
        buffManager = playergameObject.GetComponent<BuffManager>();
    }

    public void TakeDamage(float damage)
    {
        player.hp -= damage;
    }

    public void TakeBurnDamage(float damage, float interval)
    {
        StartCoroutine(BurnDamage(damage, interval));
    }

    IEnumerator BurnDamage(float damage, float interval)
    {
        while (true)
        {
            player.hp -= damage;
            yield return new WaitForSeconds(interval);
        }
    }

    public void TakeBuff(string buffName, float buffNum)
    {
        buffManager.BuffChange(buffName, buffNum);
    }
}*/
