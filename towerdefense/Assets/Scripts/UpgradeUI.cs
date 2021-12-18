using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public GameObject tankUI;
    private Camera cam = null;
    string turretTag;

    public GameObject turretRange;

    public GameObject selectedTower = null;

    public Text upgradeCost;
    public Text sellAmount;

    public Button upgradeButton;

    public GameObject upgradedTank;
    public GameObject upgradedMissile;
    public GameObject upgradedMinigun;
    public GameObject upgradedZap;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        TurretClicked();

        if(selectedTower !=null)
        {
            if (selectedTower.tag == "sentry")
            {
                auraTowers auraUpgrade = selectedTower.GetComponent<auraTowers>();
                turretRange.gameObject.transform.localScale = new Vector3(auraUpgrade.attackRange * 2, 0.2f, auraUpgrade.attackRange * 2);
                if(selectedTower.GetComponent<auraTowers>().auraTurretLvl < 5)
                {
                    upgradeButton.interactable = true;
                }
                else
                {
                    upgradeButton.interactable = false;
                }
            }
            else if (selectedTower.tag == "buffTower")
            {
                BuffScript buffUpgrade = selectedTower.GetComponent<BuffScript>();
                turretRange.gameObject.transform.localScale = new Vector3(buffUpgrade.buffTowerRange * 2, 0.2f, buffUpgrade.buffTowerRange * 2);

                if (selectedTower.GetComponent<BuffScript>().buffLvl < 5)
                {
                    upgradeButton.interactable = true;
                }
                else
                {
                    upgradeButton.interactable = false;
                }
            }
            else
            {
                attackEnemy upgrade = selectedTower.GetComponent<attackEnemy>();
                turretRange.gameObject.transform.localScale = new Vector3(upgrade.attackRange * 2, 0.2f, upgrade.attackRange * 2);
                if (selectedTower.GetComponent<attackEnemy>().turretLvl < 5)
                {
                    upgradeButton.interactable = true;
                }
                else
                {
                    upgradeButton.interactable = false;
                }
            }
        }
    }

    public void strongButton()
    {
        attackEnemy shootStrongest = selectedTower.GetComponent<attackEnemy>();
        shootStrongest.attackNearestEnemy = false;
        shootStrongest.attackStrongestEnemy = true;
    }

    public void nearButton()
    {
        attackEnemy shootNearest = selectedTower.GetComponent<attackEnemy>();
        shootNearest.attackStrongestEnemy = false;
        shootNearest.attackNearestEnemy = true;
    }

    //Implement this to the missile launcher and minigun
    public void TankUpgrade()
    {
        attackEnemy upgrade = selectedTower.GetComponent<attackEnemy>();
        

        if (GameEngine.gameInstance.SpendMoney(GameEngine.gameInstance.tankPrice * upgrade.turretLvl))
        {
            upgrade.turretLvl += 1;
            upgrade.fireRate += 1;
            upgrade.attackRange += 5;
            upgrade.damage += 2;
            Debug.Log("tank upgraded");
            upgradeCost.text = "<b>$" + (GameEngine.gameInstance.tankPrice * upgrade.turretLvl).ToString() + "</b>";

            if (upgrade.turretLvl == 5)
            {
                tankUI.SetActive(false);
                turretRange.SetActive(false);
                Destroy(selectedTower); 
                Instantiate(upgradedTank, selectedTower.transform.position, Quaternion.identity);
                selectedTower = null;
            }
        }

        else
        {
            Debug.Log("No enough money for upgrade :(");
        }
    }

    public void MissileUpgrade()
    {
        attackEnemy upgrade = selectedTower.GetComponent<attackEnemy>();
        

        if (GameEngine.gameInstance.SpendMoney(GameEngine.gameInstance.missileLauncherPrice * upgrade.turretLvl))
        {
            upgrade.turretLvl += 1;
            upgrade.attackRange += 5;
            upgrade.damage += 10;
            Debug.Log("missile upgraded");
            upgradeCost.text = "<b>$" + (GameEngine.gameInstance.missileLauncherPrice * upgrade.turretLvl).ToString() + "</b>";

            if (upgrade.turretLvl == 5)
            {
                tankUI.SetActive(false);
                turretRange.SetActive(false);
                Destroy(selectedTower);
                Instantiate(upgradedMissile, selectedTower.transform.position, Quaternion.identity);
                selectedTower = null;

            }
        }
        else
        {
            Debug.Log("No enough money for upgrade :(");
        }
    }

    public void MinigunUpgrade()
    {
        attackEnemy upgrade = selectedTower.GetComponent<attackEnemy>();
        
        if (GameEngine.gameInstance.SpendMoney(GameEngine.gameInstance.minigunPrice * upgrade.turretLvl))
        {
            upgrade.turretLvl += 1;
            upgrade.fireRate += 2;
            upgrade.attackRange += 5;
            //Debug.Log("trtlvl " + turretLvl);
            Debug.Log("upgraded minigun firerate " + upgrade);
            upgradeCost.text = "<b>$" + (GameEngine.gameInstance.minigunPrice * upgrade.turretLvl).ToString() + "</b>";

            if (upgrade.turretLvl == 5)
            {
                tankUI.SetActive(false);
                turretRange.SetActive(false);
                Destroy(selectedTower);
                Instantiate(upgradedMinigun, selectedTower.transform.position, Quaternion.identity);
                selectedTower = null;

            }
        }
        else
        {
            Debug.Log("No enough money for upgrade :(");
        }
    }

    public void ZapUpgrade()
    {
        attackEnemy upgrade = selectedTower.GetComponent<attackEnemy>();
        
        if (GameEngine.gameInstance.SpendMoney(GameEngine.gameInstance.zapTowerPrice * upgrade.turretLvl))
        {
            upgrade.turretLvl += 1;
            upgrade.fireRate += 1;
            upgrade.damage += 5;
            Debug.Log("upgraded zap firerate " + upgrade);
            upgradeCost.text = "<b>$" + (GameEngine.gameInstance.zapTowerPrice * upgrade.turretLvl).ToString() + "</b>";
            if (upgrade.turretLvl == 5)
            {
                tankUI.SetActive(false);
                turretRange.SetActive(false);
                Destroy(selectedTower);
                Instantiate(upgradedZap, selectedTower.transform.position, Quaternion.identity);
                selectedTower = null;
            }
        }
        else
        {
            Debug.Log("No enough money for upgrade :(");
        }
    }

    public void SentryUpgrade()
    {
        auraTowers auraUpgrade = selectedTower.GetComponent<auraTowers>();
        
        if (GameEngine.gameInstance.SpendMoney(GameEngine.gameInstance.sentryPrice * auraUpgrade.auraTurretLvl))
        {
            auraUpgrade.auraTurretLvl += 1;
            auraUpgrade.attackRange += 5;
            Debug.Log("upgraded sentry range " + auraUpgrade);
            upgradeCost.text = "<b>$" + (GameEngine.gameInstance.missileLauncherPrice * auraUpgrade.auraTurretLvl).ToString() + "</b>";

        }
        else
        {
            Debug.Log("No enough money for upgrade :(");
        }
    }

    //buff amount and range
    public void BuffUpgrade()
    {
        BuffScript buffUpgrade = selectedTower.GetComponent<BuffScript>();

        if (GameEngine.gameInstance.SpendMoney(GameEngine.gameInstance.sentryPrice * buffUpgrade.buffLvl))
        {
            buffUpgrade.damageBuffPercent += 0.1f;
            buffUpgrade.buffLvl += 1;
            Debug.Log("upgraded buff range " + buffUpgrade);
            upgradeCost.text = "<b>$" + (GameEngine.gameInstance.buffTowerPrice * buffUpgrade.buffLvl).ToString() + "</b>";

        }
        else
        {
            Debug.Log("No enough money for upgrade :(");
        }
    }

    

    public void sellTurret()
    {
        attackEnemy lvl = selectedTower.GetComponent<attackEnemy>();
        GameObject sellSound = GameObject.FindGameObjectWithTag("turretSounds");

        GameObject sellingEffect = Instantiate(BuildManager.buildInstance.sellEffect, selectedTower.transform.position, Quaternion.Euler(new Vector3(selectedTower.transform.rotation.x - 90.0f, selectedTower.transform.rotation.y, selectedTower.transform.rotation.z)));
        Destroy(sellingEffect, 2f);
        sellSound.GetComponent<sounds>().playSellingSound();

        turretTag = selectedTower.transform.tag;
        switch (turretTag)
        {
            case "Tank":
                GameEngine.gameInstance.AddMoney(GameEngine.gameInstance.tankPrice * lvl.turretLvl / 2);
                tankUI.SetActive(false);
                turretRange.SetActive(false);
                Destroy(selectedTower);
                selectedTower = null;
                break;

            case "MissileLauncher":
                GameEngine.gameInstance.AddMoney(GameEngine.gameInstance.missileLauncherPrice * lvl.turretLvl / 2);
                tankUI.SetActive(false);
                turretRange.SetActive(false);
                Destroy(selectedTower);
                selectedTower = null;
                break;

            case "ZapTower":
                GameEngine.gameInstance.AddMoney(GameEngine.gameInstance.zapTowerPrice * lvl.turretLvl / 2);
                tankUI.SetActive(false);
                turretRange.SetActive(false);
                Destroy(selectedTower);
                selectedTower = null;
                break;

            case "sentry":
                GameEngine.gameInstance.AddMoney(GameEngine.gameInstance.sentryPrice * selectedTower.GetComponent<auraTowers>().auraTurretLvl / 2);
                tankUI.SetActive(false);
                turretRange.SetActive(false);
                Destroy(selectedTower);
                selectedTower = null;
                break;

            case "Minigun":
                GameEngine.gameInstance.AddMoney(GameEngine.gameInstance.minigunPrice * lvl.turretLvl / 2);
                tankUI.SetActive(false);
                turretRange.SetActive(false);
                Destroy(selectedTower);
                selectedTower = null;
                break;

            case "buffTower":
                GameEngine.gameInstance.AddMoney(GameEngine.gameInstance.buffTowerPrice * selectedTower.GetComponent<BuffScript>().buffLvl / 2);
                tankUI.SetActive(false);
                turretRange.SetActive(false);
                Destroy(selectedTower);
                selectedTower = null;
                break;
        }
    }

    public void upgradeTurret()
    {
        attackEnemy lvl = selectedTower.GetComponent<attackEnemy>();

        turretTag = selectedTower.transform.tag;
        switch (turretTag)
        {
            case "Tank":
                TankUpgrade();
                sellAmount.text = "<b>$" + (GameEngine.gameInstance.tankPrice * lvl.turretLvl / 2).ToString() + "</b>";
                break;

            case "MissileLauncher":
                MissileUpgrade();
                sellAmount.text = "<b>$" + (GameEngine.gameInstance.missileLauncherPrice * lvl.turretLvl / 2).ToString() + "</b>";
                break;

            case "ZapTower":
                ZapUpgrade();
                sellAmount.text = "<b>$" + (GameEngine.gameInstance.zapTowerPrice * lvl.turretLvl / 2).ToString() + "</b>";
                break;

            case "sentry":
                SentryUpgrade();
                sellAmount.text = "<b>$" + (GameEngine.gameInstance.sentryPrice * selectedTower.GetComponent<auraTowers>().auraTurretLvl).ToString() + "</b>";
                break;

            case "Minigun":
                MinigunUpgrade();
                sellAmount.text = "<b>$" + (GameEngine.gameInstance.minigunPrice * lvl.turretLvl / 2).ToString() + "</b>";
                break;

            case "buffTower":
                BuffUpgrade();
                sellAmount.text = "<b>$" + (GameEngine.gameInstance.buffTowerPrice * selectedTower.GetComponent<BuffScript>().buffLvl / 2).ToString() + "</b>";
                break;

        }
    }

    public void TurretClicked()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //jos mousea painetaan turretin kohdalta n�yt� menu
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                turretTag = hit.transform.tag;
                Debug.Log("mita painetaan " + turretTag);
                switch (turretTag)
                {
                    case "Tank":
                        tankUI.SetActive(true);

                        turretRange.transform.position = hit.transform.position;
                        turretRange.SetActive(true);

                        transform.position = hit.transform.position;
                        selectedTower = hit.transform.gameObject;

                        upgradeCost.text = "<b>$" + (GameEngine.gameInstance.tankPrice * selectedTower.GetComponent<attackEnemy>().turretLvl).ToString() +"</b>";
                        sellAmount.text = "<b>$" + ((GameEngine.gameInstance.tankPrice * selectedTower.GetComponent<attackEnemy>().turretLvl) / 2).ToString() + "</b>";
                        break;

                    case "MissileLauncher":
                        tankUI.SetActive(true);

                        turretRange.transform.position = hit.transform.position;
                        turretRange.SetActive(true);

                        transform.position = hit.transform.position;
                        selectedTower = hit.transform.gameObject;

                        upgradeCost.text = "<b>$" + (GameEngine.gameInstance.missileLauncherPrice * selectedTower.GetComponent<attackEnemy>().turretLvl).ToString() + "</b>";
                        sellAmount.text = "<b>$" + ((GameEngine.gameInstance.missileLauncherPrice * selectedTower.GetComponent<attackEnemy>().turretLvl) / 2).ToString() + "</b>";
                        break;

                    case "ZapTower":
                        tankUI.SetActive(true);

                        turretRange.transform.position = hit.transform.position;
                        turretRange.SetActive(true);

                        transform.position = hit.transform.position;
                        selectedTower = hit.transform.gameObject;

                        upgradeCost.text = "<b>$" + (GameEngine.gameInstance.zapTowerPrice * selectedTower.GetComponent<attackEnemy>().turretLvl).ToString() + "</b>";
                        sellAmount.text = "<b>$" + ((GameEngine.gameInstance.zapTowerPrice * selectedTower.GetComponent<attackEnemy>().turretLvl) / 2).ToString() + "</b>";
                        break;

                    case "sentry":
                        tankUI.SetActive(true);

                        turretRange.transform.position = hit.transform.position;
                        turretRange.SetActive(true);

                        transform.position = hit.transform.position;
                        selectedTower = hit.transform.gameObject;

                        upgradeCost.text = "<b>$" + (GameEngine.gameInstance.sentryPrice * selectedTower.GetComponent<auraTowers>().auraTurretLvl).ToString() + "</b>";
                        sellAmount.text = "<b>$" + ((GameEngine.gameInstance.sentryPrice * selectedTower.GetComponent<auraTowers>().auraTurretLvl) / 2).ToString() + "</b>";
                        break;

                    case "Minigun":
                        tankUI.SetActive(true);

                        turretRange.transform.position = hit.transform.position;
                        turretRange.SetActive(true);

                        transform.position = hit.transform.position;
                        selectedTower = hit.transform.gameObject;

                        upgradeCost.text = "<b>$" + (GameEngine.gameInstance.minigunPrice * selectedTower.GetComponent<attackEnemy>().turretLvl).ToString() + "</b>";
                        sellAmount.text = "<b>$" + ((GameEngine.gameInstance.minigunPrice * selectedTower.GetComponent<attackEnemy>().turretLvl) / 2).ToString() + "</b>";
                        break;

                    case "buffTower":
                        tankUI.SetActive(true);

                        turretRange.transform.position = hit.transform.position;
                        turretRange.SetActive(true);

                        transform.position = hit.transform.position;
                        selectedTower = hit.transform.gameObject;

                        upgradeCost.text = "<b>$" + (GameEngine.gameInstance.buffTowerPrice * selectedTower.GetComponent<BuffScript>().buffLvl).ToString() + "</b>";
                        sellAmount.text = "<b>$" + ((GameEngine.gameInstance.buffTowerPrice * selectedTower.GetComponent<BuffScript>().buffLvl) / 2).ToString() + "</b>";
                        break;

                    case "Spawn area":
                        tankUI.SetActive(false);
                        turretRange.SetActive(false);
                        break;

                    case "Untagged":
                        tankUI.SetActive(false);
                        turretRange.SetActive(false);
                        break;
                }
            }
        }
    }
}