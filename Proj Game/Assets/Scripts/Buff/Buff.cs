using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : MonoBehaviour
{
    protected GameObject player;
    public string buffName;
    public string buffDescription;
    public abstract void GetBuff(GameObject player);
    public Buff(string buffName, string buffDescription, GameObject player)
    {
        this.buffName = buffName;
        this.buffDescription = buffDescription;
        this.player = player;
    }
}
