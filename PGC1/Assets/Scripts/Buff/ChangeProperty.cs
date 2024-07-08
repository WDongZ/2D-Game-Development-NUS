using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "_BuffChange", menuName = "BuffSystem/BuffChange", order = 1)]
public class ChangeProperty : BaseBuffModel
{
    public Property property;
    public override void Apply(BuffInfo buffinfo, DamageInfo damageInfo = null)
    {
        var character = buffinfo.Target.GetComponent<Character>();
        if(character)
        {
            character.property.hp += property.hp;
            character.property.mp += property.mp;
            character.property.atk += property.atk;
            character.property.def += property.def;
            character.property.speed += property.speed;
        }
    }
}
