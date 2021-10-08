using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindSnap : MonoBehaviour
{
    public GameObject snap;
    void OnTriggerStay(Collider collider)
    {
        if(collider.tag=="Snap")
        {
            snap = collider.gameObject;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Snap")
        {
            snap = null;
        }
    }
}
