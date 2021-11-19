using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnTurrets : MonoBehaviour
{

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


    //figure out how to click turret and spawn a upgrade menu above it
    //use tag maybe?


    private void SpawnAtMousePos()
    {
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();

        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {

            if(EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
                
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
           

            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Spawn area")
            {
                Debug.Log(hit.transform.tag);
                turret = Instantiate(turretToBuild, new Vector3(hit.point.x, hit.point.y + turret.transform.position.y, hit.point.z), Quaternion.identity);
            }

            else
            {
                Debug.Log(hit.transform.tag);
                Debug.Log("Cant spawn tower here");
            }
        }
    }

}
