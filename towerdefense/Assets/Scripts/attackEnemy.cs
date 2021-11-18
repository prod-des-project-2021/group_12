using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackEnemy : MonoBehaviour
{
   
   [Header("Attributes")]
    public float fireRate = 1f;
    
    public float damage = 75f;
    private float fireCountdown = 0f;
    public float attackRange = 100f;
    public float turnSpeed = 10f;

    public float slowEnemiesAmount;
    public float slowTime;

    [Header("Unity setup")]
    private Transform target;
    public Transform rotatingPart;
    public string enemyTag = "mob";
    public string enemyPathFinishTag = "finishLine";
    public string enemyPathSpawnTag = "spawnLine";

    private string enemyNumber1 = "Enemy 1";
    private string enemyNumber2 = "Enemy 2";
    private string enemyNumber3 = "Enemy 3";
    public GameObject bullet;
    public Transform firePoint;

    Enemy1Params enemy1params;
    Enemy2Params enemy2params;
    Enemy3Params enemy3params;
    

    private void updateTarget(){
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject finishPoint = GameObject.FindGameObjectWithTag(enemyPathFinishTag);
        GameObject spawnPoint = GameObject.FindGameObjectWithTag(enemyPathSpawnTag);

     
        float shortestDistance = Mathf.Infinity;
        float longestDistance = Mathf.Infinity;
        
        GameObject nearestEnemy = null;
        GameObject FurthestEnemyInRange = null;
        
        
        

       
        

        foreach(GameObject enemy in enemies)
        {
            
           GameObject mostHpEnemy;
          
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            float distanceToSpawn = Vector3.Distance(enemy.transform.position,spawnPoint.transform.position);
           float distanceToFinish = Vector3.Distance(enemy.transform.position, finishPoint.transform.position);

                  
                  
                    if(distanceToEnemy < shortestDistance){
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                   
                   
                    
                }

           /*         if(distanceToFinish > distanceToSpawn)
                {
                    
                    longestDistance = distanceToEnemy;
                    FurthestEnemyInRange = enemy;

                          
                } */
            
            if(nearestEnemy != null && shortestDistance <= attackRange)
            {
                
                target = nearestEnemy.transform;
                
            }
          /*  if(FurthestEnemyInRange != null && longestDistance <= attackRange){
            target = FurthestEnemyInRange.transform;
            }
            else if(FurthestEnemyInRange != null && longestDistance > attackRange && shortestDistance <= attackRange){
                target = nearestEnemy.transform;
            }*/

        

        }
    }

     private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    // Start is called before the first frame update
    void Start()
    {
        enemy1params = gameObject.GetComponent<Enemy1Params>();
        enemy2params = gameObject.GetComponent<Enemy2Params>();
        enemy3params = gameObject.GetComponent<Enemy3Params>();
     InvokeRepeating("updateTarget",0f,0.5f);
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        if(target == null)
        {
          
            return;
        }

      Vector3 direction = target.position - transform.position;
      Quaternion lookRotation = Quaternion.LookRotation(direction);
      Vector3 rotation = Quaternion.Lerp(rotatingPart.rotation,lookRotation, Time.deltaTime* turnSpeed).eulerAngles;
      rotatingPart.rotation = Quaternion.Euler(0f,rotation.y, 0f);
      
        if(fireCountdown <= 0f)
        {
            shoot();
            fireCountdown = 1f/fireRate;
        }
        fireCountdown -= Time.deltaTime;
       
    } 

    void shoot()
    {
        
        GameObject bulletGo = (GameObject) Instantiate (bullet, firePoint.position, firePoint.rotation);
        bullet paukku = bulletGo.GetComponent<bullet>();
        
        if(paukku != null)
        {
            paukku.chase(target, slowEnemiesAmount,slowTime,damage);
        }

    }
        
    
}
