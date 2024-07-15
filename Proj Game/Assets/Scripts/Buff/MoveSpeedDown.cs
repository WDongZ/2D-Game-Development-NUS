using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedDown : Buff
{
    void Awake()
    {
        buffName = "万里狂沙";
        buffDescription = "移动速度减少,攻击速度增加";
    }
    public MoveSpeedDown(string buffName, string buffDescription, GameObject player) : base(buffName, buffDescription, player)
    {
    }

    override public void GetBuff(GameObject player)
    {
        player.GetComponent<PlayerAttribute>().moveSpeed = player.GetComponent<PlayerAttribute>().moveSpeed - 1.5f;
        player.GetComponent<PlayerAttribute>().attackSpeed = player.GetComponent<PlayerAttribute>().attackSpeed - 0.3f;
    }

}
