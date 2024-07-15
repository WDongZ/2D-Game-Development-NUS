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
        GetComponentInChildren<Slider>().maxValue = BOSS.GetComponent<EnemyController>().HP;
        GetComponentInChildren<Slider>().minValue = 0;
        GetComponentInChildren<Slider>().value = BOSS.GetComponent<EnemyController>().HP;
    }

    void Update()
    {
        HP = BOSS.GetComponent<EnemyController>().HP;
        GetComponentInChildren<Slider>().value = HP;
        if (HP <= 0) Destroy(gameObject);
    }
}
