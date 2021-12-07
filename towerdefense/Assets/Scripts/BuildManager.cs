using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    
    public static BuildManager buildInstance;

   


    public GameObject minigunPrefab;
    public GameObject missileTurretPrefab;
    public GameObject tank;
    public GameObject sentry;
    public GameObject zapPrefab;
    public GameObject buffPrefab;


    private GameObject turretToBuild;
    private void Awake()
    {

        if(buildInstance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        buildInstance = this;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        //Debug.Log("noniin" +turret);
        turretToBuild = turret;
    }


    public void PurchaseMinigun()
    {
        if (GameEngine.gameInstance.SpendMoney(100))
        {
            Debug.Log("Minigun purchased");
            SetTurretToBuild(minigunPrefab);
        }
        else
        {
            Debug.Log("No Money :(");
        }

    }

    public void PurchaseZapTower()
    {
        if (GameEngine.gameInstance.SpendMoney(100))
        {
            Debug.Log("Minigun purchased");
            SetTurretToBuild(zapPrefab);
        }
        else
        {
            Debug.Log("No Money :(");
        }

    }

    public void PurchaseBuffTower()
    {
        if (GameEngine.gameInstance.SpendMoney(100))
        {
            Debug.Log("Minigun purchased");
            SetTurretToBuild(buffPrefab);
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
        Debug.Log("try tank");
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
    public void PurchaseSentry()
    {
        if (GameEngine.gameInstance.SpendMoney(100))
        {
            Debug.Log("sentry purchased");
            SetTurretToBuild(sentry);
        }
        else
        {
            Debug.Log("No Money :(");
        }

    }


}
