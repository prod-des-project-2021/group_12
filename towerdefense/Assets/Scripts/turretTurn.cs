using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretTurn : MonoBehaviour
{
    float turretX, turretY, turretZ;
    public float turnSpeed = 10;
    public Transform target;
    
    // Start is called before the first frame update
    
    
    private static Quaternion change(float x, float y, float z){
        Quaternion newQuat = new Quaternion();
        newQuat.Set(x,y,z,1);
        return newQuat;
    }

    void Start()
    {
    //turretX = 0;
    //turretY= 0;
    //turretZ = 0;
    
    
    }

    // Update is called once per frame
    void Update()
    {
       
         /* transform.rotation = change(0, turnSpeed, 0);
          turnSpeed++;
          if(transform.rotation.y > 179){
              transform.rotation = change(0,0,0);*/
       //transform.Rotate(turretX, turnSpeed, turretZ, Space.Self);
        transform.LookAt(target);
          
       
    }
}
