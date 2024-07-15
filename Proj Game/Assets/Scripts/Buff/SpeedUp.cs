using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Buff
{
    void Awake()
    {
        buffName = "凌波微步";
        buffDescription = "移动速度提升1.5";
    }
    public SpeedUp(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        player.GetComponent<PlayerAttribute>().moveSpeed = player.GetComponent<PlayerAttribute>().moveSpeed + 1.5f;
    }
}
