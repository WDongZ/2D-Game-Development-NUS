using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Buff
{
    void Awake()
    {
        buffName = "Bolt's running shoes";
        buffDescription = "Wind like sensation, increased movement speed";
    }
    public SpeedUp(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        player.GetComponent<PlayerAttribute>().moveSpeed = player.GetComponent<PlayerAttribute>().moveSpeed * 2f;
    }
}
