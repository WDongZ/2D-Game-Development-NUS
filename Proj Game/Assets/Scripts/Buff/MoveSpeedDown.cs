using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedDown : Buff
{
    void Awake()
    {
        buffName = "The wings of the little devil";
        buffDescription = "exchanging attack power with movement speed?";
    }
    public MoveSpeedDown(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        player.GetComponent<PlayerAttribute>().moveSpeed = player.GetComponent<PlayerAttribute>().moveSpeed * 0.5f;
        player.GetComponent<PlayerAttribute>().attackSpeed = player.GetComponent<PlayerAttribute>().attackSpeed * 0.4f;
    }

}
