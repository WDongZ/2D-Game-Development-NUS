using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : EntityAttribute
{
    public float HPUpbound;
    public float TMP_HP;
    public float attackSpeed;
    public float attackDistence;
    public List<Buff> buffs = new List<Buff>();
    public GameObject bullet;

    public void GainBuff(Buff buff)
    {
        buffs.Add(buff);
        buff.GetBuff(gameObject);
    }
}

class TMP_HP
{
    public float THP = 0;
    public Stack<Element> elementStack = new Stack<Element>();

    public void GetTHP(Element e)
    {
        THP++;
        elementStack.Push(e);
    }

}



enum Element { fire, water, grass}
