using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

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
    private GameObject stave;

    private GameObject roomBound;

    void Start()
    {

        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        dashTime = -dashCoolTime;
        stave = GameObject.Find("Stave");
    }

    void Update()
    {
        CheckInput();

        dashTime -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTime < -dashCoolTime) dashTime = dashDuration;

        checkFlip();
        AnimatorControllers();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void AttackOver()
    { 
        isAttacking = false;
    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttacking = true;
        }
     

    }

    private void Movement()
    {
        Vector2 normSpeed = GetComponent<Rigidbody2D>().velocity.normalized;
        if (dashTime > 0) rb.velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + normSpeed.x * dashSpeedFactor,
                                                    GetComponent<Rigidbody2D>().velocity.y + normSpeed.y * dashSpeedFactor);
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
    }

    private void Flip()
    {
        facingDir = -facingDir;
        faceRight = !faceRight;
        transform.Rotate(0, 180, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<LayerMask>().Equals("Door"))
            EnterRoom(collision.name, collision.GetComponentInParent<Transform>().position);
        else if (collision.GetComponent<LayerMask>().Equals("Room"))
            roomBound = collision.gameObject;
    }

    public GameObject GetRoomBound()
    {
        return roomBound;
    }

    private void EnterRoom (string doorName, Vector2 pos)
    {

    }

}
