using UnityEngine;

public class shootingBullet : MonoBehaviour
{
    public GameObject bulletPrefab;

    [SerializeField] public Transform targetPlayer;
    private int dmg = 10;
    public float range = 20;
    public float firerate = 1f;
    public LayerMask targetLayer;

    // Du brauchst nur noch EINEN Punkt am Ende des Laufs!
    public Transform sniperShootPoint;

    public float bulletSpeed = 15f;

    public Transform rotationPoint;
    private Transform currentTarget;
    private float nextTimeToFire = 0;

    private void Awake()
    {
        if (sniperShootPoint == null)
        {
            sniperShootPoint = transform.Find("sniperShootRight");
            if (sniperShootPoint == null) sniperShootPoint = transform.Find("bulletPos");
        }
    }

    void Update()
    {
        FindTarget();
        if (currentTarget != null)
        {
            RotateTowardsTarget();
            if (Time.time > nextTimeToFire)
            {
                Shoot();
                nextTimeToFire = Time.time + 1f / firerate;
            }
        }
    }

    void Shoot()
    {
        Debug.Log("I NEED MORE BULLETS");

        if (bulletPrefab != null && sniperShootPoint != null)
        {
            // Spawnt direkt am vorderen Punkt und nutzt dessen gedrehte Richtung
            GameObject bullet = Instantiate(bulletPrefab, sniperShootPoint.position, sniperShootPoint.rotation);

            if (bullet.TryGetComponent<Rigidbody2D>(out var rb))
            {
                rb.linearVelocity = sniperShootPoint.right * bulletSpeed;
            }
        }
    }

    void FindTarget()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, range, targetLayer);

        if (collider != null)
        {
            currentTarget = collider.transform;
        }
        else
        {
            currentTarget = null;
        }
    }

    void RotateTowardsTarget()
    {
        if (rotationPoint == null) return;

        Vector2 dir = currentTarget.position - rotationPoint.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        rotationPoint.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}