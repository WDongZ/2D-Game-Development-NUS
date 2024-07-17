using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUp : Buff
{
    void Awake()
    {
        buffName = "A bottle of red medicine";
        buffDescription = "Increase the upper limit of blood volume";
    }
    public HpUp(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        player.GetComponent<PlayerAttribute>().HPUpbound += 4;
        player.GetComponent<PlayerAttribute>().HP += 4;
    }
}
