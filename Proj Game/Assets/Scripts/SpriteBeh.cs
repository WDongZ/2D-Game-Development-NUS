using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBeh : MonoBehaviour
{
    public float moveDistance = 2f;
    public float moveSpeed = 2f;   
    public float acceleration = 2f; 
    private Vector2 startPosition;  
    private bool movingDown = true; 

    private float currentSpeed = 0f; 
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        float currentY = transform.position.y;

        if (movingDown)
        {
            currentSpeed += acceleration * Time.deltaTime;
            if (currentY <= startPosition.y - moveDistance)
            {
                movingDown = false;
            }
        }
        else
        {
            currentSpeed -= acceleration * Time.deltaTime;
            if (currentY >= startPosition.y)
            {
                movingDown = true;
            }
        }

        currentSpeed = Mathf.Clamp(currentSpeed, -moveSpeed, moveSpeed);

        rb.velocity = new Vector2(rb.velocity.x, movingDown ? -currentSpeed : currentSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(startPosition, startPosition + Vector2.down * moveDistance);
    }
}

