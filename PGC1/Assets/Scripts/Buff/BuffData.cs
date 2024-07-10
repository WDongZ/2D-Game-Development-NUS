using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuff", menuName = "Buff/BuffData")]
public class BuffData : ScriptableObject
{
    public string buffName;
    public string buffDescription;
    public float buffnum;

    public float interval;
}
