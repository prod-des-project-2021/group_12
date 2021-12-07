using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zap : MonoBehaviour
{

    private Transform target;
    private float slowEnemies;

    private float slowTime;

    public GameObject impactEffect;

    public GameObject enemyToDamage;

    public float bulletSpeed = 70f;


    public IEnumerator hitTarget(float bulletDamage)
    {

        //target.GetComponent<DamageSystem>().damageEnemy((int)bulletDamage, slowEnemies, slowTime);

        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, Quaternion.LookRotation(Vector3.up));
        Destroy(effectInstance, 0.4f);
        Destroy(gameObject);
        Collider[] exColliders = Physics.OverlapSphere(transform.position, 75);
        yield return new WaitForSeconds(0.25f);
        for (int i = 0; i < exColliders.Length; i++)
        {
            if (exColliders[i] != null)
            {
                if (exColliders[i].name.Contains("Enemy"))
                {
                    exColliders[i].GetComponent<DamageSystem>().damageEnemy((int)bulletDamage, slowEnemies, slowTime);
                }
            }
            
        }


    }



}
