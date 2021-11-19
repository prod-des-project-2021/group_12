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
    private float spawnTime;


    private int enemiesPerLevel = 5;
    bool roundDone = false;
    bool enemiesHaveSpawned = true;
    bool timeForNewRound = false;
    Coroutine ws, ld;


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
        GameEngine.gameInstance.IncreaseDifficultyAndLevel();
        StartGame();
    }

    IEnumerator WaveStarter()
    {
        for (float i = GameEngine.gameInstance.timeBetweenWaves; i > 0; i--)
        {
            //Debug.Log("next wave in: "+i);
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
<<<<<<< HEAD

        enemiesPerLevel = enemiesPerLevel + level * 1;
        //Debug.Log("enemies: " +enemiesPerLevel);
        //Debug.Log("level: "+level);
        //Debug.Log("difficulty: " + difficulty);
=======
        //ld = StartCoroutine(LevelDuration());
        enemiesPerLevel = enemiesPerLevel + GameEngine.gameInstance.level * 1;
        Debug.Log("enemies: " +enemiesPerLevel);
        Debug.Log("level: "+ GameEngine.gameInstance.level);
        Debug.Log("difficulty: " + GameEngine.gameInstance.difficulty);
>>>>>>> 78c7e80a818625f056e4c58e4528f9d3f8f4d054
        enemiesHaveSpawned = false;
        for (int i = 0; i < enemiesPerLevel; i++)
        {

            SpawnSingleEnemy();
            yield return new WaitForSeconds(GameEngine.gameInstance.timeBetweenEnemies);
        }
        enemiesHaveSpawned = true;
       // StopCoroutine(ld);
        ws = StartCoroutine(WaveStarter());


    }

    /*IEnumerator LevelDuration()
    {
        float waveDuration = 0;
        while(enemiesHaveSpawned == false)
        {          
            yield return new WaitForSeconds(0.1f);
            waveDuration += 0.1f;
            
        }
        float durationScore = waveDuration * 10;
}*/

    void SpawnSingleEnemy()
    {
        int randSpawn = Random.Range(0, 3);
        spawnPos = spawnPoints[randSpawn];
        spawnEnemyInstance = this;
        Instantiate(spawnee[vuoro], spawnPos.transform.position, spawnPos.transform.rotation);
        if (vuoro == 0) vuoro++;
        else if (vuoro == 1) vuoro++;
        else if (vuoro == 2) vuoro = 0;
        



    }

}
