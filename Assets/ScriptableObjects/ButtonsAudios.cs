using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class ButtonsAudios : ScriptableObject
{
    [SerializeField] AudioClip ButtonGo, GenericButton1, GenericButton2, InputSelect;
    AudioSource ButtonSource;
   private void Awake()
    {
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
        ButtonSource.PlayOneShot(GenericButton2);
    }
    public void inputselectsound()
    {
        ButtonSource.PlayOneShot(InputSelect);
    }
}
