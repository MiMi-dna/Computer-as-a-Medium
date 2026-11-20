using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static WaitForSeconds waitForSeconds3 = new(3f); //cached object to avoid creating new WaitForSeconds object every time the coroutine is called
    private static WaitForSeconds waitForSeconds1 = new(1f);

    public PlayerHealth playerHealth;
    public Enemy enemy;

    //UI Game Objects
    public GameObject playerHealthUI;
    public GameObject playerManaUI;
    public GameObject enemyHealthUI;

    public GameObject gameUI; //ouch text
    public GameObject gameOverUI;
    public GameObject tryHaderUI;

    //Switch Scene UI Elements
    public SwitchScene switchSceneScript;
    public bool isGameOver = false;


    public void BossUI()
    {
        enemyHealthUI.SetActive(false);
    }

    //sets ouch text to active when player is damaged, then starts a coroutine to wait 1 second before setting it to inactive again
    public void DamagedPlayer()
    {
        if(playerHealth != null)
        {
            if(playerHealth.isDamaged == true)
            {
            gameUI.SetActive(true);
            StartCoroutine(UITransition());
            }
        }
        else return;
    }

    IEnumerator UITransition()
        {
            yield return waitForSeconds1;
            gameUI.SetActive(false);
            playerHealth.isDamaged = false;
            if(playerHealth.currentHealth <= 0)
            {
                GameEnd();
            }
        }

    void GameEnd()
    {
        if (playerHealth.currentHealth <= 0 && isGameOver == false)
        {
            isGameOver = true;
            StartCoroutine(BeforeEnd());
        }
    }
    
    IEnumerator BeforeEnd()
    {
        playerHealthUI.SetActive(false);
        playerManaUI.SetActive(false);

        gameUI.SetActive(false);
        tryHaderUI.SetActive(true);
        yield return waitForSeconds3; //cached wait for seconds object to improve performance on recall
        tryHaderUI.SetActive(false);
        gameOverUI.SetActive(true);
        yield return waitForSeconds3; //cached wait for seconds object to improve performance on recall
        switchSceneScript.LoseScene(isGameOver);//access the switch scene file and calls the SwitchScenes method > Lose Scene since isGameOver is true
    }
}