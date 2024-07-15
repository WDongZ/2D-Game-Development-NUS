using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpDown : Buff
{
    void Awake()
    {
        buffName = "天上地下·唯我独尊";
        buffDescription = "HP上限减少，攻击力增加，攻击速度减少，移动速度增加，体型缩小";
    }

    public HpDown(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        player.GetComponent<PlayerAttribute>().HPUpbound = 2;
        player.GetComponent<PlayerAttribute>().HP = 2;
        player.GetComponent<PlayerAttribute>().damage += 10;
        player.GetComponent<PlayerAttribute>().attackSpeed = player.GetComponent<PlayerAttribute>().attackSpeed* 0.5f;
        player.GetComponent<PlayerAttribute>().moveSpeed = player.GetComponent<PlayerAttribute>().moveSpeed*1.5f;
        Vector3 newSize = player.transform.localScale * 0.8f;
        player.transform.localScale = newSize;
    }
}

