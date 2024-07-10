using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{

    public Player GameObject;

    public void BuffChange(string buffName, int buffNum)
    {
        switch (buffName)
        {
            case "伤害增加":
                GameObject.buffinterval += buffNum;
                GameObject.buffdamage += buffNum;
                break;
            default:
                Debug.Log("Unknown buff type");
                break;
        }
    }

    public void BuffAdd(BuffData buffData)
    {
        GameObject.buffinterval += buffData.interval;
        GameObject.buffdamage += buffData.buffnum;
    }
    
}
