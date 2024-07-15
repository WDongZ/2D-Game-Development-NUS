using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyItem_Buff : BuyItem
{
    private TMP_Text itemText;

    private void Awake()
    {
        itemText = GameObject.Find("Canvas/ItemText").GetComponent<TMP_Text>();
    }

    public override void PickUp()
    {
        GetComponent<Buff>().GetBuff(GameObject.Find("Player"));
        itemText.enabled = true;
        itemText.text = "You have picked up" + gameObject.name;
        Destroy(gameObject);
    }
}
