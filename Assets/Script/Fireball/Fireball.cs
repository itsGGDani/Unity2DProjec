using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    public float speed = 10f;
    public Vector2 direction = Vector2.right;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = direction * speed;
        spriteRenderer.flipX = direction.x < 0;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("explode", true);
        Destroy(gameObject, 0.5f);
    }
}
