using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float hp = 100;
    private bool isHurt = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            isHurt = true;
            GetHurt(collision.gameObject);
        }
    }
    private void GetHurt(GameObject attacker)
    {
        hp -= attacker.GetComponent<BulletData>().damage;
    }
}
