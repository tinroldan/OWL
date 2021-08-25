using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpears : MonoBehaviour
{

    [SerializeField]
    GameObject[] spears;

    private float activationTime=0.3f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        StartCoroutine(ActivateSpears());
    }

    IEnumerator ActivateSpears()
    {
        yield return new WaitForSeconds(activationTime);

        for (int i = 0; i < spears.Length; i++)
        {
            spears[i].transform.position = new Vector3(spears[i].transform.position.x, spears[i].transform.position.y+0.8f, spears[i].transform.position.z);
        }
    }
}
