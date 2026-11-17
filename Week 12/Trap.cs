using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.health -= damage;
        }

        Knockback knockback = other.GetComponent<Knockback>();
        if (knockback != null)
        {
            Vector2 direction = (other.transform.position - transform.position).normalized;
            knockback.ApplyKnockback(direction);
        }
    }
}