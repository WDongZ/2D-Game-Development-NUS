using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AP_Anim : MonoBehaviour
{
    private EnemyController ec;
    void Start()
    {
        ec = GetComponentInParent<EnemyController>();
    }

    public void EndHurt()
    {
        ec.EndHurt();
    }

    public void DestroyAP()
    {
        Destroy(transform.parent.gameObject);
    }

}
