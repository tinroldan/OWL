using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpears : MonoBehaviour
{

    [SerializeField]
    GameObject[] spears;

    bool kill;

    private float activationTime=0.35f;

    void Start()
    {
        kill = false;
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        PlayerM player = col.GetComponent<PlayerM>();

        if (kill==true&&player!=null)
        {
            player.Perder();
        }
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
        kill = true;
    }
}
