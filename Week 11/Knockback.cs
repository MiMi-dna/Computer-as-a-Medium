using UnityEngine;
using System.Collections;
public class Knockack : MonoBehaviour
{
    public float knockbackForce;
    public float knockbackDuration;
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
        if (other.gameObject.CompareTag("Player"))
        {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
            {
            rb.bodyType = RigidbodyType2D.Dynamic;
            Vector2 difference = (rb.transform.position - other.transform.position).normalized;
            rb.AddForce(difference * knockbackForce, ForceMode2D.Impulse);
            }
        }
    }

    public void ApplyKnockback(Vector2 direction){
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            StartCoroutine(ApplyKnockbackCoroutine(rb, direction));
        }
    }

    private IEnumerator ApplyKnockbackCoroutine(Rigidbody2D rb, Vector2 direction)
    {
        if (rb == null)
            yield break;

        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(knockbackDuration);
        rb.linearVelocity = Vector2.zero;
    }

}
