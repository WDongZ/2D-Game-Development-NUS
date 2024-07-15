using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnStatusEffect : MonoBehaviour
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
            transform.parent.GetComponent<EntityAttribute>().hurtFactor = 
                transform.parent.GetComponent<EntityAttribute>().hurtFactor == 2 ? 1 : 
                transform.parent.GetComponent<EntityAttribute>().hurtFactor;
            Destroy(gameObject);
        }
    }

}
