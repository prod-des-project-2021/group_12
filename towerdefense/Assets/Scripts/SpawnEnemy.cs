using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public static SpawnEnemy spawnEnemyInstance;
    // Start is called before the first frame update
    private GameObject[] spawnPoints = new GameObject[3];

    private GameObject spawnPos;

    public GameObject[] spawnee = new GameObject[3];
    public float maxTime = 2f;
    public float minTime = 0.2f;


    private float time;
    int vuoro = 0;
    private float spawnTime;

    float timer = 0f;

    private float timeBetweenWaves = 10.0f;
    [HideInInspector] public float difficulty = 1.0f;
    public int level = 1;
    private int enemiesPerLevel = 5;
    bool roundRunning = false;
    bool enemiesHaveSpawned = false;



    void Start()
    {
        StartRound();
        //difficulty = EnemyParams.enemyParamsInstance.difficulty;
        spawnPoints[0] = GameObject.Find("Spawn");
        spawnPoints[1] = GameObject.Find("Spawn 2");
        spawnPoints[2] = GameObject.Find("Spawn 3");

    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetKeyDown("space") && enemiesHaveSpawned)
        {
            NextRound();
        }

        if (roundRunning)
        {
            roundRunning = false;
            StartCoroutine(SpawnWave());
        }          
           
               
                   
    }

    void StartRound()
    {
        roundRunning = true;
        
    }

    void NextRound()
    {
        StartRound();
        level += 1;
        difficulty = difficulty + 0.25f;
        Enemy3Params.enemy3ParamsInstance.difficulty = difficulty;
    }

    IEnumerator SpawnWave()
    {
        
        enemiesPerLevel = enemiesPerLevel + level * 1;
        Debug.Log("enemies: " +enemiesPerLevel);
        Debug.Log("level: "+level);
        Debug.Log("difficulty: " + difficulty);
        enemiesHaveSpawned = false;
        for (int i = 0; i < enemiesPerLevel; i++)
        {

            SpawnSingleEnemy();
            yield return new WaitForSeconds(1.0f);

        }
        enemiesHaveSpawned = true;
        yield return new WaitForSeconds(timeBetweenWaves);
                
        roundRunning = false;
        NextRound();
        
    }

    void SpawnSingleEnemy()
    {
        
        int randSpawn = Random.Range(0, 3);
        spawnPos = spawnPoints[randSpawn];

        timer = 0;
        spawnEnemyInstance = this;
        Instantiate(spawnee[vuoro], spawnPos.transform.position, spawnPos.transform.rotation);
        if (vuoro == 0) vuoro++;
        else if (vuoro == 1) vuoro++;
        else if (vuoro == 2) vuoro = 0;


    }

    
}
