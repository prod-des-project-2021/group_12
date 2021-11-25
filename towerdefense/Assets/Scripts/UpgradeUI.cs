using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public GameObject ui;
    private Camera cam = null;
    Collider tankCollider;
    int turretLvl;
  
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


    //fix bug where all upgrades go to one turret
    public void Upgrade()
    {
        if (GameEngine.gameInstance.SpendMoney(100))
        {  
            turretLvl++;
            GameObject tank = GameObject.Find("tankTower");
            attackEnemy upgradeFirerate = tank.GetComponent<attackEnemy>();
            upgradeFirerate.fireRate += 5;
            Debug.Log("turret upgraded");
            Debug.Log("trtlvl " + turretLvl);
            Debug.Log("upgraded fire rate " + upgradeFirerate);

            if (turretLvl >= 5)
            {
                //Destroy(turret);
            }
        }
        else
        {
            Debug.Log("No Money :(");
        }

    }




    private void TurretClicked()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        

        //jos mousea painetaan turretin kohdalta n�yt� menu
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Tower")
            {
                //implement menu opening here 
                transform.position = hit.transform.position;
                ui.SetActive(true);
                
                
                //Debug.Log(hit.transform.tag);
                Debug.Log("Open menu");
            }

            else if (hit.transform.tag == "Untagged" | hit.transform.tag == "Spawn area")
            {
                tankCollider.isTrigger = false;
                ui.SetActive(false);
            }
        }
    }
    
}
