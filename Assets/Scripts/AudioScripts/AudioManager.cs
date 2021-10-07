using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource BackgroundM;
    AudioSource ButtonSource;
    Scene scene;
    private bool AlreadyExist = false;
    [SerializeField] AudioClip ButtonGo, InputSelect, GenericButton1, GenricButton2, World1, World2, World3, World4;
    void Start()
    {
        BackgroundM.Play();
        ButtonSource = GameObject.FindGameObjectWithTag("cliprec").GetComponent<AudioSource>();
        
        if (GameObject.FindGameObjectsWithTag("Manager").Length < 2 && AlreadyExist == false)
        {
            DontDestroyOnLoad(gameObject);
            AlreadyExist = true;
        }
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
    private void Update()
    {
        scene = SceneManager.GetActiveScene();
        switch(scene.name)
        {
            case "1-1":
                BackgroundM.clip = World1;
                if (BackgroundM.isPlaying == false)
                {
                    BackgroundM.Play();
                }
                break;
            case "2-1":
                BackgroundM.clip = World2;
                if (BackgroundM.isPlaying == false)
                {
                    BackgroundM.Play();
                }
                break;
            case "3-1":
                BackgroundM.clip = World3;
                if (BackgroundM.isPlaying == false)
                {
                    BackgroundM.Play();
                }
                break;
            case "4-1":
                BackgroundM.clip = World4;
                if (BackgroundM.isPlaying == false)
                {
                    BackgroundM.Play();
                }
                break;
        }
    }
}
