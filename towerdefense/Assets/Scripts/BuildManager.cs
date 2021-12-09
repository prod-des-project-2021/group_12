using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    
    public static BuildManager buildInstance;

    [Header("Minigun")]
    public GameObject minigunPrefab;
    public int minigunCost = 50;

    [Header("Missile")]
    public GameObject missileTurretPrefab;
    public int missileCost = 150;

    [Header("Tank")]
    public GameObject tank;
    public int tankCost = 100;

    [Header("Sentry")]
    public GameObject sentry;
    public int sentryCost = 200;

    [Header("Zap")]
    public GameObject zapPrefab;
    public int zapCost = 250;

    [Header("Buff")]
    public GameObject buffPrefab;
    public int buffCost = 300;


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
        if (GameEngine.gameInstance.SpendMoney(minigunCost))
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
        if (GameEngine.gameInstance.SpendMoney(zapCost))
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
        if (GameEngine.gameInstance.SpendMoney(buffCost))
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
        if (GameEngine.gameInstance.SpendMoney(missileCost))
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
        if (GameEngine.gameInstance.SpendMoney(tankCost))
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
        if (GameEngine.gameInstance.SpendMoney(sentryCost))
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
