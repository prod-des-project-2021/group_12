using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] spawnPoints = new GameObject[3];

    private GameObject spawnPos;

    public GameObject[] spawnee = new GameObject[3];
    public float maxTime = 2f;
    public float minTime = 0.2f;


    private float time;
    
    private float spawnTime;

    float timer = 0f;

    private float timeBetweenWaves = 1.0f;
    public float difficulty = 1.0f;
    public int level = 1;
    private int enemiesPerLevel = 5;
    bool roundRunning = false;



    void Start()
    {
        spawnPoints[0] = GameObject.Find("Spawn");
        spawnPoints[1] = GameObject.Find("Spawn 2");
        spawnPoints[2] = GameObject.Find("Spawn 3");

    }

    // Update is called once per frame
    void Update()
    {

        if(!roundRunning)

        {
            roundRunning = true;
            StartCoroutine(SpawnWave());
        }          
           
               
                   
    }

    IEnumerator SpawnWave()
    {
        enemiesPerLevel = enemiesPerLevel + level * 2;
        Debug.Log("enemies: " +enemiesPerLevel);
        Debug.Log("level: "+level);
        for (int i = 0; i < enemiesPerLevel; i++)
        {

            SpawnSingleEnemy();
            yield return new WaitForSeconds(1.0f);

        }
        yield return new WaitForSeconds(timeBetweenWaves);
        level += 1;
        roundRunning = false;
        
    }

    void SpawnSingleEnemy()
    {
        int randSpawn = Random.Range(0, 3);
        spawnPos = spawnPoints[randSpawn];

        timer = 0;
        Instantiate(spawnee[0], spawnPos.transform.position, spawnPos.transform.rotation);
        //Instantiate(spawnee[1], spawnPos.transform.position, spawnPos.transform.rotation);
        //Instantiate(spawnee[2], spawnPos.transform.position, spawnPos.transform.rotation);

    }

}
