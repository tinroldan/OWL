using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DragItems : MonoBehaviour
{
    bool startDrag;
    bool canDrop;
    [SerializeField]
    GameObject instatiateObject,startPos;

        CantDrop dropEfector;

    void Start()
    {
        dropEfector = GameObject.FindGameObjectWithTag("DropEfector").GetComponent<CantDrop>();

        canDrop = false;
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
