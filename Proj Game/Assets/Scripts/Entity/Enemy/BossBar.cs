using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    private GameObject BOSS;
    private float HP;
    void Start()
    {
        BOSS = GameObject.Find("BOSS");
    }

    void Update()
    {
        HP = BOSS.GetComponent<EnemyController>().hp;
        GetComponentInChildren<Slider>().value = HP;
        if (HP <= 0) Destroy(gameObject);
    }
}
