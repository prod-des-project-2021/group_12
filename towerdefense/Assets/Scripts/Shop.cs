using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseAutoTurret()
    {
        Debug.Log("Standard turret purchased");
        buildManager.SetTurretToBuild(buildManager.autoTurretPrefab);
    }

    public void PurchaseSniperTower()
    {
        Debug.Log("Sniper tower purchased");
        buildManager.SetTurretToBuild(buildManager.sniperTurretPrefab);
    }

}
