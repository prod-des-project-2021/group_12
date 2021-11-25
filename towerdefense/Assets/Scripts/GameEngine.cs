using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public int playerHealth = 100;
    public int money = 100;
    public float score = 0;
    [HideInInspector] public float difficulty = 1.0f;
    public int level = 1;
    public float timeBetweenWaves = 10.0f;
    public float timeBetweenEnemies = 0.5f;
    public float bossWaveDifficulty = 2.0f;

    public static GameEngine gameInstance;
    // Start is called before the first frame update
    void Start()
    {
        gameInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(int damage)
    {
        playerHealth -= damage;;
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
}
