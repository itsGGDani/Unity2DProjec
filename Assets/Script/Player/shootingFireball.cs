using System.Xml.Serialization;
using Unity.GraphToolkit.Editor;
using UnityEngine;

public class shootingFireball : MonoBehaviour
{
    public GameObject fireballPrefab; 
    public float fireballSpeed = 10f;
    [SerializeField] Transform firepoint;

    public bool facing = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            facing = horizontalInput > 0;

            print(horizontalInput);
            GameObject fb = Instantiate(fireballPrefab, transform.position, transform.rotation);

            Fireball fireballScript = fb.GetComponent<Fireball>();
            fireballScript.direction = facing ? Vector2.right : Vector2.left;
            print(facing);
        }
    }
}
