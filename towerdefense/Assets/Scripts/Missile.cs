
using UnityEngine;

public class Missile : MonoBehaviour
{

    private Transform target;
    private float slowEnemies;

    private float slowTime;

    public GameObject impactEffect;

    public GameObject enemyToDamage;

    public float bulletSpeed = 70f;

    float bulletDamage;

    private Vector3 deadTargetPos;


    public void chase(Transform turretTarget, float slowAmount, float SlowTime,float damage)
    {
        slowEnemies = slowAmount;
        slowTime = SlowTime;
        target = turretTarget;
        bulletDamage = damage;

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 20);
    }
    void hitTarget()
    {


        //target.GetComponent<DamageSystem>().damageEnemy((int)bulletDamage, slowEnemies, slowTime);

        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, Quaternion.LookRotation(Vector3.up));
        Destroy(effectInstance, 0.4f);
        Destroy(gameObject);
        Collider[] exColliders = Physics.OverlapSphere(transform.position, 22);
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
        
        if (target == null && this == null)
        {
            return;
        }

        Vector3 targetDir;
        Vector3 newDir;

        if (target != null) {
            deadTargetPos = target.position;
            targetDir = target.position - transform.position;
            float singleStep = bulletSpeed * Time.deltaTime;
            newDir = Vector3.RotateTowards(transform.forward, targetDir, singleStep, 0.0f);
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * bulletSpeed);
        }
        else
        {
            targetDir = deadTargetPos - transform.position;
            float singleStep = bulletSpeed * Time.deltaTime;
            newDir = Vector3.RotateTowards(transform.forward, targetDir, singleStep, 0.0f);
            transform.position = Vector3.MoveTowards(transform.position, deadTargetPos, Time.deltaTime * bulletSpeed);
        }
        
        transform.rotation = Quaternion.LookRotation(newDir);

        
        if (targetDir.magnitude <= 1)
        {     
            hitTarget();
            GameObject hitSound = GameObject.FindGameObjectWithTag("turretSounds");
            hitSound.GetComponent<sounds>().playMissileExplosionSound();
        }
        
    }

}
