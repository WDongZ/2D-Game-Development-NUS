/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Wand wand;

    public float damage;
    public float speed;
    public GameObject hitEffect;
    new private Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        GetComponent<SpriteRenderer>().color = new Color(damage, 0, 0);
    }
    public void SetSpeed(Vector2 direction)
    {
        rigidbody.velocity = direction * speed;
    }

    public void SetDamage(float damage)
    {
        Debug.Log("damage set");
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if(collision.tag == "Wall")
        {
            //Destroy(gameObject);
            ObjectPool.Instance.PushObject(gameObject);
        }*/
        /*if(collision.name == "Enemy")
        {
            //Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletData bulletData;
    protected Rigidbody2D rigidbody;
    public float damage;

    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        damage = bulletData.damage;
    }

    void Update()
    {
        // Apply bullet data
        GetComponent<SpriteRenderer>().color = new Color(damage, 0, 0);
    }

    public virtual void SetSpeed(Vector2 direction)
    {
        rigidbody.velocity = direction * bulletData.speed;
    }

    public virtual void SetDamage(float Outdamage)
    {
        Debug.Log("damage set");
        bulletData.damage = Outdamage;
        damage = bulletData.damage;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Enemy")
        {
            // Instantiate(bulletData.hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
