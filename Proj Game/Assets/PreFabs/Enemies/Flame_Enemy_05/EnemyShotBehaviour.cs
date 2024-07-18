using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotBehaviour : MonoBehaviour
{
    private Animator anim;  
    private int currentState = 0;
    [SerializeField] private float timmer = 0;
    [SerializeField] private float timer = 0;
    [SerializeField] private float timeChasing = 0;
    [SerializeField] private float moveSpeed = 0.01f;
    [SerializeField] private float hateDis = 0.1f;
    [SerializeField] private float attackinterval = 0;
    private Rigidbody2D rb;
    private GameObject player;
    public int BulletCount = 24;

    public float spreadAngle = 30;

    private Vector2 direction;

    public GameObject bulletPrefab;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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
                if(attackinterval > 2)
                {
                    GetComponent<EnemyController>().StartAttack();
                    if (timer > 0.6)
                    {
                        Burst();
                        GetComponent<EnemyController>().EndAttack();
                        timer = 0;
                        currentState = 2;
                    }
                    else
                    {
                        timer += Time.deltaTime;
                    }
                }
                else
                {
                    attackinterval += Time.deltaTime;
                }
                break;
            case 2:
                GetComponent<EnemyController>().StartMove();
                GetComponent<EnemyController>().EndAttack();
                timeChasing += Time.deltaTime;
                attackinterval = 0;
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
        int halfbulletNum = BulletCount / 2;
        for (int i = 0; i < BulletCount; i++)
        {
            direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.transform.position = transform.position;
            if (BulletCount % 2 == 1)
            {
                bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(spreadAngle * (i - halfbulletNum), Vector3.forward) * direction);
                bullet.GetComponent<Bullet>().SetTag(gameObject.tag);
                //bullet.GetComponent<Bullet>().SetDamage(GetComponent<PlayerAttribute>().damage);
            }
            else
            {
                bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(spreadAngle * (i - halfbulletNum) + spreadAngle / 2, Vector3.forward) * direction);
                bullet.GetComponent<Bullet>().SetTag(gameObject.tag);
               // bullet.GetComponent<Bullet>().SetDamage(GetComponent<PlayerAttribute>().damage);
            }
        }
    }

}
