using UnityEngine;

public class Fireball : MonoBehaviour
{    
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    public float speed = 10f;
    public Vector2 direction = Vector2.right;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = direction * speed;
        Destroy(gameObject, 5f);

    }
}
