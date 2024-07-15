using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeUp : Buff
{
    void Awake()
    {
        buffName = "大力金刚";
        buffDescription = "体型增大";
    }
    public SizeUp(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        Vector3 newSize = player.transform.localScale * 1.5f;
        player.transform.localScale = newSize;
        player.GetComponent<PlayerAttribute>().damage += 5 ;
        player.GetComponent<PlayerAttribute>().attackSpeed = player.GetComponent<PlayerAttribute>().attackSpeed + 0.2f;

    }

}
