using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTurrets : MonoBehaviour
{

    //figure out how to implement menu to this
    //turrets can stack fix that
    //turrets can go on the road fix that

    public GameObject turret;
    private Camera cam = null;
    BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnAtMousePos();
    }

    private void SpawnAtMousePos()
    {
        GameObject turretToBuild = BuildManager.instance.getTurretToBuild();

        if (buildManager.getTurretToBuild() == null)
            return;
        

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
               turret = Instantiate(turretToBuild, new Vector3(hit.point.x, hit.point.y + turret.transform.position.y, hit.point.z), Quaternion.identity);
            }
        }
    }

}
