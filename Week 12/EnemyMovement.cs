using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    private float speedX = 0f;
    private float speedY = 0f;
    public Rigidbody2D rb;
    Knockback knockback;

    void Start()
    {
        knockback = GetComponent<Knockback>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (knockback != null && knockback.isKnockedBack) return;

        rb.linearVelocity = new Vector2(speedX, speedY);
    }
}