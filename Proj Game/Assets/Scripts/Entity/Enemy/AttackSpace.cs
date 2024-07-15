using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpace : MonoBehaviour
{
    private BashEnemyBehaviour beb;
    void Start()
    {
        beb = GetComponentInParent<BashEnemyBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            beb.SetInRange();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            beb.NotInRange();
        }
    }
}
