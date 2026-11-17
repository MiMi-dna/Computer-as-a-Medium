using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHealth = 100f;
    public float swordDamage = 10f;
    public float knockbackForce = 5f;

    void Update()
    {
        Death();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sword"))
        {
            enemyHealth -= swordDamage;
        }
    }

    void Death()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}