using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public LayerMask groundLayer;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //groundLayer.value = 3;
    }

    // Update is called once per frame
    void Update()
    {
        int dir = transform.localScale.x > 0 ? 1 : -1;

        Vector2 fPos = (Vector2)transform.position + new Vector2(2 * dir, 0 * dir);

        if (onGround(fPos))
        {
            Debug.Log("Hello World!");
            transform.position = fPos;

        } else
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }


    public bool onGround(Vector2 pos)
    {
        RaycastHit2D hit = Physics2D.Raycast(
            pos,
            Vector2.down,
            3,
            groundLayer
        );

        return hit.collider != null;
    }

}
