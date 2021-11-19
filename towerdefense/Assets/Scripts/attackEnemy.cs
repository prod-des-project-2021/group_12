using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackEnemy : MonoBehaviour
{
   
   [Header("Attributes")]
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float attackRange = 50f;
    public float turnSpeed = 10f;

    public float slowEnemiesAmount;
    public float slowTime;

    [Header("Unity setup")]
    private Transform target;
    public Transform rotatingPart;
    public string enemyTag = "mob";
    public GameObject bullet;
    public Transform firePoint;
    

    private void updateTarget(){
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy< shortestDistance){
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
                
            }
        }
        if(nearestEnemy != null && shortestDistance <= attackRange) {
            {
                target = nearestEnemy.transform;
            }
        }else{
            target = null;
        }

    }

     private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    // Start is called before the first frame update
    void Start()
    {
     InvokeRepeating("updateTarget",0f,0.5f);
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        if(target == null)
        {
           rotatingPart.rotation = Quaternion.Lerp(rotatingPart.rotation,Quaternion.Euler(0f, 0f, 0f), Time.deltaTime *turnSpeed);
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
            paukku.chase(target, slowEnemiesAmount,slowTime);
        }

    }
        
    
}
