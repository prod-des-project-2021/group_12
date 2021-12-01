using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    
    public static BuildManager buildInstance;

    private void Awake()
    {

        if(buildInstance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        buildInstance = this;
    }


    public GameObject autoTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject tank;

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }


    public void PurchaseAutoTurret()
    {
        if (GameEngine.gameInstance.SpendMoney(100))
        {
            Debug.Log("Standard turret purchased");
            SetTurretToBuild(autoTurretPrefab);
        }
        else
        {
            Debug.Log("No Money :(");
        }

    }

    public void PurchaseMissileTower()
    {
        if (GameEngine.gameInstance.SpendMoney(100))
        {
            Debug.Log("Missile launcher purchased");
            SetTurretToBuild(missileTurretPrefab);
        }
        else
        {
            Debug.Log("No Money :(");
        }

    }

    public void PurchaseTank()
    {
        if (GameEngine.gameInstance.SpendMoney(100))
        {
            Debug.Log("tank purchased");
            SetTurretToBuild(tank);
        }
        else
        {
            Debug.Log("No Money :(");
        }

    }


}
