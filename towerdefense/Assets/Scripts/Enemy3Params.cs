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
        enemy3ParamsInstance = this;
        difficulty = SpawnEnemy.spawnEnemyInstance.difficulty;
        health = 150 * difficulty;
        speed = 30 * difficulty;

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        enemy3HitInstance = this;
    }
}
