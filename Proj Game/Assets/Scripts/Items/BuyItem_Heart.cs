
using TMPro;
using UnityEngine;

public class BuyItem_Heart : BuyItem
{

    public override void PickUp()
    {
        GameObject.Find("Player").GetComponent<PlayerAttribute>().HP += 4;
        Destroy(gameObject);
    }
}
