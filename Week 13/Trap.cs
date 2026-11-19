using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damage = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.health -= damage;
            playerHealth.isDamaged = true;
        }

        Knockback knockback = other.GetComponent<Knockback>();
        if (knockback != null)
        {
            Vector2 direction = (other.transform.position - transform.position).normalized;
            knockback.ApplyKnockback(direction);
        }
    }
}

