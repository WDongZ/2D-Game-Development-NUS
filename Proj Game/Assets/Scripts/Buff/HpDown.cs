using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpDown : Buff
{
    void Awake()
    {
        buffName = "Holy Scriptures";
        buffDescription = "increased numerical values, but there have huge side!!";
    }

    public HpDown(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        player.GetComponent<PlayerAttribute>().HPUpbound = 2;
        player.GetComponent<PlayerAttribute>().HP = 2;
        player.GetComponent<PlayerAttribute>().damage += 7;
        player.GetComponent<PlayerAttribute>().attackSpeed = player.GetComponent<PlayerAttribute>().attackSpeed * 0.6f;
        player.GetComponent<PlayerAttribute>().moveSpeed = player.GetComponent<PlayerAttribute>().moveSpeed * 1.4f;
        Vector3 newSize = player.transform.localScale * 0.8f;
        player.transform.localScale = newSize;
    }
}

