using UnityEngine;
using System.Collections;
using TMPro;

public class Enemy : MonoBehaviour
{
    public float enemyHealthMax = 20f;
    public float enemyHealth = 20f;
    public float enemyHealthMin = 0f;
    public float swordDamage = 10f;
    public float knockbackForce = 5f;
    public TMP_Text enemyHealthText;
    public Knockback knockback;
    private int damageToPlayer = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    // Handle collisions
    private void OnTriggerEnter2D(Collider2D other)
    {
        //checks if the other object has the tag "Sword", does damage to enemy and applies knockback
        if (other.CompareTag("Sword"))
        {
            if (knockback != null)
            {
                Vector2 direction = (other.transform.position - transform.position).normalized;
                knockback.ApplyKnockback(direction);
            }
            enemyHealth -= swordDamage;

            if(enemyHealthText != null) //this is needed to avoid null references for instanced enemies w/out health text assigned
            {
                enemyHealthText.text = "Enemy Health: " + enemyHealth;
            }
        }

        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            //checks if the other object has the tag "Player", does damage to player and applies knockback
            if (playerHealth != null)
            {
                playerHealth.health -= damageToPlayer;
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

    void Death()
    {
        if (enemyHealth <= enemyHealthMin)
        {
            if (enemyHealthText != null) //this is needed to avoid null references for instanced enemies w/out health text assigned
            {
                enemyHealthText.text = "Enemy Health: " + enemyHealthMin;
            }
            GameObject.Find("GameManager").GetComponent<GameManager>().enemyHealthUI.SetActive(false);
            Destroy(gameObject);
        }
    }
}
