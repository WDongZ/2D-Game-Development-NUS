using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedUp : Buff
{
    void Start()
    {
        buffName = "The skull of a bird";
        buffDescription = "Eating birds increases attack speed";
    }
    public AttackSpeedUp(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        player.GetComponent<PlayerAttribute>().attackSpeed = player.GetComponent<PlayerAttribute>().attackSpeed * 0.6f;
    }
}
