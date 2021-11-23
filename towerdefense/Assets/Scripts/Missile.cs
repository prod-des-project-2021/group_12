
using UnityEngine;

public class Missile : MonoBehaviour
{

    private Transform target;
    private float slowEnemies;

    private float slowTime;

    public GameObject impactEffect;

    public GameObject enemyToDamage;

    public float bulletSpeed = 70f;

    public float bulletDamage = 75f;


    public void chase(Transform turretTarget, float slowAmount, float SlowTime,float damage)
    {
        slowEnemies = slowAmount;
        slowTime = SlowTime;
        target = turretTarget;

    }

    void hitTarget()
    {


        //target.GetComponent<DamageSystem>().damageEnemy((int)bulletDamage, slowEnemies, slowTime);

        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 0.4f);
        Destroy(gameObject);
        Collider[] exColliders = Physics.OverlapSphere(transform.position, 20);
        for (int i = 0; i < exColliders.Length; i++)
        {
            if (exColliders[i].name.Contains("Enemy")){
                //Debug.Log(exColliders[i]);
                exColliders[i].GetComponent<DamageSystem>().damageEnemy((int)bulletDamage, slowEnemies, slowTime);
            }
        }
        

    }



    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        //Vector3 suunta = target.position - transform.position;
        //float distanceThisFrame = bulletSpeed * Time.deltaTime;

        Vector3 targetDir = target.position - transform.position;
        float singleStep = bulletSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, singleStep, 0.0f);

        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * bulletSpeed);
        transform.rotation = Quaternion.LookRotation(newDir);

        if (targetDir.magnitude <= 1)
        {
            hitTarget();


        }
        //transform.Translate(targetDir.normalized * singleStep, Space.World);

    }

}
