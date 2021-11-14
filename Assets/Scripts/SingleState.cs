using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleState : MonoBehaviour
{
    GameObject current_state;
    [SerializeField]
    GameObject userState;

    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("userState") == null)
        {
            Instantiate(userState);
        }
    }
    void Start()
    {
        
    }

}
