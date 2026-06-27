using UnityEngine;

public class shootingBullet : MonoBehaviour
{
    public GameObject bulletPrefab;

    [SerializeField] public Transform targetPlayer;
    private int dmg = 10;
    public float range = 20;
    public float firerate = 1f;
    public LayerMask targetLayer;

    // sniperShootLeft/Right sollten Child-Objekte deines rotationPoint sein, 
    // damit sie sich mitdrehen!
    public Transform sniperShootLeft;
    public Transform sniperShootRight;

    public float bulletSpeed = 15f; // Von int auf float geändert und im Code genutzt

    public Transform rotationPoint;
    private Transform currentTarget;
    private float nextTimeToFire = 0;

    private void Awake()
    {
        // Um das drecks ding zu Finden (Suche im gesamten Objektbaum)
        if (sniperShootRight == null) sniperShootRight = transform.Find("sniperShootRight");
        if (sniperShootLeft == null) sniperShootLeft = transform.Find("sniperShootLeft");
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

        if (bulletPrefab != null)
        {
            // 1. Richtigen Spawnpoint wählen (ist der Gegner links oder rechts vom Sniper?)
            Transform activeShootPoint = sniperShootRight; // Standard rechts

            if (currentTarget.position.x < transform.position.x)
            {
                activeShootPoint = sniperShootLeft; // Gegner ist links
            }

            if (activeShootPoint == null) return;

            // 2. Kugel DIREKT am richtigen Punkt mit der richtigen Rotation spawnen
            GameObject bullet = Instantiate(bulletPrefab, activeShootPoint.position, activeShootPoint.rotation);

            // 3. Rigidbody prüfen (Muss != null sein!)
            if (bullet.TryGetComponent<Rigidbody2D>(out var rb))
            {
                // Die Kugel fliegt immer nach "vorne" (X-Achse / right) des jeweiligen Launchers
                rb.linearVelocity = activeShootPoint.right * bulletSpeed;
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

        // WICHTIG: Erst Y, dann X!
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        rotationPoint.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Damit du die Range im Editor siehst
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}