using UnityEngine;
using UnityEngine.Assertions.Must;

public class APBehaviour : Attacker
{
    private GameObject player;
    [SerializeField] private float moveSpeed = 0;
    [SerializeField] private float mTurnRate = 0.2f;
    private float HP;

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
        MoveTowardPlayer(player.transform.position, mTurnRate * Time.smoothDeltaTime);
        transform.position += moveSpeed * Time.smoothDeltaTime * (Vector3.zero - transform.right); 
    }

    private void MoveTowardPlayer(Vector3 p, float r)
    {
        
        Vector3 v = p - transform.position;
        transform.right = Vector3.zero - Vector3.LerpUnclamped((Vector3.zero - transform.right), v, r); 
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("APHurt");
        if(collision.gameObject.tag == "Player") { collision.GetComponent<PlayerController>().GetHurt(gameObject); }
    }

    private void OnDestroy()
    {
        GameObject.Find("BOSS").GetComponent<BossBehavior_01>().LossAP();
    }

}
