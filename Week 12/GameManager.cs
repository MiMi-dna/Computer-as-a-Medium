using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static WaitForSeconds _waitForSeconds3 = new WaitForSeconds(3f); //cached object to avoid creating new WaitForSeconds object every time the coroutine is called
    private static WaitForSeconds _waitForSeconds1 = new WaitForSeconds(1f);

    public PlayerHealth playerHealth;
    public Enemy enemy;
    public GameObject player;
    public GameObject enemyHealthUI;

    public GameObject gameUI; //ouch text
    public GameObject gameOverUI;
    public GameObject tryHaderUI;

    public SwtichScene switchSceneScript;
    private bool isGameOver = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DamagedPlayer();
        GameEnd();
    }

    private void BossUI()
    {
        enemyHealthUI.SetActive(false);
        
    }

    //sets ouch text to active when player is damaged, then starts a coroutine to wait 1 second before setting it to inactive again
    private void DamagedPlayer()
    {
        if(playerHealth.isDamaged == true)
        {
            gameUI.SetActive(true);
            StartCoroutine(UITransition());
        }
    }
    IEnumerator UITransition()
        {
            yield return _waitForSeconds1;
            gameUI.SetActive(false);
            playerHealth.isDamaged = false;
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
        yield return _waitForSeconds3;
        tryHaderUI.SetActive(false);
        gameOverUI.SetActive(true);
    }
}