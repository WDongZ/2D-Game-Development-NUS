using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseAttack : Attacker
{
    public bool InRange = false;
    //[SerializeField] private float timmer = 0;
    private GameObject player;
    private int currentState = 0;
    //[SerializeField] private float timeChasing = 0;
    [SerializeField] private float moveSpeed = 0;
    [SerializeField] private float hateDis = 1f;
    //[SerializeField] private float attackRange = 1.5f; //范围
    [SerializeField] private float attackCooldown = 2f; //冷却时间
    private float attackTimer = 0;
    private float HP;

    //private Animator anim;
    private Rigidbody2D rb;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void Start()
    {
        HP = GetComponent<EnemyController>().HP;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        attackTimer -= Time.deltaTime;
        StateMachine(currentState);
    }

    private void StateMachine(int state)
    {
        switch (state)
        {
            case 0:

                GetComponent<EnemyController>().EndMove();
                GetComponent<EnemyController>().EndAttack();
                if (Vector2.Distance(player.transform.position, transform.position) > hateDis)
                {
                    currentState = 2; //追逐
                }
                else if (attackTimer <= 0 && InRange == true)
                {
                    currentState = 1; 
                }
                break;

            case 1:
                
                GetComponent<EnemyController>().EndMove();
                GetComponent<EnemyController>().StartAttack();
                Attack();
                attackTimer = attackCooldown;
                currentState = 2;
                break;

            case 2:
                if(GetComponent<EnemyController>().GetAttack()== true || HP <= 0)
                {
                    break;
                }
                GetComponent<EnemyController>().StartMove();
                MoveTowardPlayer(player.transform.position);
                if(InRange == true)
                {
                    currentState = 1;
                }
                break;
        }
    }

    private void MoveTowardPlayer(Vector3 targetPosition)
    {
        if(player.transform.position.x < gameObject.transform.position.x)
        {
            transform.right = Vector2.left;
        }
        else
        {
            transform.right = Vector2.right;
        }
        Vector2 direction = (targetPosition - transform.position).normalized;
        rb.velocity = direction * moveSpeed * Time.deltaTime;
    }

    private void Attack()
    {
        GetComponent<EnemyController>().StartAttack();
        rb.velocity = Vector2.zero;
    }

    private void Hurt()
    {
        if(InRange == true)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().GetHurt(gameObject);
            Debug.Log("Hurt");
        }

    }

    public void SetInRange()
    {
        InRange = true;
    }

    public void NotInRange()
    {
        InRange = false;
    }

}
