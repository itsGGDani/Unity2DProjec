using UnityEngine;

public class shootingFireball : MonoBehaviour
{
    public GameObject fireballPrefab; 
    public Transform firepoint;
    public float fireballSpeed = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(fireballPrefab, firepoint.position, firepoint.rotation);
        }
    }
}
