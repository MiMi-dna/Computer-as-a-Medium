using UnityEngine;
using System.Collections;

public class Knockback : MonoBehaviour
{
    public float knockbackForce = 5f;
    public float knockbackDuration = 0.2f;
    public bool isKnockedBack = false;

    public void ApplyKnockback(Vector2 direction)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            StartCoroutine(ApplyKnockbackCoroutine(rb, direction));
        }
    }

    private IEnumerator ApplyKnockbackCoroutine(Rigidbody2D rb, Vector2 direction)
    {
        isKnockedBack = true;
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(knockbackDuration);
        rb.linearVelocity = Vector2.zero;
        isKnockedBack = false;
    }
}