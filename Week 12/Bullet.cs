using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float destroyTime = 3f;
    public float bulletDamage = 5f;
    public Rigidbody2D rb;
    public Knockback knockback;
    public float knockbackForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.up * speed;
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.enemyHealth -= bulletDamage;
                if (enemy.enemyHealthText != null){
                    if (enemy.enemyHealth < enemy.enemyHealthMin)
                    {
                        enemy.enemyHealth = enemy.enemyHealthMin;
                    }
                    enemy.enemyHealthText.text = "Enemy Health: " + enemy.enemyHealth;
                }
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
