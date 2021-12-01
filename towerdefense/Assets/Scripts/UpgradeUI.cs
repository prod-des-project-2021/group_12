using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public GameObject tankUI;
    public GameObject missileUI;
    private Camera cam = null;
    int turretLvl;
    string turretTag;
   
    
    public GameObject selectedTower = null;


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

    public void TankUpgrade()
    {
        if (GameEngine.gameInstance.SpendMoney(100))
        {  
            turretLvl++;
          
            attackEnemy upgradeFirerate = selectedTower.GetComponent<attackEnemy>();
            upgradeFirerate.fireRate += 5;
            Debug.Log("turret upgraded");
            Debug.Log("trtlvl " + turretLvl);
            Debug.Log("upgraded tank fire rate " + upgradeFirerate);

            if (turretLvl >= 5)
            {
                //Destroy(selectedTower);
                //Instatiate
            }
        }
        else
        {
            Debug.Log("No enough money for upgrade :(");
        }

    }
  
    public void MissileUpgrade()
    {
        if (GameEngine.gameInstance.SpendMoney(150))
        {
            turretLvl++;
            attackEnemy upgradeFirerate = selectedTower.GetComponent<attackEnemy>();
            upgradeFirerate.fireRate += 5;
            Debug.Log("turret upgraded");
            Debug.Log("trtlvl " + turretLvl);
            Debug.Log("upgraded missilelauncher fire rate " + upgradeFirerate);

            if (turretLvl >= 5)
            {
                //Destroy(selectedTower);
                //Instatiate
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
                missileUI.SetActive(false);
                Destroy(selectedTower);
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

                switch(turretTag)
                {
                    case "Tank":
                        tankUI.SetActive(true);
                        missileUI.SetActive(false);
                        transform.position = hit.transform.position;
                        selectedTower = hit.transform.gameObject;           
                        break;

                    case "MissileLauncher":
                        missileUI.SetActive(true);
                        tankUI.SetActive(false);
                        transform.position = hit.transform.position;
                        selectedTower = hit.transform.gameObject;
                        break;

                    case "Spawn area":
                        tankUI.SetActive(false);
                        missileUI.SetActive(false);
                        break;

                    case "Untagged":
                        tankUI.SetActive(false);
                        missileUI.SetActive(false);
                        break;
                }

                Debug.Log("Open menu");
               
            }
        }
    }

}
