using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParams : MonoBehaviour
{
    DamageSystem ds;
    
    [HideInInspector] public float health;
    [HideInInspector] public float speed;
    public float startHealth;
    public float startSpeed;
    public static EnemyParams enemyParamsInstance;
    public static EnemyParams enemyHitInstance;

    void Start()
    {
        enemyParamsInstance = this;
        health = startHealth * GameEngine.gameInstance.difficulty;
        if(speed < 150)
        {
            speed = startSpeed * GameEngine.gameInstance.difficulty;
        }
    }

    public void EnemyNewInstance()
    {
        enemyHitInstance =this;
    }

}
