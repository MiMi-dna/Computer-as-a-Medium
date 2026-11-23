using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))] //whenever this script is attached to a game object, it auto add the required components that 
//it depends on to prevent errors and simply setup, must be added before the class

public class Knockback : MonoBehaviour
{
    public float knockbackForce = 5f;
    public float knockbackDuration = 0.2f;
    public bool isKnockedBack = false;
    Rigidbody2D rb;

    public void ApplyKnockback(Vector2 direction)
    {
        rb = GetComponent<Rigidbody2D>();
        
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
