using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Wand wand;
    public BulletData bulletData;
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
        GetComponent<SpriteRenderer>().color = new Color(damage * 0.1f, 0, 0);
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

    public void SetBurn(float burndamage, float burninterval)
    {
        bulletData.burndamage = burndamage;
        bulletData.burninterval = burninterval;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if(collision.tag == "Wall")
        {
            //Destroy(gameObject);
            ObjectPool.Instance.PushObject(gameObject);
        }*/
        if(collision.tag == "Enemy")
        {
            //Instantiate(hitEffect, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<EnemyController>().GetHurt(gameObject);
            Destroy(gameObject);
        }
    }
}
