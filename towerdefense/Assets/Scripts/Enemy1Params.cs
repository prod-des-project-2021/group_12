using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Params : MonoBehaviour
{
    DamageSystem ds;
    [HideInInspector] public float speed = 35;
    [HideInInspector] public float health;
    public float startHealth = 75;
    public static Enemy1Params enemy1ParamsInstance;
    public static Enemy1Params enemy1HitInstance;

    void Start()
    {
        enemy1ParamsInstance = this;
        health = startHealth * GameEngine.gameInstance.difficulty;
        if(speed < 150)
        {
            speed = 30 * GameEngine.gameInstance.difficulty;
        }

    }

    
    // Update is called once per frame
    void Update()
    {
       
 

    }

    public void Enemy1NewInstance()
    {
        enemy1HitInstance =this;
    }

}
