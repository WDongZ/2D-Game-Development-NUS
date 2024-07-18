using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : Buff
{
    void Awake()
    {
        buffName = "Agent Snail";
        buffDescription = "from the snail, you will move slower but attack faster and be smaller";
    }
    public Snail(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }
    override public void GetBuff(GameObject player)
    {
        Vector3 newSize = player.transform.localScale * 0.7f;
        player.transform.localScale = newSize;
        player.GetComponent<PlayerAttribute>().attackSpeed = player.GetComponent<PlayerAttribute>().attackSpeed * 0.7f;
        player.GetComponent<PlayerAttribute>().moveSpeed = player.GetComponent<PlayerAttribute>().moveSpeed * 0.7f;
    }
}
