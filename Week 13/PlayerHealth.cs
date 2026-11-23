using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool isDamaged = false;
    public bool isHealed = false;
    public int currentHealth = 100;
    public int maxHealth = 100;
    public int minHealth = 0;
    [SerializeField] TMP_Text healthText;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthText.text = "Health: " + currentHealth;
    }

    public void UpdatePlayerHealth()
    {
        if (isDamaged == true)
        {
            if(currentHealth > minHealth)
            {
                healthText.text = "Health: " + currentHealth;
                GameObject.Find("GameManager").GetComponent<GameManager>().BossUI();
            }
            else if (currentHealth <= minHealth)
            {
                healthText.text = "Health: " + minHealth;
                Death();
            }
        }

        if(isHealed == true)
        {
            if(currentHealth >= maxHealth)
            {
                healthText.text = "Health: " + maxHealth;
            }
            else
            {
                healthText.text = "Health: " + currentHealth;
            }
            isHealed = false;
        }    
    }

    void Death()
    {
        Destroy(gameObject);
    }
}

