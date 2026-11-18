using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float destroyTime = 3f;
    public float bulletDamage = 5f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.linearVelocity = transform.up * speed;
        Destroy(gameObject, destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy hitEnemy = other.GetComponent<Enemy>();

            if (hitEnemy != null)
            {
                hitEnemy.enemyHealth -= bulletDamage;
            }

            Knockback hitKnockback = other.GetComponent<Knockback>();

            if (hitKnockback != null)
            {
                Vector2 direction = (other.transform.position - transform.position).normalized;
                hitKnockback.ApplyKnockback(direction);
            }

            Destroy(gameObject);
        }
    }
}
