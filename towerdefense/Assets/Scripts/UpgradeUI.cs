using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class UpgradeUI : MonoBehaviour
{
    public GameObject ui;
    private Camera cam = null;

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

    public void Upgrade()
    {
        Debug.Log("hello upgrade");
    }


    private void TurretClicked()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        

        //jos mousea painetaan turretin kohdalta näytä menu
        if (Input.GetMouseButtonDown(0))
        {
            //do upgrade to one tower first and then do the rest....
            //SUBSTITUTE THIS FOR SWITCH/CASE BECAUSE WE WILL ADD MORE TAGS FOR TOWERS
            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Tower")
            {
                //implement menu opening here 
                transform.position = hit.transform.position;
                ui.SetActive(true);
                
                //Debug.Log(hit.transform.tag);
                Debug.Log("Open menu");
            }

            //try to use canvas raycast tag for this
            //Fix the menu closing when trying to interact with it
            else if (hit.transform.tag == "Untagged" | hit.transform.tag == "Spawn area")
            {
                ui.SetActive(false);
            }
        }
    }

}
