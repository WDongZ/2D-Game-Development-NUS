using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownStatusEffect_B : MonoBehaviour
{
    public float lastingTime;
    private float timmer;
    void Awake()
    {
        timmer = 0;
    }

    void Update()
    {
        timmer += Time.deltaTime;
        if (timmer >= lastingTime)
        {
            transform.parent.GetComponent<EntityAttribute>().moveSpeed =
                transform.parent.GetComponent<EntityAttribute>().moveSpeed * 100f;
            Destroy(gameObject);
        }
    }

}
