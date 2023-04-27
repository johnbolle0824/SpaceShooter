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

    bool stopSpawning = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies(1.5f));
        StartCoroutine(SpawnPowerUps(Random.Range(5f, 10f)));
    }

    // Update is called once per frame
    void Update()
    {
    
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
