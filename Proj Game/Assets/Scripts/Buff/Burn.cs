using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : Buff
{
    public GameObject fireBall;
    void Awake()
    {
        buffName = "火之高兴";
        buffDescription = "灼烧buff";
    }
    public Burn(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        player.GetComponent<PlayerAttribute>().bullets.Add(fireBall);
        player.GetComponent<PlayerAttribute>().bulletRates.Add(2f);
    }
}
