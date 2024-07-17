using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Buff : MonoBehaviour
{
    public TMP_Text intro;
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
    private void Update()
    {
        intro.text = buffName + "\n" + buffDescription;
    }
}
