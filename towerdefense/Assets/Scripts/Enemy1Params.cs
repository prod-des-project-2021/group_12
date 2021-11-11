using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Params : MonoBehaviour
{
    [HideInInspector] public float speed = 35;
    public float health = 150;
    public float difficulty;
    public static Enemy1Params enemy1ParamsInstance;
    public static Enemy1Params enemy1HitInstance;

    void Start()
    {
        enemy1ParamsInstance = this;
        difficulty = SpawnEnemy.spawnEnemyInstance.difficulty;
        health = 75 * difficulty;
        speed = 50 * difficulty;

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        enemy1HitInstance = this;
    }
}
