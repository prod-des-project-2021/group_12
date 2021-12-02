using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class attackEnemy : MonoBehaviour
{
    public static attackEnemy attackEnemyInstance;
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
    public Transform spinner;
    float SpinUpTime = 2;
    float SpinUpTimer;
    float MaxSpinRate = 1000;
    float currentspin;

    private bool attackNearestEnemy = true;
    private bool attackStrongestEnemy = false;

    public void strongestButtonWasClicked()
    {
        attackNearestEnemy = false;
        attackStrongestEnemy = true;
        Debug.Log("stronk");
    }
    public void nearestButtonWasClicked()
    {
        attackStrongestEnemy = false;
        attackNearestEnemy = true;
        Debug.Log("near");
    }

    private void updateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject finishPoint = GameObject.FindGameObjectWithTag(enemyPathFinishTag);
        GameObject spawnPoint = GameObject.FindGameObjectWithTag(enemyPathSpawnTag);

        float shortestDistance = Mathf.Infinity;
        float longestDistance = Mathf.Infinity;
        float distanceToMaxHpEnemy = Mathf.Infinity;

        GameObject nearestEnemy = null;
        GameObject FurthestEnemyInRange = null;
        GameObject mostHpEnemy = null;
        GameObject compareEnemy = null;

        foreach (GameObject enemy in enemies)
        {

            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            float distanceToSpawn = Vector3.Distance(enemy.transform.position, spawnPoint.transform.position);
            float distanceToFinish = Vector3.Distance(enemy.transform.position, finishPoint.transform.position);


            compareEnemy = enemy;
            float distance = Vector3.Distance(transform.position, compareEnemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
                //turrettia lähinnä
                if (attackNearestEnemy)
                {
                    if (nearestEnemy != null && shortestDistance <= attackRange)
                    {
                        target = nearestEnemy.transform;
                    }
                    // Debug.Log("near valittu");
                }
                
            }
            // hp:n määrän mukaan target
            if (attackStrongestEnemy)
            {
                // Debug.Log("stronk valittu");
                if (nearestEnemy.GetComponent<EnemyParams>().startHealth < compareEnemy.GetComponent<EnemyParams>().startHealth)
                {
                    longestDistance = distance;
                    mostHpEnemy = compareEnemy;
                }
                if (mostHpEnemy != null && distance <= attackRange | shortestDistance <= attackRange)
                {

                    target = mostHpEnemy.transform;


                }
                else
                {
                    target = null;
                }
            }

            /*         if(distanceToFinish > distanceToSpawn)
                 {


                 } */



            /*  if(FurthestEnemyInRange != null && longestDistance <= attackRange){
              target = FurthestEnemyInRange.transform;
              }

              /*         if(distanceToFinish > distanceToSpawn)
                   {

                       longestDistance = distanceToEnemy;
                       FurthestEnemyInRange = enemy;

                   } */



            /*  if(FurthestEnemyInRange != null && longestDistance <= attackRange){
              target = FurthestEnemyInRange.transform;
              }
              else if(FurthestEnemyInRange != null && longestDistance > attackRange && shortestDistance <= attackRange){
                  target = nearestEnemy.transform;
              }*/



        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("updateTarget",0f,0.05f);
        //attackEnemyInstance = this;
                  
    }
    void SpinBarrel()
    {
        float theta = (SpinUpTimer / SpinUpTime) * MaxSpinRate * Time.deltaTime;
        spinner.Rotate(Vector3.right, theta);
    }
    // Update is called once per frame
    void Update()
    {
        if(spinner != null)
        {
            SpinBarrel();
        }
        
        if (target == null)
        {
            SpinUpTimer = Mathf.Clamp(
            SpinUpTimer - Time.deltaTime,
            0, SpinUpTime);
            //tykki kääntyy default-asentoon
            if(rotatingPart != null)
            {
                rotatingPart.rotation = Quaternion.Lerp(rotatingPart.rotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * turnSpeed);
            }
            

        }
        else
        {
            SpinUpTimer = Mathf.Clamp(
            SpinUpTimer + Time.deltaTime,
            0, SpinUpTime);
            if(rotatingPart != null)
            {
                Vector3 direction = target.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                Vector3 rotation = Quaternion.Lerp(rotatingPart.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
                rotatingPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            }
            
        }
        



        if (fireCountdown <= 0f)
        {

            if (spinner != null)
            {   
                if (SpinUpTimer >= SpinUpTime)
                {
                    shoot();
                    fireCountdown = 1f / fireRate;
                }
                

            }
            else
            {

                shoot();
                fireCountdown = 1f / fireRate;
            }

        }
        fireCountdown -= Time.deltaTime;

    }

    void shoot()
    {
        if (target == null) return;
        if (attackRange >= Vector3.Distance(firePoint.position, target.position))
        {
            GameObject bulletGo = (GameObject)Instantiate(bullet, firePoint.position, firePoint.rotation);

            if (bullet.name.Contains("Bullet"))
            {


                bullet paukku = bulletGo.GetComponent<bullet>();

                if (paukku != null)
                {
                    paukku.chase(target, slowEnemiesAmount, slowTime, damage);
                }

            }
            else if (bullet.name.Contains("Missile"))
            {

                Missile paukku = bulletGo.GetComponent<Missile>();

                if (paukku != null)
                {
                    paukku.chase(target, slowEnemiesAmount, slowTime, damage);
                }
            }
            else if (bullet.name.Contains("Zap"))
            {
                Zap zap = bulletGo.GetComponent<Zap>();

                if (zap != null)
                {
                    StartCoroutine(zap.hitTarget(damage));
                }
            }
        }
        


    }


}
