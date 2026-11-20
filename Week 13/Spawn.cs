using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Spawn : MonoBehaviour
{
    private static readonly WaitForSeconds waitForSeconds3 = new(3f); //cached object to avoid creating new WaitForSeconds object every time the coroutine is called

    public GameObject enemyPrefab;
    public GameObject healthPackPrefab;
    public GameObject manaPackPrefab;
    public float spawnRangeX;
    public float spawnRangeY;
    public bool isSpawningEnemy = true;
    [SerializeField]private bool isSpawningHealthPack = true;
    [SerializeField]private bool isSpawningManaPack = true;
    public GameObject enemySpawnStopper;

    /*why public, private, or serialize?
    public - allows the variable to be accessed and manipulated accross other files w/out setters or getters, easy to access and 
    manipulate, can be problematic if the value should not be altered or can cause runtime issues if there are conflicting variables 
    with the same name
    
    private - prevents vision of a variable in inspector in Unity and prevents access to the field from any other file w/out explicit
    setters and getters. This protects the variable from being manipulated in appropriately that could cause code to fail

    [SerializeField] - prevents access to the variable from other files w/out explicit setters and getts but is visible and manipulatable
    om the Unity Inspector. Provides some protection like private while allowing some accessibility like public 
    */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemyNow());
        StartCoroutine(SpawnHealthPackNow());
        StartCoroutine(SpawnManaPackNow());
    }
    IEnumerator SpawnEnemyNow()
    {
        while(isSpawningEnemy == true)
        {
            SpawnEnemy();
            yield return waitForSeconds3;
        }
    }

    IEnumerator SpawnHealthPackNow()
    {
        while(isSpawningHealthPack == true)
        {
            SpawnHealthPack();
            yield return waitForSeconds3;
        }
    }
    IEnumerator SpawnManaPackNow()
    {
        while(isSpawningManaPack == true)
        {
            SpawnManaPack();
            yield return waitForSeconds3;
        }
    }

    private void SpawnEnemy()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX); //Unity's Random class does not require seeding, but can be seeded using Random.InitState
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);

        Vector3 spawnPosition = transform.position + new Vector3(randomX, randomY, 0f);

        Destroy(Instantiate(enemyPrefab, spawnPosition, Quaternion.identity), 5f);
    }

    private void SpawnHealthPack()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX); //Unity's Random class does not require seeding, but can be seeded using Random.InitState
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);

        Vector3 spawnPosition = transform.position + new Vector3(randomX, randomY, 0f);

        Destroy(Instantiate(healthPackPrefab, spawnPosition, Quaternion.identity), 5f);
    }
    private void SpawnManaPack()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX); //Unity's Random class does not require seeding, but can be seeded using Random.InitState
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);

        Vector3 spawnPosition = transform.position + new Vector3(randomX, randomY, 0f);

        Destroy(Instantiate(manaPackPrefab, spawnPosition, Quaternion.identity), 5f); //Quaternion.identity sets instantioated objects to "no rotaion" so it will spawn aligned wit the world axis in Unity
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isSpawningEnemy = false;
        }
    }
}
//A note about random numbers:
//since computationally, there's no "true" random sequence, normally you would need to "seed" or intialize it ensuring replicability,
//allow for troubleshooting, and give a genuine feel of "randomness" since it helps prevent the system from generating the same sequence
//repeatedly. A common way to seed a random number generator is to the system/computer clock to initiatlize the generator.
//if you seedf using a single value, it will product the exact same series of "random" nummbers each time, this can be beneficial
// for troubleshooting and can be re-seeded, if needed.
