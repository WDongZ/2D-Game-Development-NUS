using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveBullet : MonoBehaviour
{
    public BulletData bulletData;

    public void SetDamage(float _damage)
    {
        bulletData.damage = _damage;
    }
    public float lerp;

    public float speed = 15f;

    new private Rigidbody2D rigidbody2D;

    private Vector3 targetPos;

    private Vector3 direction;

    private bool isHere;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetTargetPos(Vector2 _target)
    {
        isHere = false;
        targetPos = _target;
    }
    private void FixedUpdate()
    {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (targetPos - transform.position).normalized;
        if (!isHere)
        {
            transform.right = Vector3.Slerp(transform.right, direction, lerp/Vector2.Distance(transform.position, targetPos));
            rigidbody2D.velocity = transform.right * speed;
        }
        if(Vector2.Distance(transform.position, targetPos) < 1f&& !isHere)
        {
            isHere = true;
        }
    }
}
