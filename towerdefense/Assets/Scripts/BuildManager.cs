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

    public GameObject buildEffect;
    public GameObject sellEffect;

    
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
        turretToBuild = turret;
    }

    public void PurchaseMinigun()
    {
        if (GameEngine.gameInstance.SpendMoney(GameEngine.gameInstance.minigunPrice))
        {
            SetTurretToBuild(minigunPrefab);
        }
        else
        {
            Debug.Log("No Money :(");
        }

    }

    public void PurchaseZapTower()
    {
        if (GameEngine.gameInstance.SpendMoney(GameEngine.gameInstance.zapTowerPrice))
        {
            SetTurretToBuild(zapPrefab);
        }
        else
        {
            Debug.Log("No Money :(");
        }

    }

    public void PurchaseBuffTower()
    {
        if (GameEngine.gameInstance.SpendMoney(GameEngine.gameInstance.buffTowerPrice))
        {
            SetTurretToBuild(buffPrefab);
        }
        else
        {
            Debug.Log("No Money :(");
        }

    }

    public void PurchaseMissileTower()
    {
        if (GameEngine.gameInstance.SpendMoney(GameEngine.gameInstance.missileLauncherPrice))
        {
            SetTurretToBuild(missileTurretPrefab);
        }
        else
        {
            Debug.Log("No Money :(");
        }

    }

    public void PurchaseTank()
    {
        if (GameEngine.gameInstance.SpendMoney(GameEngine.gameInstance.tankPrice))
        {
            SetTurretToBuild(tank);
        }
        else
        {
            Debug.Log("No Money :(");
        }

    }
    public void PurchaseSentry()
    {
        if (GameEngine.gameInstance.SpendMoney(GameEngine.gameInstance.sentryPrice))
        {
            SetTurretToBuild(sentry);
        }
        else
        {
            Debug.Log("No Money :(");
        }

    }


}
