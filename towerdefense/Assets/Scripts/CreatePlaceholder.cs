using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlaceholder : MonoBehaviour
{
    public GameObject placeHolder;
    private Vector3 spawnPos;
  
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = placeHolder.transform.position;

    }


    // Update is called once per frame
    void Update()
    {
        PlaceHolder();
    }

    public void PlaceHolder()
    {
        placeHolder.SetActive(true);

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            
            Vector3 newPos = hit.point;
            placeHolder.transform.position = newPos;
        }

        if(Input.GetMouseButtonDown(0))
        {
            placeHolder.SetActive(false);
            placeHolder.transform.position = spawnPos;
        }
    }
}
