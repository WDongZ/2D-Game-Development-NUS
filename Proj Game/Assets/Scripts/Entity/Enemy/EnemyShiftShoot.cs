using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShiftShoot : MonoBehaviour
{
    private Vector2 direction;

    private float YN = 0;
    private Animator anim;   
    private int currentState = 0;
    [SerializeField] private float timer = 0;
    [SerializeField] private float timmer = 0;
    [SerializeField] private float timeChasing = 0;
    [SerializeField] private float moveSpeed = 0.01f;
    [SerializeField] private float hateDis = 0.1f;
    [SerializeField] private float attackinterval = 1.5f;
    [SerializeField] private float attacktimer = 0;
    private GameObject player;
    public GameObject bulletPrefab;

    private Rigidbody2D rb;

    public int bulletnum = 0;

    private float currentOffsetAngle = 0f;

    private bool isFirstShot = true;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        StateMachine(currentState);
    }

    private void StateMachine(int state)
    {
        switch (state)
        {
            case 0:
                GetComponent<EnemyController>().EndMove();
                GetComponent<EnemyController>().EndAttack();
                if (timmer > 3 || timeChasing > 1)
                {
                    currentState = 1;
                    timmer = 0;
                    timeChasing = 0;
                }
                else if (Vector2.Distance(player.transform.position,transform.position) > hateDis) { currentState = 2; }
                else
                {
                    timmer += Time.deltaTime;
                }
                break;
            case 1:
                if(attacktimer > attackinterval)
                {
                    GetComponent<EnemyController>().StartAttack();
                    if(timer > 0.2)
                    {
                        Burst();
                        GetComponent<EnemyController>().EndAttack();
                        timer = 0;
                        if(bulletnum >= 13)
                        {
                            currentState = 2;
                            bulletnum = 0;
                            currentOffsetAngle = 0;
                            isFirstShot = true;
                        }
                        else
                        {
                            bulletnum++ ;
                        }
                    }
                    else
                    {
                        timer += Time.deltaTime;
                    }
                }
                else
                {
                    attacktimer += Time.deltaTime;
                }
                break;
            case 2:
                GetComponent<EnemyController>().StartMove();
                attacktimer = 0;
                timeChasing += Time.deltaTime;
                MoveTowardPlayer(GameObject.Find("Player").transform.position);
                if (Vector2.Distance(player.transform.position, transform.position) < hateDis || timeChasing > 1) {
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    currentState = 0; 
                }
                break;

        }
    }

    private void MoveTowardPlayer(Vector3 p)
    {
        Vector2 direction = (p - transform.position).normalized;
        rb.velocity = direction * moveSpeed * Time.deltaTime;
    }

    private void Burst()
    {
    
        Fire();
    }

    private void Fire()
    {
        Vector2 Tempdirection;
    if (isFirstShot)
    {
        Vector2 playerPos = GameObject.Find("Player").transform.position;
        direction = (playerPos - new Vector2(transform.position.x, transform.position.y)).normalized;
        Tempdirection = direction;
        isFirstShot = false;
        YN = Random.Range(0, 1);
        return;
    }
    else
    {
        Quaternion rotationOffset = Quaternion.Euler(0, 0, currentOffsetAngle);
        Tempdirection = rotationOffset * direction;
        if(YN <= 0.5f)
        {
            if(bulletnum >= 5)
            {
                YN = 1;
            }
            currentOffsetAngle -= 8f;
        }
        else
        {
            currentOffsetAngle += 8f;
        }
    }
    GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);
    bullet.transform.position = gameObject.transform.position;
    bullet.transform.right = Tempdirection;
    bullet.GetComponent<Bullet>().SetTag("Enemy");
    bullet.GetComponent<Bullet>().SetSpeed(Tempdirection);
    }
}
