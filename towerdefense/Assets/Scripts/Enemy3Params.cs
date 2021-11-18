using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Params : MonoBehaviour
{
    [HideInInspector] public float speed = 35;
    [HideInInspector] public float health;
    public float startHealth = 150;
    public static Enemy3Params enemy3ParamsInstance;
    public static Enemy3Params enemy3HitInstance;

    void Start()
    {
        enemy3ParamsInstance = this;
        health = startHealth * GameEngine.gameInstance.difficulty; 
        if (speed < 100)
        {
            speed = 15 * GameEngine.gameInstance.difficulty;
        }
        

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Enemy3NewInstance()
    {
        enemy3HitInstance =this;
    }
}
