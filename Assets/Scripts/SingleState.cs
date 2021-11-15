using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleState : MonoBehaviour
{
    [SerializeField]
    GameObject userState, audioManager;

    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("userState") == null)
        {
            Instantiate(userState);
        }

        if (GameObject.FindGameObjectWithTag("AudioManager") == null)
        {
            Instantiate(audioManager);
        }
    }
    void Start()
    {
        
    }

}
