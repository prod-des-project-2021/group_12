using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

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
}

