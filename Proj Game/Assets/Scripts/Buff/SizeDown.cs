using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeDown : Buff
{
    void Awake()
    {
        buffName = "易筋经";
        buffDescription = "体型缩小";
    }
    public SizeDown(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        Vector3 newSize = player.transform.localScale * 0.5f;
        player.transform.localScale = newSize;
    }

}
