using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Attacker
{
    protected EntityAttribute entity;
    protected Rigidbody2D rb;
    new protected string tag;
    public float speed;
    public bool isHit = false;
    public Animator anim;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.SetBool("isHit", isHit);
    }

    public void SetSpeed(Vector2 direction)
    {
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
        transform.right = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (tag == "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.GetComponent<EnemyController>().GetHurt(this.gameObject);
                //collision.GetComponent<>().Status
                isHit = true;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                Debug.Log("Enemy hit!");
            }
        }
        if (tag == "Enemy")
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.GetComponent<PlayerController>().GetHurt(this.gameObject);
                isHit = true;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
        if (collision.gameObject.name == "Tilemap")
        {
            isHit = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

    }


    public void SetTag(string tag)
    {
        this.tag = tag;
    }

    private void BulletDestroy()
    {
        Destroy(gameObject);
    }


}