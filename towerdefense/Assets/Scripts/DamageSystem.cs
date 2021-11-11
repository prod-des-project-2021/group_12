using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
           Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        DamageEnemy(50);
        

    }

    public void DamageEnemy(int damageAmount)
    {
        health -= damageAmount;
    }

}
