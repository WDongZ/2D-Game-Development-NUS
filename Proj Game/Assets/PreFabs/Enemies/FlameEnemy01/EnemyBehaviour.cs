using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    private Animator anim;   
    private int currentState = 0;


    [SerializeField] private float timmer = 0;
    [SerializeField] private float timeChasing = 0;
    [SerializeField] private float moveSpeed = 0.01f;
    [SerializeField] private float hateDis = 0.1f;
    [SerializeField] private float attackinterval = 0;
    private GameObject player;

    public GameObject bulletPrefab;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        moveSpeed = GetComponent<EntityAttribute>().moveSpeed;
        StateMachine(currentState);
        if (GetComponent<EntityAttribute>().HP <= 0)
        {
            currentState = 0;
        }
    }

    private void StateMachine(int state)
    {
        switch (state)
        {
            case 0:
                GetComponent<EnemyController>().EndMove();
                GetComponent<EnemyController>().EndAttack();
                if (timmer > 3 || timeChasing > 2)
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
                if(attackinterval>0.8)
                {
                    GetComponent<EnemyController>().StartAttack();
                    Burst();
                    currentState = 2;
                    break;
                }
                else
                {
                    attackinterval += Time.deltaTime;
                }
                break;
            case 2:
                GetComponent<EnemyController>().StartMove();
                attackinterval = 0;
                timeChasing += Time.deltaTime;
                MoveTowardPlayer(GameObject.Find("Player").transform.position);
                if (Vector2.Distance(player.transform.position, transform.position) < hateDis || timeChasing > 2) {
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    currentState = 0; 
                }
                break;

        }
    }

    private void MoveTowardPlayer(Vector3 p)
    {
        Vector2 tSpeed = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
        GetComponent<Rigidbody2D>().velocity = new Vector2(tSpeed.x * moveSpeed * 100, tSpeed.y * moveSpeed * 100); 
        
    }

    private void Burst()
    {
    
        Fire();
    }

    private void Fire()
    {
        Vector2 playerPos = GameObject.Find("Player").transform.position;
        Vector2 direction = (playerPos - new Vector2(transform.position.x,transform.position.y)).normalized;
        GameObject bullet = Instantiate(bulletPrefab,gameObject.transform.position,Quaternion.identity);
        bullet.transform.position = gameObject.transform.position;
        bullet.transform.right = GameObject.Find("Player").transform.position;
        bullet.GetComponent<Bullet>().SetTag("Enemy");
        bullet.GetComponent<Bullet>().SetSpeed(direction);
    }
}
