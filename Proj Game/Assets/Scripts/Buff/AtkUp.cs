using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkUp : Buff
{
    void Awake()
    {
        buffName = "The best small knife in the village";
        buffDescription = "it is extremely sharp and increases player's attack power";
    }
    public AtkUp(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        player.GetComponent<PlayerAttribute>().damage += 3;
    }
}
