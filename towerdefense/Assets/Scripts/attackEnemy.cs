using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class attackEnemy : MonoBehaviour
{

    [Header("Attributes")]
    public bool attackNearestEnemy = true;
    public bool attackStrongestEnemy = false;
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


    public GameObject bullet;
    public Transform firePoint;
    public Transform spinner;
    float SpinUpTime = 2;
    float SpinUpTimer;
    float MaxSpinRate = 360;


    private void updateTarget()
    {
       
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);  
        GameObject finishPoint = GameObject.FindGameObjectWithTag(enemyPathFinishTag);
        GameObject spawnPoint = GameObject.FindGameObjectWithTag(enemyPathSpawnTag);

        float shortestDistance = Mathf.Infinity;
       float longestDistance = Mathf.Infinity;
        float distance = Mathf.Infinity;

        GameObject nearestEnemy = null;
       // GameObject FurthestEnemyInRange = null;
        GameObject mostHpEnemy = null;
        double maxHpEnemy = 0;       

        foreach(GameObject enemy in enemies)
        {            
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            float distanceToSpawn = Vector3.Distance(enemy.transform.position, spawnPoint.transform.position);
            float distanceToFinish = Vector3.Distance(enemy.transform.position, finishPoint.transform.position);
            
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
                
                 }
                //turrettia lähinnä
                if (attackNearestEnemy)
                {
                   // Debug.Log("attack nearest enemy");
                     if (nearestEnemy != null && shortestDistance <= attackRange)
                {
                    target = nearestEnemy.transform;
                }
                     
                }
                
                 // hp:n määrän mukaan target
                 if(attackStrongestEnemy){
                     Debug.Log("stronk valittu");

                if(maxHpEnemy < enemy.GetComponent<EnemyParams>().startHealth){
                    mostHpEnemy = enemy;
                    distance =Vector3.Distance(transform.position, mostHpEnemy.transform.position);
                    maxHpEnemy = enemy.GetComponent<EnemyParams>().startHealth;
                }
                
                if(mostHpEnemy != null && distance <= attackRange){
                    target = mostHpEnemy.transform;
                }else if(shortestDistance <= attackRange){
                    target = nearestEnemy.transform;
                }              
             }
                                                            
        }
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    // Start is called before the first frame update
    void Start()
    {
       
        InvokeRepeating("updateTarget", 0f, 0.25f);


    }
    void SpinBarrel()
    {
        float theta = (SpinUpTimer / SpinUpTime) *
         MaxSpinRate * Time.deltaTime;
        spinner.RotateAroundLocal(Vector3.back, theta);

    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            SpinUpTimer = Mathf.Clamp(
            SpinUpTimer - Time.deltaTime,
            0, SpinUpTime);
            //tykki kääntyy default-asentoon
            rotatingPart.rotation = Quaternion.Lerp(rotatingPart.rotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * turnSpeed);

        }
        else
        {
            SpinUpTimer = Mathf.Clamp(
            SpinUpTimer + Time.deltaTime,
            0, SpinUpTime);
            Vector3 direction = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(rotatingPart.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            rotatingPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }




        if (fireCountdown <= 0f)
        {

            if (spinner != null)
            {
                SpinBarrel();
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


    }


}
