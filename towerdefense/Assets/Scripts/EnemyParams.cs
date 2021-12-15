using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParams : MonoBehaviour
{
    
    public float health;
    [HideInInspector] public float speed;
    public float startHealth;
    public float startSpeed;
    public float maxSpeed;
    public static EnemyParams enemyParamsInstance;
    public static EnemyParams enemyHitInstance;

    void Start()
    {
        enemyParamsInstance = this;
        health = startHealth * GameEngine.gameInstance.difficulty;
        startHealth = startHealth * GameEngine.gameInstance.difficulty;
        if (startSpeed * GameEngine.gameInstance.difficulty < maxSpeed)
        {
            speed = startSpeed * GameEngine.gameInstance.difficulty;
        }
        else speed = maxSpeed;
    }

    public void EnemyNewInstance()
    {
        enemyHitInstance =this;
    }

}
