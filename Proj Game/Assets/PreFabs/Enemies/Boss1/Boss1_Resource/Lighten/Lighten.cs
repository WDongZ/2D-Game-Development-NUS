using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighten : Attacker
{
    private bool isLighten;

    private void Update()
    {
        GetComponent<Animator>().SetBool("isLighten", isLighten);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerController>().GetHurt(this.gameObject);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerController>().GetHurt(this.gameObject);
        }

    }

    public void StartLighten()
    {
        isLighten = true;
    }

    public void EndLighten()
    {
        isLighten = false;
    }

    public void TriggerOn()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
    }

    public void TriggerOff()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    public void CurrentStateToZero()
    {
        GetComponentInParent<BossBehavior_01>().CurrentStateToZero();
    }
}
