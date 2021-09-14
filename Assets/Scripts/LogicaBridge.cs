using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LogicaBridge : MonoBehaviour
{
    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    if(col.tag=="")
    //    StartCoroutine(BridgeOFF());
    //}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && col.gameObject.GetComponent<PlayerM>().speed > (col.gameObject.GetComponent<PlayerM>().initialSpeed / 2))
        {
            StartCoroutine(BridgeOFF());
        }
    }

    IEnumerator BridgeOFF()
    {
        yield return new WaitForSeconds(0.15f);
        //avctivar animacion aqui :3
        this.gameObject.SetActive(false);
    }
}
