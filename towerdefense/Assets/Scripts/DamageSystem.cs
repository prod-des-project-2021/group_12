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
    void Start()
    {
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
            Waypoints.wPInstance.stop = 0;
            if (timer < 0.01)
            {
                timer += Time.deltaTime;
            }
            else
            {
                this.gameObject.transform.localScale += new Vector3(i, 0, i);

                timer = 0;
                Debug.Log(this.gameObject);
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
    void OnMouseDown()
    {
        float attackDamage = 50f;
        Debug.Log("adgdasgas: "+this.gameObject.name);
        if(this.gameObject.name.Contains("Enemy 1"))
        {
            Debug.Log("HP ennen: "+Enemy1Params.enemy1HitInstance.health);
            Enemy1Params.enemy1HitInstance.health -= attackDamage;
            Debug.Log("HP j�lkeen: " + Enemy1Params.enemy1HitInstance.health);
            if (Enemy1Params.enemy1HitInstance.health <= 0.0f)
            {
                timeToDie = true;
            }
        }
        else if (this.gameObject.name.Contains("Enemy 2"))
        {
            Enemy2Params.enemy2HitInstance.health -= attackDamage;
            if (Enemy2Params.enemy2HitInstance.health <= 0.0f)
            {
                timeToDie = true;
            }
        }
        else if (this.gameObject.name.Contains("Enemy 3"))
        {
            Enemy3Params.enemy3HitInstance.health -= attackDamage;
            Debug.Log("HP j�lkeen: " + Enemy3Params.enemy3HitInstance.health);
            if (Enemy3Params.enemy3HitInstance.health <= 0.0f)
            {
                timeToDie = true;
            }
        }



    }

   

}
