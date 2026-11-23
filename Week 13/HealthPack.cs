using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField]int healAmount = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null && player.currentHealth < player.maxHealth)
        {
            player.currentHealth = Mathf.Min(player.currentHealth + healAmount, player.maxHealth); //adjusted to pull directly from PlayerHealth file
            player.isHealed = true;
            player.UpdatePlayerHealth();
            Destroy(gameObject);
        }
    }
}

//our files are not yet refined, but ideally, each file will maint their own instuctions, e.g. PlayerHealth, should full be responsible
//for manage PlayerHealth, whereas Health Pack should only be responsible for manage "Health Pack" instructions
//this is easier for maintenance because you can update one file and it will trickle to all files that reference it