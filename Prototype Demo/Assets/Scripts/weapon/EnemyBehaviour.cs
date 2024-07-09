using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Bullet(Clone)")
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            health -= bullet.damage;
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
