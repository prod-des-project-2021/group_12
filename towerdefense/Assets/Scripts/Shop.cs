using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.buildInstance;
    }

    public void PurchaseAutoTurret()
    {
        if (GameEngine.gameInstance.SpendMoney(100))
        {
            Debug.Log("Standard turret purchased");
            buildManager.SetTurretToBuild(buildManager.autoTurretPrefab);
        }
        else
        {
            Debug.Log("No Money :(");
        }
        
    }

    public void PurchaseSniperTower()
    {
        if (GameEngine.gameInstance.SpendMoney(100))
        {
            Debug.Log("Sniper tower purchased");
            buildManager.SetTurretToBuild(buildManager.sniperTurretPrefab);
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
            buildManager.SetTurretToBuild(buildManager.tank);
        }
        else
        {
            Debug.Log("No Money :(");
        }
            
    }

}
