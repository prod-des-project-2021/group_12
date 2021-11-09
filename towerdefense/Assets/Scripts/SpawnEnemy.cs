using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform spawnPos;
    public GameObject spawnee;
    float timer = 0f;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 3)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            Instantiate(spawnee, spawnPos.position, spawnPos.rotation);
        }
        
            
        

    }
}
