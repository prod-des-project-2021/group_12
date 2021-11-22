using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Waypoints wPInstanceBirth;
    public static Waypoints wPInstanceRunning;
    private GameObject[] waypoints = new GameObject[9];
    int current = 0;
    [HideInInspector] public float speed, speed2, speed3;
    [HideInInspector] public float speedMultiplier = 1.0f;
    float WPradius = 1;

    private void Awake()
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
    }
    void Start()
    {
        wPInstanceBirth = this;
        current = Random.Range(0, 3);
        speed = EnemyParams.enemyParamsInstance.speed;

        
    }

    // Update is called once per frame
    void Update()
    {


        
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            
            if (current <= 2 && current >= 0){
                current = Random.Range(3,6);
            }
            else if(current <= 5 && current <= waypoints.Length){
                current = Random.Range(6,9);
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
