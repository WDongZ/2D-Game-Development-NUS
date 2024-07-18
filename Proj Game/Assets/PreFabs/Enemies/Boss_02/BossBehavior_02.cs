
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBehavior_02 : MonoBehaviour
{
    private float chasingDuration = 2f;
    private Animator anim;
    private bool isImmune;
    [SerializeField] private int immuneCount = 1;
    private float timmer = 0;
    [SerializeField] private int currentState = 0;
    private float timeA = 0;
    private float timeT = 0;
    private float timeI = 0;
    private float timeChasing = 0;
    [SerializeField] private float moveSpeed = 100;
    [SerializeField] private float hateDis = 0;
    [SerializeField] private float healthUpRate = 0.5f;
    [SerializeField] private float dashRate = 10f;
    private GameObject player;
    private float HP_Upbound;
    private Vector2 tSpeed;
    private float dashSpeed = 0;
    public int dashCount = 3;
    private int currentDash = 0;
    private bool dashState = false;
    private bool bulletState = false;
    private float attackinterval = 0;
    private int currentBullet = 0;
    public int bulletCount = 3;
    public int transBulletCount = 15;
    public GameObject bulletPrefab;
    private bool isTrans = false;
    public int BulletCount = 30;
    public GameObject transBulletPrefab;

    void Start()
    {
        HP_Upbound = GetComponent<EnemyController>().HP;
        anim = GetComponentInChildren<Animator>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        moveSpeed = GetComponent<EntityAttribute>().moveSpeed;
        StateMachine(currentState);
        if (GetComponent<EntityAttribute>().HP <= HP_Upbound * 0.5 && !isTrans)
        {
            isTrans = true;
            anim.SetBool("isTrans", true);
            GetComponent<EntityAttribute>().HP = HP_Upbound;
            GetComponent<Collider2D>().offset = new Vector2(-0.26f, -0.36f);
            GetComponent<BoxCollider2D>().size = new Vector2(0.74f, 1.9f);
            currentState = 4;
        }
        if (GetComponent<EntityAttribute>().HP <= 0)
        {

        }
    }

    private void Flip()
    {
        if (player.transform.position.x < gameObject.transform.position.x)
        {
            transform.right = Vector2.right;
        }
        else
        {
            transform.right = Vector2.left;
        }
    }

    private void StateMachine(int state)
    {
        switch (state)
        {
            case 0:
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                if (Vector2.Distance(player.transform.position, transform.position) > hateDis && timeChasing < chasingDuration && !dashState && !bulletState && !isTrans)
                {
                    timeChasing = 0;
                    currentState = 3;
                }
                else if (currentDash < dashCount)
                {
                    Flip();
                    dashState = true;
                    tSpeed = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
                    dashSpeed = 0;
                    currentDash++;
                    currentState = 1;
                    timeChasing = 0;
                    if (currentDash == dashCount)
                    {
                        dashState = false;
                        currentBullet = 0;
                    }
                }
                else if (currentBullet < bulletCount)
                {
                    bulletState = true;
                    currentState = 2;
                    currentBullet++;
                    timeChasing = 0;
                    if (currentBullet == bulletCount)
                    {
                        bulletState = false;
                        currentDash = 0;
                    }
                }
                else
                {
                    timmer += Time.deltaTime;
                }
                break;
            case 1:
                timmer = 0;
                DashAttack(tSpeed);
                break;
            case 2:
                if (attackinterval > .8f)
                {
                    anim.SetBool("isStance", true);
                    Fire();
                    attackinterval = 0;
                    currentState = 0;
                    break;
                }
                else
                {
                    attackinterval += Time.deltaTime;
                }
                break;
            case 3:
                timeChasing += Time.deltaTime;
                MoveTowardPlayer(GameObject.Find("Player").transform.localPosition);
                if (Vector2.Distance(player.transform.position, transform.position) < hateDis || timeChasing > chasingDuration) {
                    if (!isTrans) currentState = 0;
                    else currentState = 5;
                }
                break;
            case 4:
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<EnemyController>().hurtFactor = 0;
                timeT += Time.deltaTime;
                if (timeT >= 2)
                {
                    GetComponent<EnemyController>().hurtFactor = 1;
                    currentDash = 0;
                    currentBullet = 0;
                    dashState = false;
                    bulletState = false;
                    currentState = 5;
                }
                break;
            case 5:
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                if (Vector2.Distance(player.transform.position, transform.position) > hateDis && timeChasing < chasingDuration && !dashState && !bulletState)
                {
                    timeChasing = 0;
                    currentState = 3;
                }
                else if (currentDash < dashCount)
                {
                    Flip();
                    dashState = true;
                    tSpeed = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
                    dashSpeed = 0;
                    currentDash++;
                    currentState = 6;
                    timeChasing = 0;
                    if (currentDash == dashCount)
                    {
                        dashState = false;
                        currentBullet = 0;
                    }
                }
                else if (currentBullet < transBulletCount)
                {
                    bulletState = true;
                    currentState = 7;
                    currentBullet++;
                    timeChasing = 0;
                    if (currentBullet == transBulletCount)
                    {
                        bulletState = false;
                        currentDash = 0;
                    }
                }
                else
                {
                    timmer += Time.deltaTime;
                }
                break;
            case 6:
                timmer = 0;
                DashAttackTrans(tSpeed);
                break;
            case 7:
                if (attackinterval > .1f)
                {
                    anim.SetBool("transStance", true);
                    TransFire();
                    attackinterval = 0;
                    currentState = 5;
                    if (currentBullet == transBulletCount) anim.SetBool("transStance", false);
                    break;
                }
                else
                {
                    attackinterval += Time.deltaTime;
                }
                break;
        }
    }

    private void Fire()
    {
        Vector2 playerPos = GameObject.Find("Player").transform.position;
        Vector2 direction = (playerPos - new Vector2(transform.position.x, transform.position.y)).normalized;
        GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);
        bullet.transform.position = gameObject.transform.position;
        bullet.transform.right = GameObject.Find("Player").transform.position;
        bullet.GetComponent<Bullet>().SetTag("Enemy");
        bullet.GetComponent<Bullet>().SetSpeed(direction);
    }
    private void TransFire()
    {
        int halfbulletNum = BulletCount / 2;
        float spreadAngle = 12;
        for (int i = 0; i < BulletCount; i++)
        {
            Vector2 direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
            GameObject bullet = Instantiate(transBulletPrefab, transform.position, Quaternion.identity);
            bullet.transform.position = transform.position;
            if (BulletCount % 2 == 1)
            {
                bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(spreadAngle * (i - halfbulletNum) + Random.Range(-10f, 10f), Vector3.forward) * direction);
                bullet.GetComponent<Bullet>().SetTag(gameObject.tag);
                //bullet.GetComponent<Bullet>().SetDamage(GetComponent<PlayerAttribute>().damage);
            }
            else
            {
                bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(spreadAngle * (i - halfbulletNum) + spreadAngle / 2 + Random.Range(-10f, 10f), Vector3.forward) * direction);
                bullet.GetComponent<Bullet>().SetTag(gameObject.tag);
                // bullet.GetComponent<Bullet>().SetDamage(GetComponent<PlayerAttribute>().damage);
            }
        }
    }

    private void DashAttack(Vector2 tSpeed)
    {
        GetComponent<EnemyController>().StartAttack();
        dashSpeed += Time.deltaTime * dashRate;
        GetComponent<Rigidbody2D>().velocity = new Vector2(tSpeed.x * moveSpeed * dashSpeed, tSpeed.y * moveSpeed * dashSpeed);
    }

    private void DashAttackTrans(Vector2 tSpeed)
    {
        anim.SetBool("transDash", true);
        dashSpeed += Time.deltaTime * dashRate;
        GetComponent<Rigidbody2D>().velocity = new Vector2(tSpeed.x * moveSpeed * dashSpeed, tSpeed.y * moveSpeed * dashSpeed);
    }

    private void MoveTowardPlayer(Vector3 p)
    {
        Flip();
        Vector2 tSpeed = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
        GetComponent<Rigidbody2D>().velocity = new Vector2(tSpeed.x * moveSpeed, tSpeed.y * moveSpeed); 
    }

    public void CurrentStateToZero()
    {
        if (!isTrans) currentState = 0;
        else currentState = 4;
    }

    public void SetCurrentState(int iState)
    {
        currentState = iState;
    }


}
