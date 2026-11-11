using UnityEngine;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject player;
    public GameObject gameUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DamagedPlayer();
    }

    private void DamagedPlayer()
    {
    if (playerHealth.healthText.text == "Health: 90")
    {
        gameUI.SetActive(true);
    }
    else if (playerHealth.healthText.text == "Health: 100")
        {
            gameUI.SetActive(false);
        }

    if (playerHealth.healthText.text == "Health: 0")
        {
            PlayerDied();
        }
    }

    private void PlayerDied()
    {
        gameUI.SetActive(true);
        player.SetActive(false);
    }
}
