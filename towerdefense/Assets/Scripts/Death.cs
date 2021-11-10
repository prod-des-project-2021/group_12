using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public static Death deathInstance;
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
            EnemyParams.enemyParamsInstance.speed = 0;
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

    void OnMouseDown()
    {
        //KillEnemy();
        //deathInstance = this;

    }

    public void KillEnemy()
    {
        timeToDie = true;
    }
}

