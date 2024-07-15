using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkUp : Buff
{
    void Awake()
    {
        buffName = "九阳神功";
        buffDescription = "攻击力增加";
    }
    public AtkUp(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        Debug.Log("atk++");
        player.GetComponent<PlayerAttribute>().damage += 2 ;
        player.GetComponent<BulletControl>().bulletColor = new Color(1, 0.65f, 0);
    }
}
