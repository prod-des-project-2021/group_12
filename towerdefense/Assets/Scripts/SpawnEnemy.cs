using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] spawnPoints = new GameObject[3];

    private GameObject spawnPos;
    public GameObject spawnee;

    
    

    public float maxTime = 5;
    public float minTime = 2;
    private float time;
    bool waitingSpawn = false;
    private float spawnTime;

    float timer = 0f;
    void Start()
    {
        spawnPoints[0] = GameObject.Find("Spawn");
        spawnPoints[1] = GameObject.Find("Spawn 2");
        spawnPoints[2] = GameObject.Find("Spawn 3");

    }

    // Update is called once per frame
    void Update()

    {
        
        if (timer <= 3)

    {   
        if(waitingSpawn == false)

        {
            waitingSpawn = true;
            spawnTime = Random.Range(minTime, maxTime);
        }
        else
        {

            timer = 0;
            
             Instantiate(spawnee, spawnPos.position, spawnPos.rotation);
            
          
            

            
            if (timer < spawnTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                int randSpawn = Random.Range(0,3);
                spawnPos = spawnPoints[randSpawn];
                
                waitingSpawn = false;
                timer = 0;
                Instantiate(spawnee, spawnPos.transform.position, spawnPos.transform.rotation);
            }

        }
        
        
        
            
        

    }
}
