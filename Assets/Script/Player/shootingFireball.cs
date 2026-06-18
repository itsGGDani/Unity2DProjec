using System.Xml.Serialization;
using Unity.GraphToolkit.Editor;
using UnityEngine;

public class shootingFireball : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firepointRight;
    public Transform firepointLeft;
    public float fireballSpeed = 10f;
    public bool facing = true;

    private void Awake()
    {
        //Um das drecks ding zu Finden
        if(firepointRight == null)
        {
            firepointRight = transform.Find("firepointRight");
        }   

        if(firepointLeft == null)
        {
            firepointLeft = transform.Find("firepointLeft");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Richting
            float horizontalInput = Input.GetAxis("Horizontal");

            if(horizontalInput > 0)
            {
                facing = true;
            } else if(horizontalInput < 0)
            {
                facing = false;
            }
            
            Transform firepoint = facing ? firepointRight : firepointLeft;
            GameObject fb = Instantiate(fireballPrefab, firepoint.position, firepoint.rotation);
            
            Fireball fireballScript = fb.GetComponent<Fireball>();
            fireballScript.direction = facing ? Vector2.right : Vector2.left;
            print(facing);
        }
    }
}
