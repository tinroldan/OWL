using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource BackgroundM;
    void Start()
    {
        BackgroundM.Play();
    }


}
