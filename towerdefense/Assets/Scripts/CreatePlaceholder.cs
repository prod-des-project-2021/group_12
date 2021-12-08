using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlaceholder : MonoBehaviour
{
    public GameObject placeHolder;
    private Vector3 spawnPos;

    public Component[] switchColor;

    public Color CantPlaceHere;
    private Renderer rend;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = placeHolder.transform.position;
        //rend = GetComponent<Renderer>();
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
            if (hit.transform.tag != "Spawn area")
            {
                switchColor[0].GetComponent<Renderer>().material.color = CantPlaceHere;
            }
            else 
            {
                switchColor[0].GetComponent<Renderer>().material.color = originalColor;
            }
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
