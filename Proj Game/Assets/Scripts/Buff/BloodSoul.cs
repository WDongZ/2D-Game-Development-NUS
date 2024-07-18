using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSoul : Buff
{
    void Awake()
    {
        buffName = "BloodSoul";
        buffDescription = "from the blood soul, you can move faster and have more HP";
    }
    public BloodSoul(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }
    override public void GetBuff(GameObject player)
    {
        player.GetComponent<PlayerAttribute>().moveSpeed = player.GetComponent<PlayerAttribute>().moveSpeed * 1.5f;
        player.GetComponent<PlayerAttribute>().HPUpbound += 2;
        player.GetComponent<PlayerAttribute>().HP += 2;
    }
}
