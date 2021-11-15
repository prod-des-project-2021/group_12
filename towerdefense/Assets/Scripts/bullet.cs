
using UnityEngine;

public class bullet : MonoBehaviour
{
    
    private Transform target;

    public GameObject impactEffect;

    public GameObject enemyToDamage;

    public float bulletSpeed = 70f;

    public float bulletDamage = 75f;

    
    
    public void chase(Transform turretTarget) 
    {
        target = turretTarget;

    }
  
    void hitTarget()
    {
       
        
       target.GetComponent<DamageSystem>().damageEnemy((int) bulletDamage);
       
        GameObject effectInstance = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 2f);

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

    if(suunta.magnitude <= distanceThisFrame)
    {
        hitTarget();
    }
    transform.Translate(suunta.normalized * distanceThisFrame, Space.World);

    }
   
}
