using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Waypoints : MonoBehaviour
{
    public static Waypoints wPInstanceBirth;
    public static Waypoints wPInstanceRunning;
    private GameObject[] waypoints = new GameObject[100];
    int current = 0;
    [HideInInspector] public float speed, speed2, speed3;
    [HideInInspector] public float speedMultiplier = 1.0f;
    float WPradius = 1;

    private void Awake()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "SampleScene")
        {
            waypoints[0] = GameObject.Find("Turn 1 1");
            waypoints[1] = GameObject.Find("Turn 1 2");
            waypoints[2] = GameObject.Find("Turn 1 3");

            waypoints[3] = GameObject.Find("Turn 2 1");
            waypoints[4] = GameObject.Find("Turn 2 2");
            waypoints[5] = GameObject.Find("Turn 2 3");

            waypoints[6] = GameObject.Find("Finish 1");
            waypoints[7] = GameObject.Find("Finish 2");
            waypoints[8] = GameObject.Find("Finish 3");
        }else if (sceneName == "FirstMap" || sceneName == "MainMenu")
        {
            waypoints[0] = GameObject.Find("Turn 1 1");
            waypoints[1] = GameObject.Find("Turn 1 2");
            waypoints[2] = GameObject.Find("Turn 1 3");

            waypoints[3] = GameObject.Find("Turn 2 1");
            waypoints[4] = GameObject.Find("Turn 2 2");
            waypoints[5] = GameObject.Find("Turn 2 3");

            waypoints[6] = GameObject.Find("Turn 3 1");
            waypoints[7] = GameObject.Find("Turn 3 2");
            waypoints[8] = GameObject.Find("Turn 3 3");

            waypoints[9]  = GameObject.Find("Turn 4 1");
            waypoints[10] = GameObject.Find("Turn 4 2");
            waypoints[11] = GameObject.Find("Turn 4 3");

            waypoints[12] = GameObject.Find("Turn 5 1");
            waypoints[13] = GameObject.Find("Turn 5 2");
            waypoints[14] = GameObject.Find("Turn 5 3");

            waypoints[15] = GameObject.Find("Turn 6 1");
            waypoints[16] = GameObject.Find("Turn 6 2");
            waypoints[17] = GameObject.Find("Turn 6 3");

            waypoints[18] = GameObject.Find("Turn 7 1");
            waypoints[19] = GameObject.Find("Turn 7 2");
            waypoints[20] = GameObject.Find("Turn 7 3");

            waypoints[21] = GameObject.Find("Turn 8 1");
            waypoints[22] = GameObject.Find("Turn 8 2");
            waypoints[23] = GameObject.Find("Turn 8 3");

            waypoints[24] = GameObject.Find("Finish 1");
            waypoints[25] = GameObject.Find("Finish 2");
            waypoints[26] = GameObject.Find("Finish 3");
        }else if(sceneName == "SecondMap")
        {
            waypoints[0] = GameObject.Find("Turn 1 1");
            waypoints[1] = GameObject.Find("Turn 1 2");
            waypoints[2] = GameObject.Find("Turn 1 3");

            waypoints[3] = GameObject.Find("Turn 2 1");
            waypoints[4] = GameObject.Find("Turn 2 2");
            waypoints[5] = GameObject.Find("Turn 2 3");

            waypoints[6] = GameObject.Find("Turn 3 1");
            waypoints[7] = GameObject.Find("Turn 3 2");
            waypoints[8] = GameObject.Find("Turn 3 3");

            waypoints[9] = GameObject.Find("Turn 4 1");
            waypoints[10] = GameObject.Find("Turn 4 2");
            waypoints[11] = GameObject.Find("Turn 4 3");

            waypoints[12] = GameObject.Find("Turn 5 1");
            waypoints[13] = GameObject.Find("Turn 5 2");
            waypoints[14] = GameObject.Find("Turn 5 3");

            waypoints[15] = GameObject.Find("Turn 6 1");
            waypoints[16] = GameObject.Find("Turn 6 2");
            waypoints[17] = GameObject.Find("Turn 6 3");

            waypoints[18] = GameObject.Find("Turn 7 1");
            waypoints[19] = GameObject.Find("Turn 7 2");
            waypoints[20] = GameObject.Find("Turn 7 3");

            waypoints[21] = GameObject.Find("Turn 8 1");
            waypoints[22] = GameObject.Find("Turn 8 2");
            waypoints[23] = GameObject.Find("Turn 8 3");

            waypoints[24] = GameObject.Find("Turn 9 1");
            waypoints[25] = GameObject.Find("Turn 9 2");
            waypoints[26] = GameObject.Find("Turn 9 3");

            waypoints[27] = GameObject.Find("Turn 10 1");
            waypoints[28] = GameObject.Find("Turn 10 2");
            waypoints[29] = GameObject.Find("Turn 10 3");

            waypoints[30] = GameObject.Find("Turn 11 1");
            waypoints[31] = GameObject.Find("Turn 11 2");
            waypoints[32] = GameObject.Find("Turn 11 3");

            waypoints[33] = GameObject.Find("Turn 12 1");
            waypoints[34] = GameObject.Find("Turn 12 2");
            waypoints[35] = GameObject.Find("Turn 12 3");

            waypoints[36] = GameObject.Find("Turn 13 1");
            waypoints[37] = GameObject.Find("Turn 13 2");
            waypoints[38] = GameObject.Find("Turn 13 3");

            waypoints[39] = GameObject.Find("Finish 1");
            waypoints[40] = GameObject.Find("Finish 2");
            waypoints[41] = GameObject.Find("Finish 3");
        }
        
    }
    void Start()
    {
        wPInstanceBirth = this;
        current = Random.Range(0, 3);
        speed = EnemyParams.enemyParamsInstance.speed;
        Debug.Log("waypointteja " + waypoints.Length);
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("waypoints current " + current);
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            //seuraava kulma
            if(current % 3 == 0)
            {
                current += Random.Range(3, 6);
            }
            else if ((current -1) % 3 == 0)
            {
                current += Random.Range(2, 5);
            }
            else
            {
                current += Random.Range(1, 4);
            }

        }
            Vector3 targetDir = waypoints[current].transform.position - transform.position;
            float singleStep = speed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, singleStep, 0.0f);

            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed * speedMultiplier);
            transform.rotation = Quaternion.LookRotation(newDir);
            
        
    }
    public void NewWPInstance()
    {
        wPInstanceRunning = this;
    }
    
}
