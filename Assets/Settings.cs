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
    GameObject settingsPanel;
    [SerializeField]
    TextMeshProUGUI textTutorial, textSound;
    void Start()
    {
        settingsPanel.SetActive(false);
        state = GameObject.FindGameObjectWithTag("userState").GetComponent<UserSate>();

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
        //int aux = numtutorials - 1;
        //print("tutorial final " + aux + "= " + state.Tutorials[numtutorials - 1]);
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

        UserSateSave.Save(state);

    }

    public void OnMusic()
    {

    }

    public void OpenSettings()
    {
        if(settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(false);
        }
        else
        {
            settingsPanel.SetActive(true);

        }
    }
}
