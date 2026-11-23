using UnityEngine;

public class ManaPack : MonoBehaviour
{
    [SerializeField]int restoreAmount = 50;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerMana player = other.GetComponent<PlayerMana>();

        if (player != null && player.currentMana < player.maxMana)
        {
            player.currentMana = Mathf.Min(player.currentMana + restoreAmount, player.maxMana); 
            player.isRestored = true;
            player.UpdatePlayerMana();
            Destroy(gameObject);
        }
    }
}

//our files are not yet refined, but ideally, each file will maint their own instuctions, e.g. PlayerHealth, should full be responsible
//for manage PlayerHealth, whereas Health Pack should only be responsible for manage "Health Pack" instructions
//this is easier for maintenance because you can update one file and it will trickle to all files that reference it