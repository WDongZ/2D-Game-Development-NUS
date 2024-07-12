using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : Attacker
{
    private Animator anim;
    private bool laserStop = false;
    void Awake()
    {
        damage = 1;
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        anim.SetBool("laserStop", laserStop);
    }
    public void ColliderActive()
    {
        GetComponentInParent<Collider2D>().enabled = true;
    }
    public void ColliderPossive()
    {
        GetComponentInParent<Collider2D>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") collision.GetComponent<PlayerController>().GetHurt(this.gameObject);
    }
    public void StopLaser()
    {
        laserStop = true;
    }
}
