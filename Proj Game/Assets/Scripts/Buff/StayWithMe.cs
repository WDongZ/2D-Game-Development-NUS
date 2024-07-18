using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayWithMe : Buff
{
    void Awake()
    {
        buffName = "StayWithMe";
        buffDescription = "from StayWithMe, you will attack faster but bigger";
    }
    public StayWithMe(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }
    override public void GetBuff(GameObject player)
    {
        player.GetComponent<PlayerAttribute>().attackSpeed *= 0.5f;
        Vector3 newSize = player.transform.localScale * 2f;
        player.transform.localScale = newSize;
    }
}
