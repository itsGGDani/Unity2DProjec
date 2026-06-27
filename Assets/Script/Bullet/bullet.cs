using UnityEngine;

public class bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 15f; // 100 ist für Rigidbody oft extrem schnell, 15-20 reicht meistens

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        // Die Kugel fliegt einmalig in die Richtung, in die sie beim Instanziieren gedreht wurde.
        // transform.right ist die lokale "Vorwärts"-Achse der Kugel.
        if (rb != null)
        {
            rb.linearVelocity = transform.right * speed;
        }

        Destroy(gameObject, 2f);
    }

    // Die Update-Methode löschen wir komplett! 
    // Wenn man rb.linearVelocity in jedem Frame überschreibt, 
    // kann die Kugel sich nicht mehr frei durch die Physik bewegen.

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Gibt in der Konsole aus, was die Kugel berührt, falls sie stecken bleibt
        print("Kugel berührt: " + other.gameObject.name);

        if (other.CompareTag("MainPlayer"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.takeDmg(20);
            }
            Destroy(gameObject);
        }
        // Ignoriert den Sniper selbst (Achte auf exakte Schreibweise oder nutze Tags)
        else if (other.CompareTag("Enemy") || other.gameObject.name == "sniper")
        {
            return; // Tu nichts, flieg weiter!
        }
        else
        {
            // Bei Wänden oder Boden löschen
            Destroy(gameObject);
        }
    }
}