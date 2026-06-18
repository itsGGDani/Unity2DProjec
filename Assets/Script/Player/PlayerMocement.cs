   using System;
using System.IO;
using Unity.GraphToolkit.Editor;
using UnityEngine;

public class PlayerMocement : MonoBehaviour
{   
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float jumpForce = 10f;
    private bool isGrounded;
    private Rigidbody2D rb;
    [SerializeField] public Animator animator;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
     
        if(moveInput == 0){
            animator.SetBool("isRunning", false);
        }
        else{
            animator.SetBool("isRunning", true);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if(moveInput > 0){
            spriteRenderer.flipX = false;

        }else if(moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }

        if(Input.GetKeyDown(KeyCode.Q)) {
            animator.SetTrigger("isShooting");
        }
        else
        {
           animator.ResetTrigger("isShooting");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
