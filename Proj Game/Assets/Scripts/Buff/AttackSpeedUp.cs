using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedUp : Buff
{
    void Start()
    {
        buffName = "含沙射影";
        buffDescription = "攻击速度提升20%";
    }
    public AttackSpeedUp(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        player.GetComponent<PlayerAttribute>().attackSpeed = player.GetComponent<PlayerAttribute>().attackSpeed * 0.6f;
        player.GetComponent<PlayerAttribute>().damage = player.GetComponent<PlayerAttribute>().damage * 0.5f;
    }
}
