using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public GameObject tankUI;
    private Camera cam = null;
    string turretTag;
    public GameObject upgradedTank;
    public GameObject turretRange;

    public GameObject selectedTower = null;

    public Text upgradeCost;
    public Text sellAmount;

    int cost = 50;

    //public static UpgradeUI instance;

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
            attackEnemy upgrade = selectedTower.GetComponent<attackEnemy>();
            turretRange.gameObject.transform.localScale = new Vector3(upgrade.attackRange * 2, 0.2f, upgrade.attackRange * 2);
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
        upgrade.turretLvl += 1;

        if (GameEngine.gameInstance.SpendMoney((cost / 2) * upgrade.turretLvl))
        {
            upgrade.fireRate += 5;
            upgrade.attackRange += 25;
            Debug.Log("turret upgraded");
            Debug.Log("trtlvl " + upgrade.turretLvl);
            Debug.Log("upgraded tank fire rate " + upgrade.fireRate);

            if (upgrade.turretLvl == 5)
            {
                Destroy(selectedTower);
                Instantiate(upgradedTank, selectedTower.transform.position, Quaternion.identity);
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
        upgrade.turretLvl += 1;

        if (GameEngine.gameInstance.SpendMoney(cost))
        {
            upgrade.fireRate += 5;
            upgrade.attackRange += 25;
            Debug.Log("turret upgraded");
            //Debug.Log("trtlvl " + turretLvl);
            Debug.Log("upgraded missilelauncher fire rate " + upgrade);

            if (upgrade.turretLvl == 5)
            {
                Destroy(selectedTower);

            }
        }
        else
        {
            Debug.Log("No enough money for upgrade :(");
        }
    }

    public void sellTurret()
    {
        turretTag = selectedTower.transform.tag;
        switch (turretTag)
        {
            case "Tank":
                Debug.Log("tank sell" + selectedTower);
                GameEngine.gameInstance.AddMoney(50);
                tankUI.SetActive(false);
                Destroy(selectedTower);
                break;

            case "MissileLauncher":
                GameEngine.gameInstance.AddMoney(100);
                //missileUI.SetActive(false);
                Destroy(selectedTower);
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
                upgradeCost.text = "<b>$" + ((cost / 2) * lvl.turretLvl).ToString() + "</b>";
                break;

            case "MissileLauncher":
                MissileUpgrade();
                upgradeCost.text = "<b>$" + (cost * lvl.turretLvl).ToString() + "</b>";
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

                switch (turretTag)
                {
                    case "Tank":
                        tankUI.SetActive(true);

                        turretRange.transform.position = hit.transform.position;
                        turretRange.SetActive(true);

                        transform.position = hit.transform.position;
                        selectedTower = hit.transform.gameObject;

                        upgradeCost.text = "<b>$" + ((cost / 2) * selectedTower.GetComponent<attackEnemy>().turretLvl).ToString() +"</b>";
                        sellAmount.text = "<b>$" + (cost / 2).ToString() + "</b>";
                        break;

                    case "MissileLauncher":
                        tankUI.SetActive(true);

                        turretRange.transform.position = hit.transform.position;
                        turretRange.SetActive(true);

                        transform.position = hit.transform.position;
                        selectedTower = hit.transform.gameObject;

                        upgradeCost.text = "<b>$" + (cost * selectedTower.GetComponent<attackEnemy>().turretLvl).ToString() + "</b>";
                        sellAmount.text = "<b>$" + (cost / 2).ToString() + "</b>";
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