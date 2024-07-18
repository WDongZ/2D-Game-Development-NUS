using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeDown : Buff
{
    void Awake()
    {
        buffName = "Colorful jellyfish";
        buffDescription = "jellyfish makes your body smaller and increases your attack speed";
    }
    public SizeDown(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        Vector3 newSize = player.transform.localScale * 0.5f;
        player.transform.localScale = newSize;
        player.GetComponent<PlayerAttribute>().attackSpeed = player.GetComponent<PlayerAttribute>().attackSpeed * 0.8f;
    }

}
