using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class ButtonsAudios : ScriptableObject
{
    [SerializeField] AudioClip ButtonGo, GenericButton, GenericButton2, InputSelect;
    AudioSource ButtonSource;
   private void Awake()
    {
        try
        {
            ButtonSource = GameObject.FindGameObjectWithTag("cliprec").GetComponent<AudioSource>();

        }
        catch
        {
            ButtonSource = null;
        }
    }

    public void GoButton()
    {
        if (ButtonSource != null)
            ButtonSource.PlayOneShot(ButtonGo);
    }
    public void genericButton1()
    {
        if (ButtonSource != null)
            ButtonSource.PlayOneShot(GenericButton);
    }
    public void genericButton2()
    {

        if (ButtonSource != null)
            ButtonSource.PlayOneShot(GenericButton2);
    }
    public void inputselectsound()
    {
        if (ButtonSource != null)
            ButtonSource.PlayOneShot(InputSelect);
    }
}
