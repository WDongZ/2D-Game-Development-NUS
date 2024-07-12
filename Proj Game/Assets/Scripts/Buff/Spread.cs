using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spread : Buff
{
    public Spread(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        player.GetComponent<BulletControl>().SetBullet(6, 10f);
    }
}
