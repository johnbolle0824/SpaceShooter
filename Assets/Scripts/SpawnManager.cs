using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab, bigAsteroidPrefab, smallAsteroidPrefab; 
    [SerializeField] 
    GameObject[] powerUps;
    [SerializeField]
    GameObject spawnPos;
    [SerializeField]
    GameObject enemyContainer;
    [SerializeField]
    Player player;

    public float _spawnTime;
    private float _currentSpawnTime;

    private int _playerScore;

    bool stopSpawning = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemies(3f));
        StartCoroutine(SpawnPowerUps(Random.Range(5f, 10f)));
        StartCoroutine(SpawnSmallAsteroid(8f));
        StartCoroutine(SpawnBigAsteroid(10f));
    }

    IEnumerator SpawnEnemies(float spawnTime)
    {
        while (stopSpawning == false)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(11.5f, Random.Range(-5, 5), 0), Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(spawnTime);
        }
    }

    IEnumerator SpawnPowerUps(float spawnTime)
    {
        while(stopSpawning == false)
        {
            Vector3 spawnPos = new Vector3(11.5f, Random.Range(-5, 5), 0);
            int randomPowerUp= Random.Range(0, 3);
            Instantiate(powerUps[randomPowerUp],spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public IEnumerator SpawnBigAsteroid(float spawnTime)
    {
        while (stopSpawning == false)
        {
            GameObject newBigAsteroid = Instantiate(bigAsteroidPrefab, new Vector3(11.5f,
                Random.Range(-5, 5),0), Quaternion.identity);
            newBigAsteroid.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public IEnumerator SpawnSmallAsteroid(float spawnTime)
    {
        while (stopSpawning == false)
        {
            GameObject newSmallAsteroid = Instantiate(smallAsteroidPrefab,new Vector3(11.5f, 
                Random.Range(-5,5),0), Quaternion.identity);
            newSmallAsteroid.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void OnPlayerDeath()
    {
        stopSpawning = true;
    }    
}
