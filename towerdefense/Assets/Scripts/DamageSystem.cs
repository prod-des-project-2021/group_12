using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public static DamageSystem damageInstance;
    float timer = 0f;
   
    bool timeToDie;
    int i = 1;
    private GameObject[] deathpoints = new GameObject[9];
    GameEngine gameEngine;
    EnemyParams enemyparams;
    //Enemy2Params enemy2params;
    //Enemy3Params enemy3params;
    Waypoints wpInstance;
    private float normalEnemySpeed;


    private void Awake()
    {
        gameEngine = gameObject.GetComponent<GameEngine>();
    }


    void Start()
    {

        enemyparams = gameObject.GetComponent<EnemyParams>();
        //enemy2params = gameObject.GetComponent<Enemy2Params>();
        //enemy3params = gameObject.GetComponent<Enemy3Params>();
        wpInstance = gameObject.GetComponent<Waypoints>();
        
        deathpoints[0] = GameObject.Find("Finish 1");
        deathpoints[1] = GameObject.Find("Finish 2");
        deathpoints[2] = GameObject.Find("Finish 3");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(deathpoints[0].transform.position, transform.position) < 1)
        {        
            Destroy(gameObject);
            GameEngine.gameInstance.DamagePlayer(1);

        }
        if (Vector3.Distance(deathpoints[1].transform.position, transform.position) < 1)
        {        
            Destroy(gameObject);
            GameEngine.gameInstance.DamagePlayer(1);
        }

        if (Vector3.Distance(deathpoints[2].transform.position, transform.position) < 1)
        {
            Destroy(gameObject);
            GameEngine.gameInstance.DamagePlayer(1);
        }
    }

    void FixedUpdate()
    {

        if (timeToDie)
        {

            Destroy(gameObject);
        }

    }


    public IEnumerator slowTimer(float slowTime,float slowAmount,Waypoints wpInstance)
    {
            
            wpInstance.speedMultiplier += slowAmount;
            yield return new WaitForSeconds(slowTime);
            wpInstance.speedMultiplier = 1f;        
    }
   
    public void damageEnemy(int attackDamage, float slowAmount, float slowTime)
    {
        
        //Enemy1Params.enemy1HitInstance = this.gameObject;
        if(this.gameObject.name.Contains("Enemy 1"))
        {          
            enemyparams.EnemyNewInstance();

            wpInstance.NewWPInstance();
            float apu = wpInstance.speedMultiplier;   
            EnemyParams.enemyHitInstance.health -= attackDamage;            
            
            if (EnemyParams.enemyHitInstance.health <= 0.0f)
            {
                wpInstance.NewWPInstance();
                Waypoints.wPInstanceRunning.speedMultiplier = 0;
                timeToDie = true;
                GameEngine.gameInstance.AddMoney(25);
                GameEngine.gameInstance.IncreaseScore(1f);
            }
            if(slowAmount < 0 && wpInstance.speedMultiplier == apu)
            {
                
                StartCoroutine(slowTimer(slowTime,slowAmount,wpInstance));
               
            }
        }
        else if (this.gameObject.name.Contains("Enemy 2"))
        {
            enemyparams.EnemyNewInstance();
            wpInstance.NewWPInstance();
            float apu = wpInstance.speedMultiplier;

            EnemyParams.enemyHitInstance.health -= attackDamage;
            if (EnemyParams.enemyHitInstance.health <= 0.0f)
            {
                wpInstance.NewWPInstance();
                Waypoints.wPInstanceRunning.speedMultiplier = 0;
                timeToDie = true;
                GameEngine.gameInstance.AddMoney(30);
                GameEngine.gameInstance.IncreaseScore(1.25f);
            }
             if(slowAmount < 0 && wpInstance.speedMultiplier == apu)
            {
                
                StartCoroutine(slowTimer(slowTime,slowAmount,wpInstance));
               
            }
        }
        else if (this.gameObject.name.Contains("Enemy 3"))
        {
            enemyparams.EnemyNewInstance();

            wpInstance.NewWPInstance();
            float apu = wpInstance.speedMultiplier;
          
            EnemyParams.enemyHitInstance.health -= attackDamage;
            
            if (EnemyParams.enemyHitInstance.health <= 0.0f)
            {
                wpInstance.NewWPInstance();
                Waypoints.wPInstanceRunning.speedMultiplier = 0;
                timeToDie = true;
                GameEngine.gameInstance.AddMoney(35);
                GameEngine.gameInstance.IncreaseScore(1.5f);
            }
            if(slowAmount < 0 && wpInstance.speedMultiplier == apu)
            {
                
                StartCoroutine(slowTimer(slowTime,slowAmount,wpInstance));
               
            }
        }



    }

   

}
