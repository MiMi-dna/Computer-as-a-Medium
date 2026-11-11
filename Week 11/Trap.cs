using UnityEngine;

public class Trap : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    public Knockack knockback;
    public float knockbackForce;
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
        if (other.CompareTag("Player"))
        {
            playerHealth.health -= 10;

            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                Vector2 difference = (rb.transform.position - other.transform.position).normalized;
                rb.AddForce(difference * knockbackForce, ForceMode2D.Impulse);knockback.ApplyKnockback((playerMovement.transform.position - transform.position).normalized);
            }
            
        }
    }
}

