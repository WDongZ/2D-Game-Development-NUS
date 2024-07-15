using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUp : Buff
{
    void Awake()
    {
        buffName = "洗髓经";
        buffDescription = "生命上限增加";
    }
    public HpUp(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        player.GetComponent<PlayerAttribute>().HPUpbound += 2;
        player.GetComponent<PlayerAttribute>().HP += 2;
    }
}
