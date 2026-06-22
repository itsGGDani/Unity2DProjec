using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public LayerMask groundLayer;
    public Transform player;
    public float speed;
    public int atkDmg;


    [SerializeField]
    Transform target;
    public float aggroRange;

    Rigidbody2D rb;
    int dir = 1;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            float dst = (transform.position - target.position).magnitude;

            if (dst > aggroRange)
            {
                target = null;
                return;
            }

            if (dst < 2)        // attack
            {
                rb.linearVelocity = Vector2.zero;
                attack();
                return;
            }

            int lastDir = dir;
            dir = target.position.x > transform.position.x ? 1 : -1;
            
            if (dir != lastDir)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                rb.linearVelocity = Vector2.zero;
            }
        }
        else
        {
            if (!onGround(transform.position, speed / 2))
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                dir *= -1;
                rb.linearVelocity = Vector2.zero;
            }

            findTarget();
        }
        Vector2 mov = new Vector2(speed * dir, 0);

        if (rb.linearVelocity.magnitude < speed)
            rb.linearVelocity += mov;
    }

    public void findTarget()
    {
        float dst = (transform.position - player.position).magnitude;

        if (dst < aggroRange)
            target = player;
    }


    public bool onGround(Vector2 pos, float offset)
    {
        RaycastHit2D hit = Physics2D.Raycast(
            pos + new Vector2(offset * dir, 0),
            Vector2.down,
            4,
            groundLayer
        );

        return hit.collider != null;
    }


    public void attack()
    {
        player p = target.gameObject.GetComponent<player>();
        if (p)
        {
            p.takeDmg(atkDmg);
        }
        else
        {
            Debug.Log("no player ");
        }
    }
}
