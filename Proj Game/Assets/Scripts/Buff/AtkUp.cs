using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkUp : Buff
{
    void Awake()
    {
        buffName = "The best small knife in the village";
        buffDescription = "Crafted by the best blacksmith in the village, it is extremely sharp and increases player's attack power";
    }
    public AtkUp(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        player.GetComponent<PlayerAttribute>().damage += 2 ;
        //player.GetComponent<BulletControl>().bulletColor = new Color(1, 0.65f, 0);
    }
}
