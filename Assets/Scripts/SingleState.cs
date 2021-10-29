using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleState : MonoBehaviour
{
    GameObject current_state;
    [SerializeField]
    GameObject userState;
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("userState") == null)
        {
            Instantiate(userState);
        }
    }

}
