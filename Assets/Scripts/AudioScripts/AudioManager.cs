using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource BackgroundM;
    AudioSource ButtonSource;
    [SerializeField] AudioClip ButtonGo;
    void Start()
    {
        BackgroundM.Play();
        ButtonSource = GameObject.FindGameObjectWithTag("cliprec").GetComponent<AudioSource>();
    }
    public void GoButton()
    {
        ButtonSource.PlayOneShot(ButtonGo);
    }

}
