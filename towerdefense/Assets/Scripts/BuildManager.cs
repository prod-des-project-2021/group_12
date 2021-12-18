using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Text minigunCost, missileCost, tankCost, sentryCost, zapCost, buffCost;

    private void Awake()
    {

        if(buildInstance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        buildInstance = this;
    }

    private void Start()
    {
        minigunCost.text = "$ " +  GameEngine.gameInstance.minigunPrice.ToString();
        missileCost.text = "$ " + GameEngine.gameInstance.missileLauncherPrice.ToString();
        tankCost.text = "$ " + GameEngine.gameInstance.tankPrice.ToString();
        sentryCost.text = "$ " + GameEngine.gameInstance.sentryPrice.ToString();
        zapCost.text = "$ " + GameEngine.gameInstance.zapTowerPrice.ToString();
        buffCost.text = "$ " + GameEngine.gameInstance.buffTowerPrice.ToString();
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
