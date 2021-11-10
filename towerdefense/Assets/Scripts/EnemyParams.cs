using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParams : MonoBehaviour
{
    public static EnemyParams enemyParamsInstance;
    [HideInInspector] public float speed = 40;
    public float health;
    public float difficulty = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemyParamsInstance = this;
        if (this.gameObject.name == "Enemy 1(Clone)") 
        {
            health = 100 * difficulty;
            speed = 35 * difficulty;
            return;
        }
        if (this.gameObject.name == "Enemy 2(Clone)")
        {
            health = 75 * difficulty;
            speed = 50 * difficulty;
            return;

        }
        if (this.gameObject.name == "Enemy 3(Clone)")
        {
            health = 150 * difficulty;
            speed = 25 * difficulty;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


}
