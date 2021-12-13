using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageSystem : MonoBehaviour
{
    public static DamageSystem damageInstance;
    float timer = 0f;

    public Image healthBar;
    private float health;
   
    bool timeToDie;
    int i = 1;
    private GameObject[] deathpoints = new GameObject[9];
    GameEngine gameEngine;
    EnemyParams enemyparams;
    
    Waypoints wpInstance;
    private float normalEnemySpeed;


    private void Awake()
    {
        gameEngine = gameObject.GetComponent<GameEngine>();
    }


    void Start()
    {

        enemyparams = gameObject.GetComponent<EnemyParams>();
       
        wpInstance = gameObject.GetComponent<Waypoints>();
        health = enemyparams.startHealth;
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
            GameObject deathSound = GameObject.FindGameObjectWithTag("turretSounds");
            deathSound.GetComponent<sounds>().playEnemyDeathSound();
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
       float originalSpeedMultiplier = 1f;
        
        //Enemy1Params.enemy1HitInstance = this.gameObject;
        if(this.gameObject.name.Contains("Enemy 1"))
        {          
            enemyparams.EnemyNewInstance();

            wpInstance.NewWPInstance();
            float apu = wpInstance.speedMultiplier;   
            EnemyParams.enemyHitInstance.health -= attackDamage;
            
              healthBar.fillAmount =  EnemyParams.enemyHitInstance.health/EnemyParams.enemyHitInstance.startHealth;             
            
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
           
            GameObject enemy2 = GameObject.Find("Enemy 2(Clone)");
          
            healthBar.fillAmount =  EnemyParams.enemyHitInstance.health/EnemyParams.enemyHitInstance.startHealth;
            
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
             healthBar.fillAmount =  EnemyParams.enemyHitInstance.health/EnemyParams.enemyHitInstance.startHealth;

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
        else if (this.gameObject.name.Contains("Enemy 4"))
        {
            enemyparams.EnemyNewInstance();

            wpInstance.NewWPInstance();
            float apu = wpInstance.speedMultiplier;
          
            EnemyParams.enemyHitInstance.health -= attackDamage;
              healthBar.fillAmount =  EnemyParams.enemyHitInstance.health/EnemyParams.enemyHitInstance.startHealth;
            
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
