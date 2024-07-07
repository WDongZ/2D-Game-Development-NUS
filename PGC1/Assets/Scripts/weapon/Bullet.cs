using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Wand wand;
    public float speed;
    public GameObject hitEffect;

    public float hdamage;

    new private Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        hdamage = wand.damage;
    }
    public void SetSpeed(Vector2 direction)
    {
        rigidbody.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if(collision.tag == "Wall")
        {
            //Destroy(gameObject);
            ObjectPool.Instance.PushObject(gameObject);
        }*/
        if(collision.name == "Enemy")
        {
            //Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            ObjectPool.Instance.PushObject(gameObject);
        }
    }
}
