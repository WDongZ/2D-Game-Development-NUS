using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [Header("Dash info")]
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashCoolTime;
    private float dashTime;

    [Header("Attack info")]
    [SerializeField] private float comboTime = .3f;
    private float comboTimeCounter;
    private bool isAttacking = false;
    private int comboCounter;

    private Animator anim;
    private Rigidbody2D rb;
    private float xInput;
    private float yInput;
    private int facingDir = 1;
    private bool faceRight = true;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        dashTime = -dashCoolTime;
    }

    void Update()
    {
        Movement();
        CheckInput();

        comboTimeCounter -= Time.deltaTime;

        if (comboTimeCounter < 0) comboCounter = 0;

        dashTime -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTime < -dashCoolTime) dashTime = dashDuration;

        checkFlip();
        AnimatorControllers();
    }

    public void AttackOver()
    { 
        isAttacking = false;

        comboCounter++;

        if (comboCounter > 2) comboCounter = 0;
    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttacking = true;
            comboTimeCounter = comboTime; 
        }
     

    }

    private void Movement()
    {
        if (dashTime > 0) rb.velocity = new Vector2(facingDir * dashSpeed, 0);
        else rb.velocity = new Vector2(xInput * moveSpeed, yInput * moveSpeed);
    }

    private void checkFlip()
    {
        if ((xInput < 0 && faceRight) || (xInput > 0 && !faceRight)) Flip();
    }



    private void AnimatorControllers()
    {
        bool isMoving = rb.velocity.x != 0;

        anim.SetFloat("yVelocity", rb.velocity.y);

        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isDashing", dashTime > 0);
        anim.SetBool("isAttacking", isAttacking);
        anim.SetInteger("comboCounter", comboCounter);
    }

    private void Flip()
    {
        facingDir = -facingDir;
        faceRight = !faceRight;
        transform.Rotate(0, 180, 0);
    }


}
