
using UnityEngine;

public class bullet : MonoBehaviour
{
    
    private Transform target;
    private float slowEnemies;

    private float slowTime;

    public GameObject impactEffect;

    public GameObject enemyToDamage;

    public float bulletSpeed = 70f;

    private float bulletDamage;

       
    public void chase(Transform turretTarget, float slowAmount, float SlowTime, float damage) 
    {
        slowEnemies = slowAmount;
        slowTime = SlowTime;
        target = turretTarget;
        bulletDamage = damage;

    }
  
    void hitTarget()
    {

       
        target.GetComponent<DamageSystem>().damageEnemy((int) bulletDamage, slowEnemies, slowTime);
        if(impactEffect != null)
        {
            GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectInstance, 2f);
        }     
        Destroy(gameObject);

    }


    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
           Destroy(gameObject);
            return;
        }

        Vector3 suunta = target.position - transform.position;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;


        if (suunta.magnitude <= distanceThisFrame)
    {
        hitTarget();
        

    }
    transform.Translate(suunta.normalized * distanceThisFrame, Space.World);

    }
   
}
