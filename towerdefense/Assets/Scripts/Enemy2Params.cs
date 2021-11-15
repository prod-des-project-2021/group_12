using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Params : MonoBehaviour
{
    [HideInInspector] public float speed = 35;
    public float health = 150;
    public float difficulty;
    public static Enemy2Params enemy2ParamsInstance;
    public static Enemy2Params enemy2HitInstance;

    void Start()
    {
        enemy2HitInstance = this;
        enemy2ParamsInstance = this;
        difficulty = SpawnEnemy.spawnEnemyInstance.difficulty;
        health = 100 * difficulty;
        speed = 25 * difficulty;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Enemy2NewInstance()
    {
        enemy2HitInstance =this;
    }
}
