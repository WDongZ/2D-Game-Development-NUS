using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FellItem : BuyItem
{
    private void Awake()
    {
        
    }

    public override void PickUp()
    {
        GetComponent<Buff>().GetBuff(GameObject.Find("Player"));
        Destroy(gameObject);
    }
}
