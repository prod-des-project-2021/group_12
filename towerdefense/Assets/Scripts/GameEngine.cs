using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject playerUI;
    public GameObject endScreenUI;
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
    public bool gameWon = false;
    public bool gameLost = false;

    public int minigunPrice, missileLauncherPrice, tankPrice, sentryPrice, zapTowerPrice, buffTowerPrice;

    public Text currentHealth;
    public Text currentMoney;
    public Text currentScore;

    public Text Map1Score, Map2Score;
    public Text Map1Level, Map2Level;
    public Text pauseGameText;
	private GameObject findShopMenu;

    SaveData data;

    public static GameEngine gameInstance;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1f;
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
        if (Map1Score != null) Map2Score.text = map1HighScore.ToString();
        if (Map1Level != null) Map2Level.text = map1HighLevel.ToString();
        if (Map2Score != null) Map1Score.text = sampleHighScore.ToString();
        if (Map2Level != null) Map1Level.text = sampleHighLevel.ToString();
        gameInstance = this;
    }

    private void Start()
    {

        findShopMenu = GameObject.Find("Shopmenu");

        if (findShopMenu != null)
        {
            findShopMenu.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(doubleSpeedButtonClicked);
            findShopMenu.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(StartGameButtonClicked);
        }
        
    }

	private void StartGameButtonClicked()
	{
		if(findShopMenu.transform.GetChild(1).GetComponentInChildren<Text>().text == "Start game")
		 {
			 Time.timeScale = 1f;    
			SpawnEnemy.spawnEnemyInstance.startGameButtonClicked = true;
			 findShopMenu.transform.GetChild(1).GetComponentInChildren<Text>().text = "Pause";        
		 }else
		 {
			
			 Time.timeScale = 0f;
			 findShopMenu.transform.GetChild(1).GetComponentInChildren<Text>().text = "Start game";
		 }
	   
	}
    private void doubleSpeedButtonClicked()
    {
        if(findShopMenu.transform.GetChild(2).GetComponentInChildren<Text>().text == "2x speed")
        {
            if(findShopMenu.transform.GetChild(1).GetComponentInChildren<Text>().text == "Pause")
            {
        Time.timeScale = 2f;
        findShopMenu.transform.GetChild(2).GetComponentInChildren<Text>().text = "Normal speed";
            }       
        }
        else 
        {
            if(findShopMenu.transform.GetChild(1).GetComponentInChildren<Text>().text == "Pause"){
        Time.timeScale = 1f;
        findShopMenu.transform.GetChild(2).GetComponentInChildren<Text>().text = "2x speed";
            }
        }
    }
    public void StartGameTimer()
    {
        gameRunning = true;
    }

    public void StopGameTimer()
    {
        if (gameRunning)
        {
            if (gameWon) {
                score = score * (3600 / gameTime);
            }
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused == true)
            {
                if (endScreenUI.activeSelf) endScreenUI.SetActive(false);
                else if (gameWon || gameLost) endScreenUI.SetActive(true);
                else Resume();         
            }
            else Pause();

        }

        if (currentHealth != null) currentHealth.text = playerHealth.ToString();
        if (currentMoney != null) currentMoney.text = money.ToString();
        if (currentScore != null) currentScore.text = score.ToString();
        if (score > map1HighScore && SceneManager.GetActiveScene().name == "FirstMap")
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

        if (playerHealth <= 0 && gameRunning) GameLost();
        if (gameWon && gameRunning) GameWon();


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

    }

    public void IncreaseScore(float amount)
    {
        score += amount* difficulty;
        
    }

    public void Resume()
    {
        findShopMenu.SetActive(true);
        pauseMenuUI.SetActive(false);
        playerUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LookAround()
    {
        Debug.Log("backtomap");
        endScreenUI.SetActive(false);
    }

    public void Menu()
    {
        findShopMenu.SetActive(false);
        pauseMenuUI.SetActive(false);
        playerUI.SetActive(false);
        endScreenUI.SetActive(false);
    }
    void Pause()
    {
        findShopMenu.SetActive(false);
        pauseMenuUI.SetActive(true);
        playerUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    public void QuitGame()
    {
        Debug.Log("Quitting..");
        Application.Quit();
    }

    public void GameWon()
    {
        gameRunning = false;
        findShopMenu.SetActive(false);
        endScreenUI.SetActive(true);
        endScreenUI.transform.Find("EndMenu").transform.Find("Results").transform.Find("WinTXT").gameObject.SetActive(true);
        endScreenUI.transform.Find("EndMenu").transform.Find("Results").transform.Find("Score").transform.Find("ScoreTXT").gameObject.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        endScreenUI.transform.Find("EndMenu").transform.Find("Results").transform.Find("Level").transform.Find("LevelTXT").gameObject.GetComponent<UnityEngine.UI.Text>().text = level.ToString();
        playerUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void GameLost()
    {
        gameRunning = false;
        gameLost = true;
        StopGameTimer();
        findShopMenu.SetActive(false);
        endScreenUI.SetActive(true);
        endScreenUI.transform.Find("EndMenu").transform.Find("Results").transform.Find("LoseTXT").gameObject.SetActive(true);
        endScreenUI.transform.Find("EndMenu").transform.Find("Results").transform.Find("Score").transform.Find("ScoreTXT").gameObject.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        endScreenUI.transform.Find("EndMenu").transform.Find("Results").transform.Find("Level").transform.Find("LevelTXT").gameObject.GetComponent<UnityEngine.UI.Text>().text = level.ToString();
        playerUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
