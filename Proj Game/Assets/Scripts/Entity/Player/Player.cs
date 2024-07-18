using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private PlayerAttribute playerAttribute;
    public GameObject deadMenu;

    [Header("Dash info")]
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashSpeedFactor;
    [SerializeField] private float dashCoolTime;
    private float dashTime;

    [Header("Attack info")]
    private bool isAttacking = false;

    private Animator anim;
    private Rigidbody2D rb;
    private float xInput;
    private float yInput;
    private int facingDir = 1;
    private bool faceRight = true;
    private bool isDead = false;

    [Header("Map info")]
    [SerializeField] private float mapSpeed;
    public Camera miniMap;

    private bool isHurt = false;
    public Vector3 birthPos = Vector3.zero;
    private float attackTime;

    private RawImage minimap;

    public GameObject wave;

    private float UltSpeed;

    void Start()
    {
        playerAttribute = GetComponent<PlayerAttribute>();
        transform.position = birthPos;
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        dashTime = -dashCoolTime;
        minimap = GameObject.Find("MiniMap").GetComponent<RawImage>();
    }

    void Update()
    {
        if (!isDead) Movement();
        CheckInput();
        dashTime -= Time.deltaTime;
        attackTime -= Time.deltaTime;
        UltSpeed -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTime < -dashCoolTime) dashTime = dashDuration;
        checkFlip();
        AnimatorControllers();
        if (playerAttribute.HP <= 0)
        {
            deadMenu.SetActive(true);
            playerAttribute.HP = 0;
            isDead = true;
            rb.velocity = Vector2.zero;
            GetComponent<Collider2D>().enabled = false;
        }
        GetComponent<BulletControl>().bulletPrefabs = GetComponent<PlayerAttribute>().bullets;
        GetComponent<BulletControl>().bulletRates = GetComponent<PlayerAttribute>().bulletRates;
    }


    public void AttackOver()
    {
        isAttacking = false;
    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Mouse0) && attackTime <= 0)
        {
            attackTime = playerAttribute.attackSpeed;
            Vector2 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mPos - new Vector2(transform.position.x, transform.position.y)).normalized;
            GetComponent<BulletControl>().Burst(playerAttribute.attackSpeed, direction, new Vector3(transform.position.x + direction.x, transform.position.y + direction.y,0));
            isAttacking = true;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!minimap.enabled)
            {
                minimap.enabled = true;
                miniMap.transform.position = new Vector3(transform.position.x, transform.position.y, -20);
            }
            else
            {
                minimap.enabled = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && UltSpeed <= 0)
        {
            UltSpeed = 2f;
            wave.GetComponent<Ult>().StartWave();
            GetComponent<EntityAttribute>().HP -= 2;
        }

    }

    private void Movement()
    {
        Vector2 normSpeed = GetComponent<Rigidbody2D>().velocity.normalized;
        if (dashTime > 0)
        {
            if (rb.velocity != Vector2.zero)
                rb.velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + normSpeed.x * dashSpeedFactor, GetComponent<Rigidbody2D>().velocity.y + normSpeed.y * dashSpeedFactor);
            else rb.velocity = new Vector2((faceRight ? 1 : -1) * dashSpeedFactor, 0);
        }
        else rb.velocity = new Vector2(xInput * playerAttribute.moveSpeed, yInput * playerAttribute.moveSpeed);
    }

    private void checkFlip()
    {
        if ((xInput < 0 && faceRight) || (xInput > 0 && !faceRight)) Flip();
    }



    private void AnimatorControllers()
    {
        bool isMoving = rb.velocity.x != 0;

        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isDashing", dashTime > 0);
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("isHurt", isHurt);
        anim.SetBool("isDead", isDead);
    }

    private void Flip()
    {
        facingDir = -facingDir;
        faceRight = !faceRight;
        transform.Rotate(0, 180, 0);
    }




    private void EnterRoom(string doorName, Vector2 pos)
    {

    }

    public void GetHurt(GameObject attacker)
    {
        if (!isHurt && dashTime < 0)
        {
            anim.Play("Player_Idel");
            isHurt = true;
            playerAttribute.HP -= (int)attacker.GetComponent<Attacker>().damage;
        }
    }

    public void GetHurt(int damage)
    {
        if (!isHurt && dashTime < 0)
        {
            anim.Play("Player_Idel");
            isHurt = true;
            playerAttribute.HP -= damage;
        }
    }

    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }

    private void EndHurt()
    {
        isHurt = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetHurt(1);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetHurt(1);
        }
    }
}
