using System;
using System.Collections;
using UnityEngine;
public enum BuffUpdateTimeEnum
{
    Add,
    Replace,
    Keep
}

public enum BuffRemoveUpdateEnum
{
    Clear,
    Reduce
}

public class BuffInfo
{
    public BuffData buffData;
    public GameObject Creator;

    public GameObject Target;
    public float duration;
    public float tickRate;

    public int curStack = 1;

}

public class DamageInfo
{
    public GameObject Creator;
    public GameObject Target;
    public float damage;
}
[System.Serializable]
public class Property
{
    public float hp;
    public float mp;
    public float atk;
    public float def;
    public float speed;
}