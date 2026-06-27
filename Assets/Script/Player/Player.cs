using UnityEngine;

public class Player : MonoBehaviour
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

        if (Input.GetKeyDown(KeyCode.W))
        {
            takeDmg(20);
        }        
    }

    public void takeDmg(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }
}
