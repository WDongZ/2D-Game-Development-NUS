using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : Buff
{
    void Awake()
    {
        buffName = "Delivery";
        buffDescription = "from the delivery man, you can move faster and attack faster";
    }
    public Delivery(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }
    override public void GetBuff(GameObject player)
    {
        player.GetComponent<PlayerAttribute>().attackSpeed *= 0.8f;
        player.GetComponent<PlayerAttribute>().moveSpeed *= 1.5f;
    }
}
