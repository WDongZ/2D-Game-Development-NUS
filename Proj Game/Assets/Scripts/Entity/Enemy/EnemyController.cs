using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : EntityAttribute
{
    protected bool isHurt = false;
    [SerializeField] protected Animator anim;
    protected bool isDead;
    protected bool isAttack;
    protected bool isMove;
    void Awake()
    {
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            anim = GetComponentInChildren<Animator>();
        }
    }

    void Update()
    {
        if(HP <= 0)
        {
            isDead = true;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<SpriteRenderer>().enabled = true;

        }
        anim.SetBool("isHurt", isHurt);
        anim.SetBool("isDead", isDead);
        anim.SetBool("isAttack", isAttack);
        anim.SetBool("isMove", isMove);
    }

    public void GetHurt(GameObject attacker)
    {
        if (hurtFactor > 0)
        {
            anim.Play("Enemy_Idel");
            isHurt = true;
            HP -= attacker.GetComponent<Attacker>().damage * hurtFactor;
        }
    }

    public void EndHurt()
    {
        isHurt = false;
    }

    public void StartAttack()
    {
        isAttack = true;
    }

    public void EndAttack()
    {
        isAttack = false;
    }

    public void EnemyDestroy()
    {
        Destroy(gameObject);
    }

    public void StartMove()
    {
        isMove = true;
    }

    public void EndMove()
    {
        isMove = false;
    }
    public bool GetAttack()
    {
        return isAttack;
    }

}
