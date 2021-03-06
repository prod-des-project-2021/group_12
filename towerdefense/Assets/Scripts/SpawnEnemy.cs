using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{

    DamageSystem dsInstance;
    public static SpawnEnemy spawnEnemyInstance;
    // Start is called before the first frame update
    private GameObject[] spawnPoints = new GameObject[3];

    private GameObject spawnPos;

    public GameObject[] spawnee = new GameObject[3];

    private Button startGameButton;
    private GameObject findShopMenu;
     [HideInInspector] public bool startGameButtonClicked = false;

    public bool gameHasStarted = false;
    int vuoro = 0;
    int bossTurn = 0;
    private bool enemiesDead;
    private bool gameOver = false;

    GameObject[] Enemies;
    private int enemiesPerLevel = 5;
    
    bool enemiesHaveSpawned = false;
    bool timeForNewRound = false;
    Coroutine ws, ld;
    void Start()
    {
        
        spawnEnemyInstance = this;
        spawnPoints[0] = GameObject.Find("Spawn 1");
        spawnPoints[1] = GameObject.Find("Spawn 2");
        spawnPoints[2] = GameObject.Find("Spawn 3");
        
    }

 
    void Update()
    {
         foreach (GameObject enemy in spawnee){
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            startGameButtonClicked = true;
           
               
            enemy.transform.GetChild(0).GetComponent<Canvas>().enabled  = false;

            }else {
                 enemy.transform.GetChild(0).GetComponent<Canvas>().enabled  = true;

            }
        }
           
        


        if (startGameButtonClicked && !enemiesHaveSpawned)
        {

             if (!gameHasStarted)
            {
                StartGame();
                gameHasStarted = true;
                GameEngine.gameInstance.StartGameTimer();
                 startGameButtonClicked = false;
            }
            else
            {
                timeForNewRound = true;
            }
           
            
        }
        if (GameObject.FindGameObjectsWithTag("mob") == null || GameObject.FindGameObjectsWithTag("mob").Length == 0)
        {
            enemiesDead = true;
        }
        else
        {
            enemiesDead = false;
        }
        if(enemiesDead && gameOver)
        {
            GameEngine.gameInstance.gameWon = true;
            GameEngine.gameInstance.StopGameTimer();
            
        }

    }
    void StartGame()
    {
        StartCoroutine(SpawnWave());
    }

    void NextRound()
    {
        
        if(GameEngine.gameInstance.maxLevels > GameEngine.gameInstance.level)
        {
            GameEngine.gameInstance.IncreaseDifficultyAndLevel();
            StartGame();
        }
        else
        {
            gameOver = true;             
        }
        
    }

    IEnumerator WaveStarter()
    {
        for (float i = GameEngine.gameInstance.timeBetweenWaves; i > 0; i--)
        {

           // Debug.Log("next wave in: "+i);

           

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
        enemiesPerLevel = enemiesPerLevel + GameEngine.gameInstance.level * 1;
        
       // Debug.Log("enemies: " +enemiesPerLevel);
       // Debug.Log("level: "+ GameEngine.gameInstance.level);
       // Debug.Log("difficulty: " + GameEngine.gameInstance.difficulty);
        
        enemiesHaveSpawned = true;
         if (GameEngine.gameInstance.level % 10 == 0)
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
                else if (vuoro == 2) vuoro++;
                else if (vuoro == 3) vuoro = 0;
                yield return new WaitForSeconds(GameEngine.gameInstance.timeBetweenEnemies);

            }
        }
        //enemiesHaveSpawned = true;
        ws = StartCoroutine(WaveStarter());


    }
    

    void SpawnSingleEnemy(int enemyType)
    {
        foreach(GameObject enemy in spawnee){        
         
         if(enemy.name.Contains("Enemy 4")){
             enemy.GetComponent<MeshRenderer>().enabled = false;
            enemy.transform.GetChild(0).GetComponent<Canvas>().enabled = false;
          
         }
        }  
        spawnPos = spawnPoints[Random.Range(0, 3)];
        Instantiate(spawnee[enemyType], spawnPos.transform.position, spawnPos.transform.rotation);

    }

}

