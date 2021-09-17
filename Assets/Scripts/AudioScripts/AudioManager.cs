using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    [SerializeField]AudioSource BackGroundMusic;
    void Start()
    {
         BackGroundMusic.Play();
    }

   
}
