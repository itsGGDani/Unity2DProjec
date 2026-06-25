using UnityEngine;

public class shootingBullet : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform sniperShootLeft;
    public Transform sniperShootRight;

    public int fireballSpeed = 100;
    public bool facing = true;


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

    // Update is called once per frame
    void Update()
    {
        
    }
}
