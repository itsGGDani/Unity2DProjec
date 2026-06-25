using System;
using UnityEditor.Rendering;
using UnityEngine;

public class robotterMovement : MonoBehaviour
{
    public int health = 40;
    [SerializeField] private Rigidbody2D rb;
    private BoxCollider2D rbCollider;
    [SerializeField] SpriteRenderer spriteRenderer;
    private int startDirection = 1;
    [SerializeField] private float speed = 0.05f;
    private Vector2 movement;
    private int currentDirection;
    private float halfWith;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        halfWith = spriteRenderer.bounds.extents.x;
        currentDirection = startDirection;
    }

    //Better because it does not ticks with the unity Engine, it will be more consistent with the physics engine
    void FixedUpdate()
    {
        movement.x = speed * currentDirection;
        movement.y = rb.linearVelocityY;
        rb.linearVelocity = movement;

        SetDirection();

        if (currentDirection == 1)
        {
            spriteRenderer.flipX = false;
        } else if(currentDirection == -1)
        {
            spriteRenderer.flipX = true;
        }


    }

    private void SetDirection()
    {
        if (Physics2D.Raycast(transform.position, Vector2.right, halfWith + 0.1f, LayerMask.GetMask("Default")) &&
            rb.linearVelocity.x > 0) {
            currentDirection *= -1;
        }else if(Physics2D.Raycast(transform.position, Vector2.left, halfWith + 0.1f, LayerMask.GetMask("Default")) && rb.linearVelocity.x < 0){
            currentDirection *= -1;
        }

        print("Current Direction: " + currentDirection);
        print("Layermastk: " + LayerMask.GetMask("Default"));
        Debug.DrawRay(transform.position, Vector2.right * (halfWith + 0.1f), Color.red);
        Debug.DrawRay(transform.position, Vector2.left * (halfWith + 0.1f), Color.red);
    }
}