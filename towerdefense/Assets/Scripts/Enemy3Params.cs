using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Params : MonoBehaviour
{
    [HideInInspector] public float speed = 35;
    public float health = 150;
    public float difficulty;
    public static Enemy3Params enemy3ParamsInstance;
    public static Enemy3Params enemy3HitInstance;

    void Start()
    {
        enemy3HitInstance = this;
        enemy3ParamsInstance = this;
        difficulty = SpawnEnemy.spawnEnemyInstance.difficulty;
        health = 150 * difficulty;
        speed = 10 * difficulty;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Enemy3NewInstance()
    {
        enemy3HitInstance = this;
    }
}
