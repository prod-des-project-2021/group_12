using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackEnemy : MonoBehaviour
{
    public List<GameObject> enemyList;
    //public Transform enemy;
    
    //public GameObject test;
    float distanceToEnemy;
    float attackRange = 100;
    
    GameObject g;


    private void OnTriggerEnter(Collider other) {
        
        
        if(other.TryGetComponent<Waypoints>(out Waypoints enemy)){
            Debug.Log("osuu!");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
     
        
    }

    // Update is called once per frame
    void Update()
    {   
        

       /* g = GameObject.FindGameObjectWithTag("mob");
        if(g != null){
            enemyList.Add(g);
             Debug.Log(enemyList.Count);
             g = null;
        }
       
        for (int i = 0; i < g.Length; i++){
         distanceToEnemy = Vector3.Distance(transform.position, g[i].transform.position);
         Debug.Log("halooooo"+ "lista "+g);
          Debug.Log(distanceToEnemy);
      if(distanceToEnemy < attackRange){
                Debug.Log("attack rangella");
                
        }}*/
       
        } 
        
    
}
