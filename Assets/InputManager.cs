using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InputManager : MonoBehaviour
{

    public Transform player;
    [SerializeField] float maxDist;
    public float dist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();

        
    }

    public void CheckDistance()
    {
        dist = Vector2.Distance(player.position, transform.position);
        //print("Distance to player: " + dist);


        if (dist >= maxDist)
        {
            Debug.Log("player still too far");

        }
        else
        {
            Debug.Log("Player close");
        }
        print("Distance: " + dist);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, maxDist/2);
    }
}
