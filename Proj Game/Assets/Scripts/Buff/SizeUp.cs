using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeUp : Buff
{
    void Awake()
    {
        buffName = "Mushrooms for plumbers";
        buffDescription = "Red and blue overalls experience card, increased body size";
    }
    public SizeUp(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        Vector3 newSize = player.transform.localScale * 1.5f;
        player.transform.localScale = newSize;
        player.GetComponent<PlayerAttribute>().damage += 4 ;

    }

}
