using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spread : Buff
{
    void Awake()
    {
        buffName = "ShotGun";
        buffDescription = "The power of the shotgun, the bullet spreads out";
    }
    public Spread(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        player.GetComponent<BulletControl>().SetBullet(3, 10f);
    }
}
