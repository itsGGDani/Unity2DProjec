using UnityEngine;

public class player : MonoBehaviour
{
    public int currentHealth = 100;
    public int maxHealth = 100;

    [SerializeField] public HealthBarScript healthBar;


    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        print("HHJSJHDKAJKHDKJHASDKJHSADHKKDJH");

        if (Input.GetKeyDown(KeyCode.W))
        {
            print("hier aufgerudfe");
            takeDmg(20);
        }        
    }

    void takeDmg(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }
}
