using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttzckGolem : MonoBehaviour
{
    private EnemyGolemBehaviour egb;
    void Start()
    {
        egb = GetComponentInParent<EnemyGolemBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            egb.SetInRange();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            egb.NotInRange();
        }
    }
}
