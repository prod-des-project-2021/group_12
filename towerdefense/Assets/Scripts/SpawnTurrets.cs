using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnTurrets : MonoBehaviour
{

    public GameObject turret = null;
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
        if (turret != null){
            turret = BuildManager.buildInstance.sentry;
            
        }
    }


    private void SpawnAtMousePos()
    {
        GameObject turretToBuild = BuildManager.buildInstance.GetTurretToBuild();
        GameObject buildingSound = GameObject.FindGameObjectWithTag("turretSounds");

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
                GameObject buildingEffect = (GameObject)Instantiate(buildManager.buildEffect, turret.transform.position, turret.transform.rotation);
                Destroy(buildingEffect, 2f);
                buildingSound.GetComponent<sounds>().playBuildingSound();
                BuildManager.buildInstance.SetTurretToBuild(null);
            }

            else
            {
                if (turretToBuild.name.Contains("Tank")) GameEngine.gameInstance.AddMoney(GameEngine.gameInstance.tankPrice);
                else if (turretToBuild.name.Contains("Minigun")) GameEngine.gameInstance.AddMoney(GameEngine.gameInstance.minigunPrice);
                else if (turretToBuild.name.Contains("MissileLauncher")) GameEngine.gameInstance.AddMoney(GameEngine.gameInstance.missileLauncherPrice);
                else if (turretToBuild.name.Contains("sentry")) GameEngine.gameInstance.AddMoney(GameEngine.gameInstance.sentryPrice);
                else if (turretToBuild.name.Contains("ZapTower")) GameEngine.gameInstance.AddMoney(GameEngine.gameInstance.zapTowerPrice);
                else if (turretToBuild.name.Contains("BuffTower")) GameEngine.gameInstance.AddMoney(GameEngine.gameInstance.buffTowerPrice);
                BuildManager.buildInstance.SetTurretToBuild(null);
            }
        }
    }

}
