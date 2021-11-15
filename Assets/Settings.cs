using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    bool showtuto;
    int numtutorials = 7;

    UserSate state;
    [SerializeField]
    GameObject settingsPanel,uiComponents;
    GameObject audioManager;
    [SerializeField]
    TextMeshProUGUI textTutorial, textSound,textScore;
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManagerSingle>().childObject;
        settingsPanel.SetActive(false);
        state = GameObject.FindGameObjectWithTag("userState").GetComponent<UserSate>();
        UserSateSave.Load(state);
        if (state.Tutorials[numtutorials - 1])
        {
            showtuto = false;
            textTutorial.text = "Show Tutorial: No";
        }
        else
        {
            showtuto = true;
            textTutorial.text = "Show Tutorial: Yes";

        }

        for (int i = 0; i < state.Tutorials.Length; i++)
        {
            //print("tutorial " + i + ": " + state.Tutorials[i]);

        }

        if (state.music)
        {
            textSound.text = "Music: On";
            audioManager.SetActive(true);
        }
        else
        {
            textSound.text = "Music: Off";
            audioManager.SetActive(false);

        }
        SetScore();
        //int aux = numtutorials - 1;
        //print("tutorial final " + aux + "= " + state.Tutorials[numtutorials - 1]);
    }

    private void SetScore()
    {
        int auxScore =0;
        for (int i = 0; i < state.score.Length; i++)
        {
            auxScore += state.score[i];
        }
        textScore.text = "Score: " + auxScore.ToString();
    }

    public void ShowTutorial()
    {
        if (showtuto)
        {
            textTutorial.text = "Show Tutorial: No";

            showtuto = false;
            for (int i = 0; i < state.Tutorials.Length; i++)
            {
                state.Tutorials[i] = true;


            }
        }
        else
        {
            textTutorial.text = "Show Tutorial: Yes";

            showtuto = true;
            for (int i = 0; i < state.Tutorials.Length; i++)
            {
                state.Tutorials[i] = false;
                //print("tutorial " + i + ": " + state.Tutorials[i]);

            }
        }

        UserSateSave.Save(state);

    }

    public void DeletData()
    {
        state.past_worlds = 0;
        for (int i = 0; i < state.Tutorials.Length; i++)
        {
            state.Tutorials[i] = false;
            //print("tutorial " + i + ": " + state.Tutorials[i]);

        }
        textTutorial.text = "Show Tutorial: Yes";
        textSound.text = "Sound: On";
        state.music = true;
        audioManager.SetActive(true);

        for (int i = 0; i < state.score.Length; i++)
        {
            state.score[i] = 0;
        }
        SetScore();

        UserSateSave.Save(state);

    }

    public void OnMusic()
    {
        if(state.music)
        {
            textSound.text = "Sound: Off";
            state.music = false;
            audioManager.SetActive(false);
        }
        else
        {
            textSound.text = "Sound: On";
            state.music = true;
            audioManager.SetActive(true);

        }
        UserSateSave.Save(state);
    }

    public void OpenSettings()
    {
        if(settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(false);
            uiComponents.SetActive(true);
        }
        else
        {
            settingsPanel.SetActive(true);
            uiComponents.SetActive(false);

        }
    }
}
