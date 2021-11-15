using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public static DamageSystem damageInstance;
    float timer = 0f;
    bool timeToDie;
    int i = 1;
    private GameObject[] deathpoints = new GameObject[9];
    // Start is called before the first frame update
    Enemy1Params enemy1params;
    Enemy2Params enemy2params;
    Enemy3Params enemy3params;
    Waypoints wpInstance;

    void Start()
    {
        enemy1params = gameObject.GetComponent<Enemy1Params>();
        enemy2params = gameObject.GetComponent<Enemy2Params>();
        enemy3params = gameObject.GetComponent<Enemy3Params>();
        wpInstance = gameObject.GetComponent<Waypoints>();
        deathpoints[0] = GameObject.Find("Finish 1");
        deathpoints[1] = GameObject.Find("Finish 2");
        deathpoints[2] = GameObject.Find("Finish 3");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(deathpoints[0].transform.position, transform.position) < 1)
        {
            Destroy(gameObject);
        }
        if (Vector3.Distance(deathpoints[1].transform.position, transform.position) < 1)
        {
            Destroy(gameObject);
        }

        if (Vector3.Distance(deathpoints[2].transform.position, transform.position) < 1)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        
        if (timeToDie)
        {
            Waypoints.wPInstanceRunning.speedMultiplier = 0;
            if (timer < 0.01)
            {
                timer += Time.deltaTime;
            }
            else
            {
                this.gameObject.transform.localScale += new Vector3(i, 0, i);

                timer = 0;
                i++;

                if (i >= 6)
                {
                    
                    timeToDie = false;
                    Destroy(gameObject);
                }
            }
        }

    }

    //t�m� korvataan sitten kun turretti osuu
    public void DamageEnemy(int damageAmount)
    {
        
        //Enemy1Params.enemy1HitInstance = this.gameObject;
        int attackDamage = damageAmount;
        if(this.gameObject.name.Contains("Enemy 1"))
        {          
            enemy1params.Enemy1NewInstance();
            Debug.Log("HP enemy 1 ennen: "+Enemy1Params.enemy1HitInstance.health);
            Enemy1Params.enemy1HitInstance.health -= attackDamage;
            Debug.Log("HP enemy 1 jalkeen: " + Enemy1Params.enemy1HitInstance.health);
            if (Enemy1Params.enemy1HitInstance.health <= 0.0f)
            {
                wpInstance.NewWPInstance();
                timeToDie = true;
            }
        }
        else if (this.gameObject.name.Contains("Enemy 2"))
        {
            enemy2params.Enemy2NewInstance();
            Debug.Log("HP enemy 2 ennen: " + Enemy2Params.enemy2HitInstance.health);
            Enemy2Params.enemy2HitInstance.health -= attackDamage;
            Debug.Log("HP enemy 2 jalkeen: " + Enemy2Params.enemy2HitInstance.health);
            if (Enemy2Params.enemy2HitInstance.health <= 0.0f)
            {
                wpInstance.NewWPInstance();
                timeToDie = true;
            }
        }
        else if (this.gameObject.name.Contains("Enemy 3"))
        {
            enemy3params.Enemy3NewInstance();
            Debug.Log("HP enemy 3 ennen: " + Enemy3Params.enemy3HitInstance.health);
            Enemy3Params.enemy3HitInstance.health -= attackDamage;
            Debug.Log("HP enemy 3 jalkeen: " + Enemy3Params.enemy3HitInstance.health);
            if (Enemy3Params.enemy3HitInstance.health <= 0.0f)
            {
                wpInstance.NewWPInstance();
                timeToDie = true;
            }
        }



    }

   

}
