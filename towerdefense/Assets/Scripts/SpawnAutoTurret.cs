using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnAutoTurret : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    public GameObject autoTurret;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("onDrag");
        
        //kirjoita if lause joka spawnaa uuden turretin ja draggaa sen kartalle
        //selvitä miten saat turretit spawnaamaan maantasalle
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnStartDrag");
        Instantiate(autoTurret);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnDown");
    }

    /*
     public void DragSpawn(PointerEventData eventData)
    {
        //transform.position = GetMousePos();
        Instantiate(autoTurret);
        autoTurret.transform.position = GetMousePos();

    }
    */

    /*
      Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
       
    }
    */
}
