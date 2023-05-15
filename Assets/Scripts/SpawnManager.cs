using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab; 
    [SerializeField] 
    GameObject[] powerUps;
    [SerializeField]
    GameObject spawnPos;
    [SerializeField]
    GameObject enemyContainer;
    [SerializeField]
    Player player;

    private IEnumerator spawnCoroutine;

    private float _spawnTime;

    bool stopSpawning = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

        _spawnTime = 1.5f;
        spawnCoroutine = SpawnEnemies(_spawnTime);

        StartCoroutine(spawnCoroutine);
        StartCoroutine(SpawnPowerUps(Random.Range(5f, 10f)));
    }

    // Update is called once per frame
    void Update()
    {        
        if (player.score >= 50)  
            _spawnTime = 1.0f;
        if (player.score >= 100)
            _spawnTime = 0.5f;
        if (player.score >= 150)
            _spawnTime = 0.1f;
        if (player.score >= 200) 
            _spawnTime = 0.01f;

        Debug.Log(_spawnTime);
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

    public void OnPlayerDeath()
    {
        stopSpawning = true;
    }
}
