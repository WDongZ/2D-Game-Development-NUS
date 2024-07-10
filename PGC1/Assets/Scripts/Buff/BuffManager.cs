using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public int buffAmount;

    public Player GameObject;

    public void BuffChange(int buffAmount)
    {
        switch (buffAmount)
        {
            case 0:
                GameObject.hp += 100;
                break;
            case 1:
                GameObject.atk += 100;
                break;
            case 2:
                GameObject.def += 100;
                break;
            default:
                Debug.Log("Unknown buff type");
                break;
        }
    }
}
