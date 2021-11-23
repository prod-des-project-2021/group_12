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
<<<<<<< HEAD
    string turretTag;
    public GameObject selectedTower = null;

=======
  
>>>>>>> 079ab5470773b196818f111b0312ad24aa5701d9
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


    //Implement this to the missile launcher and minigun
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



<<<<<<< HEAD
    public void TurretClicked()
=======
    private void TurretClicked()
>>>>>>> 079ab5470773b196818f111b0312ad24aa5701d9
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
                Debug.Log("selected tower " + selectedTower);
            }
        }
    }
    
}
