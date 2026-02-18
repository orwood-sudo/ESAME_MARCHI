using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Config")]
    public List<GameObject> enemiesPrefab = new List<GameObject>();
    public Transform[] spawnPoints;
    public float spawningInterval = 2.0f;
    public int spawnOccurrenceLevelUp = 10;
    public float difficultyMultiplier = 0.9f;

    private int lvlUpCounter;
    private float timer;

    private void Awake()
    {
        lvlUpCounter = spawnOccurrenceLevelUp;
    }
    
    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnEnemy();
            timer = spawningInterval;
            
            lvlUpCounter--;
            if (lvlUpCounter <= 0)
            {
                lvlUpCounter = spawnOccurrenceLevelUp;
                spawningInterval = spawningInterval * difficultyMultiplier;
            }
        }
    }

    private void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];   
        Instantiate(enemiesPrefab[GetEnemyType()], spawnPoint.position, Quaternion.identity, transform);
    }

    private int GetEnemyType()
    {
        int randomEnemyType = Random.Range(0, 10);
        if (randomEnemyType == 8) return 1;
        else if (randomEnemyType == 9) return 2;
        return 0;
    }
}



