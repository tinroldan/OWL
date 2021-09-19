using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource BackgroundM;
    AudioSource ButtonSource;
    [SerializeField] AudioClip ButtonGo,InputSelect,GenericButton1,GenricButton2;
    void Start()
    {
        BackgroundM.Play();
        ButtonSource = GameObject.FindGameObjectWithTag("cliprec").GetComponent<AudioSource>();
    }
    public void GoButton()
    {
        ButtonSource.PlayOneShot(ButtonGo);
    }
    public void genericButton1()
    {
        ButtonSource.PlayOneShot(GenericButton1);
    }
    public void genericButton2()
    {
        ButtonSource.PlayOneShot(GenricButton2);
    }
    public void inputselectsound()
    {
        ButtonSource.PlayOneShot(InputSelect);
    }
}
