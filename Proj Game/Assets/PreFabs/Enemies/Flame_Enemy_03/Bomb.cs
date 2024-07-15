using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Attacker
{
    protected EntityAttribute entity;
    protected Rigidbody2D rb;
    new protected string tag;
    public float speed;
    public bool isHit = false;

    public bool isBomb = false;

    public bool PInRange = false;
    public Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(PInRange == true)
        {
            Hurt();
        }
    }

    public void SetSpeed(Vector2 direction)
    {
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
        transform.right = direction;
    }

    private void Hurt()
    {
        transform.up = Vector2.zero;
        isHit = true;
        isBomb = true;
        GameObject.Find("Player").GetComponent<PlayerController>().GetHurt(gameObject);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Debug.Log("boooooooooom");
        anim.SetTrigger("isBomb");
    }

    public void SetPInRange()
    {
        PInRange = true; 
    }

    public void NotPInRange()
    {
        PInRange = false;
    }

    public void SetTag(string tag)
    {
        this.tag = tag;
    }

    private void BombDestroy()
    {
        Destroy(gameObject);
    }

}
