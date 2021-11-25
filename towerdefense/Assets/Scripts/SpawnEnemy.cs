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


    int vuoro = 0;
    int bossTurn = 0;
    private float spawnTime;


    private int enemiesPerLevel = 5;
    bool roundDone = false;
    bool enemiesHaveSpawned = true;
    bool timeForNewRound = false;
    Coroutine ws, ld;

    void Start()
    {
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
        GameEngine.gameInstance.IncreaseDifficultyAndLevel();
        StartGame();
    }

    IEnumerator WaveStarter()
    {
        for (float i = GameEngine.gameInstance.timeBetweenWaves; i > 0; i--)
        {
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
        enemiesPerLevel = enemiesPerLevel + GameEngine.gameInstance.level * 1;
        
        Debug.Log("enemies: " +enemiesPerLevel);
        Debug.Log("level: "+ GameEngine.gameInstance.level);
        Debug.Log("difficulty: " + GameEngine.gameInstance.difficulty);
        
        enemiesHaveSpawned = false;
        if(GameEngine.gameInstance.level % 10 == 0)
        {
            float normalDifficulty = GameEngine.gameInstance.difficulty;
            GameEngine.gameInstance.difficulty = normalDifficulty * GameEngine.gameInstance.bossWaveDifficulty;
            for (int i = 0; i < enemiesPerLevel; i++)
            {
                SpawnSingleEnemy(bossTurn);
                yield return new WaitForSeconds(GameEngine.gameInstance.timeBetweenEnemies);
            }
            GameEngine.gameInstance.difficulty = normalDifficulty;
            if (bossTurn == 0) bossTurn++;
            else if (bossTurn == 1) bossTurn++;
            else if (bossTurn == 2) bossTurn = 0;
            
        }
        else
        {
            for (int i = 0; i < enemiesPerLevel; i++)
            {

                SpawnSingleEnemy(vuoro);
                if (vuoro == 0) vuoro++;
                else if (vuoro == 1) vuoro++;
                else if (vuoro == 2) vuoro = 0;
                yield return new WaitForSeconds(GameEngine.gameInstance.timeBetweenEnemies);

            }
        }
        
        enemiesHaveSpawned = true;
        ws = StartCoroutine(WaveStarter());

    }



    void SpawnSingleEnemy(int enemyType)
    {
        spawnPos = spawnPoints[Random.Range(0, 3)];
        spawnEnemyInstance = this;
        Instantiate(spawnee[enemyType], spawnPos.transform.position, spawnPos.transform.rotation);
        

        
        



    }

}
