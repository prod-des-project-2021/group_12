using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
  
  public class auraTowers : MonoBehaviour
{
    public string enemyTag = "mob";
    public string enemyPathFinishTag = "finishLine";
    public string enemyPathSpawnTag = "spawnLine";
    public string sentryTag = "sentry";
     public float attackRange = 100f;
     float distanceToEnemy = 0f;
  
     float shortestDistance = Mathf.Infinity;
  



  private void UpdateTarget()
  {

GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
GameObject sentry = GameObject.FindGameObjectWithTag(sentryTag);
GameObject invisEnemy = null;

foreach(GameObject enemy in enemies)
{ 
      
    
 if(enemy.name.Contains("Enemy 4(Clone)")){
     invisEnemy = enemy;
distanceToEnemy = Vector3.Distance(transform.position, invisEnemy.transform.position);

   
Debug.Log("attakcrange" +attackRange);
Debug.Log("näkymätön" +invisEnemy.GetComponent<Renderer>().enabled);
Debug.Log("shortestdistance" +distanceToEnemy);

  if(sentry != null &&  distanceToEnemy <= attackRange)
    {
       invisEnemy.GetComponent<Renderer>().enabled = true;  
                    
    }
     if(sentry != null && distanceToEnemy > attackRange){
        
       invisEnemy.GetComponent<Renderer>().enabled = false;  
    }

}
}
 
  



  }
  private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
  void Start()
    {
       
        InvokeRepeating("UpdateTarget", 0f, 0.25f);


    }
void Update(){

}

}