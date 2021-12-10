using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
    public int playerHealth = 100;
    public int money = 1000;
    public float score = 0;
    public float highScore = 0;
    [HideInInspector] public float difficulty = 1.0f;
    [HideInInspector] public float map1HighScore, sampleHighScore;
    [HideInInspector] public int map1HighLevel, sampleHighLevel;
    public int level = 1;
    public int maxLevels = 30;
    public float timeBetweenWaves = 10.0f;
    public float timeBetweenEnemies = 0.5f;
    public float bossWaveDifficulty = 2.0f;
    public float gameTime = 0f;
    private bool gameRunning = false;

    public int minigunPrice, missileLauncherPrice, tankPrice, sentryPrice, zapTowerPrice, buffTowerPrice;

    public Text currentHealth;
    public Text currentMoney;
    public Text currentScore;
    SaveData data;

    public static GameEngine gameInstance;
    // Start is called before the first frame update
    void Awake()
    {
        string path = Application.persistentDataPath + "/player.SaveData";

        if (System.IO.File.Exists(path))
        {
            LoadData();
        }
        else
        {
            SaveData();
            LoadData();
        }
        gameInstance = this;
    }

    private void Start()
    {
        
    }

    public void StartGameTimer()
    {
        gameRunning = true;
    }

    public void StopGameTimer()
    {
        if (gameRunning)
        {
            score = score * (3600 / gameTime);
        }
        gameRunning = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth != null) currentHealth.text = playerHealth.ToString();
        if(currentMoney != null) currentMoney.text = money.ToString();
        if(currentScore != null) currentScore.text = score.ToString();
        if(score > map1HighScore && SceneManager.GetActiveScene().name == "FirstMap")
        {
            SaveData();
            LoadData();
        }
        else if (score > sampleHighScore && SceneManager.GetActiveScene().name == "SampleScene")
        {
            SaveData();
            LoadData();
        }
        if (gameRunning)
        {
            gameTime += Time.deltaTime;
        }
        
    }

    public void DamagePlayer(int damage)
    {
        playerHealth -= damage;
        
    }

    public void SaveData()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadData()
    {
        data = SaveSystem.LoadData();
        map1HighScore = data.map1Score;
        map1HighLevel = data.map1Level;
        sampleHighScore = data.sampleScore;
        sampleHighLevel = data.sampleLevel;
        //Debug.Log("Map 1 HighScore: " + map1HighScore);
        //Debug.Log("Map 1 HighLevel: " + map1HighLevel);
        //Debug.Log("sample HighScore: " + sampleHighScore);
        //Debug.Log("sample HighLevel: " + sampleHighLevel);

        if (SceneManager.GetActiveScene().name == "FirstMap")
        {         
            highScore = map1HighScore;     
        }
        else if (SceneManager.GetActiveScene().name == "SampleScene")
        {          
            highScore = sampleHighScore;     
        }
        

    }

    public bool SpendMoney(int amount)
    {
        if(money >= amount)
        {
            money -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public void AddMoney(int amount)
    {
        money += amount;
    }

    public int GetMoney()
    {
        return money;
    }

    public void IncreaseDifficultyAndLevel()
    {
        
        level += 1;
        difficulty = (level * 0.25f) + 0.75f;
        /*LoadData();
        if (SceneManager.GetActiveScene().name == "FirstMap")
        {
            if(data.map1Score <= score)
            {
                SaveData();
            }
        }
        else if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            if (data.sampleScore <= score)
            {
                SaveData();
            }
        }*/
        
        
    }

    public void IncreaseScore(float amount)
    {
        score += amount* difficulty;
        
    }
}
