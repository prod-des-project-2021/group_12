using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnTurrets : MonoBehaviour
{

    public GameObject turret;
    private Camera cam = null;
    BuildManager buildManager;
    public static GameEngine spawnTurretInstance;
    


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        buildManager = BuildManager.buildInstance;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnAtMousePos();
    }


    private void SpawnAtMousePos()
    {
        GameObject turretToBuild = BuildManager.buildInstance.GetTurretToBuild();

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
                BuildManager.buildInstance.SetTurretToBuild(null);
            }

            else
            {
                Debug.Log(hit.transform.tag);
                Debug.Log("Cant spawn tower here");
            }
        }
    }

}
