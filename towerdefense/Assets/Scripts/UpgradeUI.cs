using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class UpgradeUI : MonoBehaviour
{
    public GameObject ui;
    private Camera cam = null;
    Collider tankCollider;
    int turretLvl;
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


    //Implement this to the missile launcher and minigun
    public void Upgrade()
    {
        if (GameEngine.gameInstance.SpendMoney(100))
        {  
            turretLvl++;
            GameObject tank = selectedTower;
            attackEnemy upgradeFirerate = tank.GetComponent<attackEnemy>();
            upgradeFirerate.fireRate += 5;
            Debug.Log("turret upgraded");
            Debug.Log("trtlvl " + turretLvl);
            Debug.Log("upgraded fire rate " + upgradeFirerate);

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



    public void TurretClicked()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        

        //jos mousea painetaan turretin kohdalta näytä menu
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Tower")
            {
                //implement menu opening here 
                transform.position = hit.transform.position;
                ui.SetActive(true);
                selectedTower = hit.transform.gameObject;
                
                //Debug.Log(hit.transform.tag);
                Debug.Log("Open menu");
                Debug.Log("selected tower " + selectedTower);
            }

            else if (hit.transform.tag == "Untagged" | hit.transform.tag == "Spawn area")
            {
                //tankCollider.isTrigger = false;
                ui.SetActive(false);
            }
        }
    }

}
