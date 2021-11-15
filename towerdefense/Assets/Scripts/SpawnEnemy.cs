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
    bool roundDone = false;
    bool enemiesHaveSpawned = true;
    bool timeForNewRound = false;
    Coroutine ws;


    void Start()
    {
       // ws = StartCoroutine(WaveStarter());
        //difficulty = EnemyParams.enemyParamsInstance.difficulty;
        spawnPoints[0] = GameObject.Find("Spawn");
        spawnPoints[1] = GameObject.Find("Spawn 2");
        spawnPoints[2] = GameObject.Find("Spawn 3");
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && enemiesHaveSpawned)
        {
            timeForNewRound = true;
        }


        if (roundDone && enemiesHaveSpawned)
        {
            StartGame();

        }          
           
               
                   
    }
    void StartGame()
    {
        StartCoroutine(SpawnWave());
    }

    void NextRound()
    {
        level += 1;
        difficulty = difficulty + 0.25f;
        Enemy3Params.enemy3ParamsInstance.difficulty = difficulty;
        StartGame();
    }

    IEnumerator WaveStarter()
    {
        for (float i = timeBetweenWaves; i > 0; i--)
        {
            Debug.Log("next wave in: "+i);
            if (timeForNewRound)
            {
                NextRound();
                timeForNewRound = false;
                i = 0;
                StopCoroutine(ws);
            }
            yield return new WaitForSeconds(1.0f);
        }
        NextRound();
        


    }



    IEnumerator SpawnWave()
    {
        roundDone = false;

        enemiesPerLevel = enemiesPerLevel + level * 1;
        Debug.Log("enemies: " +enemiesPerLevel);
        Debug.Log("level: "+level);
        Debug.Log("difficulty: " + difficulty);
        enemiesHaveSpawned = false;
        for (int i = 0; i < enemiesPerLevel; i++)
        {

            SpawnSingleEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        enemiesHaveSpawned = true;
        ws = StartCoroutine(WaveStarter());


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
