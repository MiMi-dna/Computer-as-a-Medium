using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] TMP_Text enemyHealthText;
    public float enemyHealthMax = 20f;
    public float enemyCurrentHealth = 20f;
    public float enemyHealthMin = 0f;
    public float swordDamage = 10f;
    Bullet bullet;
    public float knockbackForce = 5f;
    public Knockback knockback;
    private int damageToPlayer = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(enemyHealthText != null) //prevent null exception from Spawned enemies and receives UI text from "Boss"
        {
        enemyHealthText.text = "Boss Health: " + enemyCurrentHealth;
        }
    }
    // Handle collisions
    private void OnTriggerEnter2D(Collider2D other)
    {
        //collision w/ sword:
        if (other.CompareTag("Sword"))
        {
            if (knockback != null)
            {
                Vector2 direction = (other.transform.position - transform.position).normalized;
                knockback.ApplyKnockback(direction);
            }
            enemyCurrentHealth -= swordDamage;
        }

        //collision w/ bullet
        else if (other.CompareTag("Bullet"))
        {
            bullet = other.GetComponent<Bullet>();
            if (bullet != null)
            {
                enemyCurrentHealth -= bullet.bulletDamage;
            }
        }

        if(enemyHealthText != null)
        {
            if(enemyCurrentHealth > enemyHealthMin)
            {
                enemyHealthText.text = "Health: " + enemyCurrentHealth;
            }
            else if (enemyCurrentHealth <= enemyHealthMin)
            {
                enemyHealthText.text = "Health: " + enemyHealthMin;
                GameObject.Find("GameManager").GetComponent<GameManager>().BossUI();
                Death();
            }
        }

        //collision w/ player
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            //checks if the other object has the tag "Player", does damage to player and applies knockback
            if (playerHealth != null)
            {
                playerHealth.currentHealth -= damageToPlayer;
                playerHealth.isDamaged = true;
                playerHealth.UpdatePlayerHealth();
                
            }

            Knockback knockback = other.GetComponent<Knockback>();

            if (knockback != null)
            {
                Vector2 direction = (other.transform.position - transform.position).normalized;
                knockback.ApplyKnockback(direction);
            }
        }
    }

    void Death()
        {
            Destroy(gameObject);
        }
}

