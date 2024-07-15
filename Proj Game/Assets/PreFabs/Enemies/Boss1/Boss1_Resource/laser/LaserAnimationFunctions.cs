using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAnimationFunctions : MonoBehaviour
{
    private LaserController lct;
    void Start()
    {
        lct = GetComponentInParent<LaserController>();
    }
    private void ColliderActive()
    {
        lct.ColliderActive();
    }
    private void ColliderPossive()
    {
        lct.ColliderPossive();
    }
    private void DestroyLaser()
    {
        Destroy(transform.parent.gameObject);
    }
}
