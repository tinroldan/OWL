using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    private bool used;


    void Start()
    {
        used = false;
    }

    void Update()
    {
    }

    
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player") && !used)
        {
            

        }
    }
}
