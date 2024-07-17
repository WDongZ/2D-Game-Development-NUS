using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ult : Attacker
{
    [SerializeField] private bool isWave;

    private float ultRate = 5f;
    private void Update()
    {
        SetDamage(GetComponentInParent<PlayerAttribute>().damage * ultRate);
        GetComponent<Animator>().SetBool("isWave", isWave);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        collision.GetComponent<EnemyController>().GetHurt(gameObject);
    }

    public void SetUltRate(float rate)
    {
        ultRate = rate;
    }

    public void StartWave()
    {
        Debug.Log("StartWave");
        isWave = true;
    }

    public void EndWave()
    {
        isWave = false;
    }

    public void TriggerOn()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
    }

    public void TriggerOff()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
    }
}
