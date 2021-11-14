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

    int numtutorials = 7;

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

        if(state.Tutorials[numtutorials-1])
        {
            showtuto = false;
            buttonRender.color = Color.red;
        }
        else
        {
            showtuto = true;
            buttonRender.color = Color.green;
        }

        for (int i = 0; i < state.Tutorials.Length; i++)
        {
            print("tutorial " + i + ": " + state.Tutorials[i]);

        }
        int aux = numtutorials-1;
        print("tutorial final " + aux +"= "+ state.Tutorials[numtutorials - 1]);

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



}
