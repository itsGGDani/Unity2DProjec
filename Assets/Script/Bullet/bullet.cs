using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject gameObject;
    public Vector2 direction = Vector2.right;
    private Rigidbody2D rb;
    public float speed = 100;

    public SpriteRenderer renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }


    public void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = direction * speed;
        renderer.flipX = direction.x < 0;
    }
}
