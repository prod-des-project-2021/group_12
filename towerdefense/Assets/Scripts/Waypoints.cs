using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    private GameObject[] waypoints = new GameObject[4];
    int current = 0;
    float rotSpeed;
    public float speed;
    float WPradius = 1;
    // Start is called before the first frame update
    void Start()
    {
        waypoints[0] = GameObject.Find("Spawn");
        waypoints[1] = GameObject.Find("Turn 1");
        waypoints[2] = GameObject.Find("Turn 2");
        waypoints[3] = GameObject.Find("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current++;
            if(current >= waypoints.Length)
            {
                Destroy(gameObject);
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }
}
