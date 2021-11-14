using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CantDrop : MonoBehaviour
{
    public GameObject ItemDrag;
    public bool canDrop;
    public Vector3 worldPosition;

    void Start()
    {
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 8.61f;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
    }
    private void OnMouseOver()
    {
        //print("can't drop");

        if (ItemDrag != null)
        {
            ItemDrag.GetComponent<Image>().color = Color.red;
            canDrop = false;

        }
    }
    private void OnMouseEnter()
    {
        
    }

    private void OnMouseExit()
    {
        //print("can drop");
        if (ItemDrag != null)
        {
            ItemDrag.GetComponent<Image>().color = Color.white;
            canDrop = true;

        }
    }
}
