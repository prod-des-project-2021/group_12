using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Params : MonoBehaviour
{
    [HideInInspector] public float speed = 35;
    [HideInInspector] public float health;
    public float startHealth = 100;
    public static Enemy2Params enemy2ParamsInstance;
    public static Enemy2Params enemy2HitInstance;

    void Start()
    {
        enemy2ParamsInstance = this;
        health = startHealth * GameEngine.gameInstance.difficulty; 
        if(speed < 130)
        {
            speed = 25 * GameEngine.gameInstance.difficulty;
        }
        

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
