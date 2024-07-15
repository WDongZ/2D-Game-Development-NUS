using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spread : Buff
{
    void Awake()
    {
        buffName = "漫天花雨";
        buffDescription = "子弹数量增加";
    }
    public Spread(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        player.GetComponent<BulletControl>().SetBullet(6, 10f);
    }
}
