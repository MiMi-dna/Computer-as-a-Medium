using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public float enemyHealth = 10f;
    public float swordDamage = 10f;
    public float knockbackForce = 5f;
    public TMP_Text enemyHealthText;
    Bullet bullet;
    public Knockback knockback;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyHealthText.text = "Enemy Health: " + enemyHealth;    
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealthText.text = "Enemy Health: " + enemyHealth;    
        Death();
    }

    void Death()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Bullet"))
    //     {
    //         Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            
    //         if (rb != null)
    //         {
    //             rb.bodyType = RigidbodyType2D.Dynamic;
    //             Vector2 difference = (rb.transform.position - other.transform.position).normalized;
    //             rb.AddForce(difference * knockbackForce, ForceMode2D.Impulse);knockback.ApplyKnockback((bullet.speed * transform.position - transform.position).normalized);
    //         }
    //     }
    // }

}
