using UnityEngine;

public class shootingBullet : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletPos;
    public Transform sniperShootLeft;
    public Transform sniperShootRight;

    public int fireballSpeed = 100;
    public bool facing = true;

    private float timer = 0;
    private void Awake()
    {
        //Um das drecks ding zu Finden
        if (sniperShootRight == null)
        {
            sniperShootRight = transform.Find("sniperShootRight");
        }
        if (sniperShootLeft == null)
        {
            sniperShootLeft = transform.Find("sniperShootLeft");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;
            print("SKHDKJAHSDLKJ");
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bulletPrefab, bulletPos.position, Quaternion.identity);
    }
}
