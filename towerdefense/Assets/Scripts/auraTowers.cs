using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class auraTowers : MonoBehaviour
{
    public string enemyTag = "mob";
    public string enemyPathFinishTag = "finishLine";
    public string enemyPathSpawnTag = "spawnLine";
    public string sentryTag = "sentry";
    public float attackRange = 100f;
    float distanceToEnemy = 0f;

    float shortestDistance = Mathf.Infinity;
    public int auraTurretLvl = 1;




    private void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject sentry = GameObject.FindGameObjectWithTag(sentryTag);
        GameObject invisEnemy = null;

        foreach (GameObject enemy in enemies)
        {


            if (enemy.name.Contains("Enemy 4(Clone)"))
            {
                invisEnemy = enemy;
                distanceToEnemy = Vector3.Distance(transform.position, invisEnemy.transform.position);

                if (sentry != null && distanceToEnemy <= attackRange)
                {
                        
                    invisEnemy.GetComponent<Renderer>().enabled = true;
                    if (SceneManager.GetActiveScene().name != "MainMenu")
                    {
                    invisEnemy.transform.GetChild(0).GetComponent<Canvas>().enabled = true;
                    }

                }
                if (sentry != null && distanceToEnemy > attackRange)
                {

                    invisEnemy.GetComponent<Renderer>().enabled = false;
                    invisEnemy.transform.GetChild(0).GetComponent<Canvas>().enabled = false;
                }

            }
        }





    }
    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    void Start()
    {

        InvokeRepeating("UpdateTarget", 0f, 0.25f);


    }
    void Update()
    {

    }

}