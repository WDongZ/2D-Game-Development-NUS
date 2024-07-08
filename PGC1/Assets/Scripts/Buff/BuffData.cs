using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_BuffData", menuName = "BuffSystem/BuffData", order = 1)]
public class BuffData : ScriptableObject
{
    public int id;
    public string buffName;
    public string buffDescription;
    public int priority;

    public Sprite buffIcon;

    public int maxStack;
    public string[] tags;

    public bool isForever;

    public float duration;
    public float tickRate;

    public BuffUpdateTimeEnum buffUpdateTime;

    public BuffRemoveUpdateEnum buffRemoveUpdate;
    //基础
    public BaseBuffModel OnCreate;
    public BaseBuffModel OnRemove;
    public BaseBuffModel OnTick;
    //伤害
    public BaseBuffModel OnDamage;
    public BaseBuffModel OnTakeDamage;
    //可以续写


}
