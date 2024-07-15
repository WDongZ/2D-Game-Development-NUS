using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : Buff
{
    void Awake()
    {
        buffName = "火之高兴";
        buffDescription = "持续伤害";
    }
    public Burn(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        Debug.Log("burn");
        player.AddComponent<BurnStatus>();
    }
}
