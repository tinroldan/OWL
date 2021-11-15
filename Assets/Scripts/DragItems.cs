using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public enum InputItems
{
    jump,
    speed,
    slow,
    mirror,
    size,

}

public class DragItems : MonoBehaviour
{
    [SerializeField]
    InputItems m_SelectInput;
    [SerializeField]
    GameObject[] available_inputs;
    [SerializeField]
    Sprite[] available_inputs_image;
    bool startDrag;
    [SerializeField]
    GameObject instatiateObject,startPos;

        CantDrop dropEfector;

    void Start()
    {
        int indexInput = Array.IndexOf(Enum.GetValues(m_SelectInput.GetType()), m_SelectInput);
        instatiateObject = available_inputs[indexInput];
        this.gameObject.GetComponent<Image>().sprite = available_inputs_image[indexInput];
        print(indexInput);

        dropEfector = GameObject.FindGameObjectWithTag("DropEfector").GetComponent<CantDrop>();
    }

    void Update()
    {
      

        if (startDrag)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void StartDragUI()
    {
        startDrag = true;
        dropEfector.ItemDrag = this.gameObject;
    }


    public void StopDragUI()
    {
        dropEfector.ItemDrag = null;

        startDrag = false;
        if (dropEfector.canDrop)
        {
            //instatiateObject.SetActive(true);
            Vector3 instantiatePos = new Vector3(dropEfector.worldPosition.x, dropEfector.worldPosition.y, 0);
            Instantiate(instatiateObject, instantiatePos, instatiateObject.transform.rotation);
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            transform.position = startPos.transform.position;
            this.gameObject.GetComponent<Image>().color = Color.white;

            //transform.position = new Vector3(transform.parent.position.x - transform.parent.localScale.x / 2, transform.parent.position.y);
        }

    }
}
