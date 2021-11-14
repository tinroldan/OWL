using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    UserSate state;
    [SerializeField]
    Button[] worldsButtons;
    [SerializeField]
    Image buttonRender;
    private void Start()
    {
        state = GameObject.FindGameObjectWithTag("userState").GetComponent<UserSate>();

        for (int i = 0; i < worldsButtons.Length; i++)
        {
            worldsButtons[i].interactable = false;
        }

        for (int i = 0; i < state.past_worlds+1; i++)
        {
            worldsButtons[i].interactable = true;
        }

        if(state.Tutorials[state.Tutorials.Length-1])
        {
            showtuto = false;
            buttonRender.color = Color.red;
        }
        else
        {
            showtuto = true;
            buttonRender.color = Color.green;
        }
    }

    bool showtuto;
    public void ShowTutorial()
    {
        if(showtuto)
        {
            buttonRender.color = Color.red;
            showtuto = false;
            for (int i = 0; i < state.Tutorials.Length; i++)
            {
                state.Tutorials[i] = true;
                //print("tutorial " + i + ": " + state.Tutorials[i]);

            }
        }
        else
        {
            buttonRender.color = Color.green;
            showtuto = true;
            for (int i = 0; i < state.Tutorials.Length; i++)
            {
                state.Tutorials[i] = false;
                //print("tutorial " + i + ": " + state.Tutorials[i]);

            }
        }

        UserSateSave.Save(state);

    }



}
