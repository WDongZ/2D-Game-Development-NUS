using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem_Buff : PickUpItem
{
    public override bool PickCondition()
    {
        return player.GetComponent<PlayerAttribute>().HP < player.GetComponent<PlayerAttribute>().HPUpbound;
    }

    public override void PickUp()
    {
        player.GetComponent<PlayerAttribute>().HP += 2;
        Destroy(gameObject);
    }

}
