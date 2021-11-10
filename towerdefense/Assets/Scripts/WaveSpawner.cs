using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    private float timeBetweenWaves = 5.0f;
    public float difficulty = 1.0f;
    public int level = 1;
    public int enemiesPerLevel = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnWave()
    {
        for (int i = 0; i < enemiesPerLevel; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    void SpawnEnemy()
    {

    }
}
