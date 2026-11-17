using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject player;
    public GameObject gameUI;
    public GameObject gameOverUI;
    public GameObject tryHaderUI;
    private bool isGameOver = false;

    void Update()
    {
        DamagedPlayer();
        GameEnd();
    }

    private void DamagedPlayer()
    {
        if (isGameOver) return;

        // show gameUI whenever the player is below full health
        gameUI.SetActive(playerHealth.health < 100);
    }

    void GameEnd()
    {
        if (playerHealth.health <= 0 && isGameOver == false)
        {
            isGameOver = true;
            StartCoroutine(BeforeEnd());
        }
    }

    IEnumerator BeforeEnd()
    {
        playerHealth.healthText.text = "Health: 0";
        player.SetActive(false);
        gameUI.SetActive(false);
        tryHaderUI.SetActive(true);
        yield return new WaitForSeconds(3f);
        tryHaderUI.SetActive(false);
        gameOverUI.SetActive(true);
    }
}