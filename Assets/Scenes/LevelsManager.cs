using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelsManager : MonoBehaviour
{
    UserSate state;
    [SerializeField]
    Button[] worldsButtons;
    [SerializeField]
    TextMeshProUGUI[] worldsButtonsText;


    Color availableColor, noAvailableColor;

    private void Start()
    {
        availableColor = Color.white;
        noAvailableColor = Color.white;
        noAvailableColor.a = 0.5f;

        state = GameObject.FindGameObjectWithTag("userState").GetComponent<UserSate>();

        for (int i = 0; i < worldsButtons.Length; i++)
        {
            worldsButtons[i].interactable = false;
            worldsButtonsText[i].faceColor = noAvailableColor;

        }

        for (int i = 0; i < state.past_worlds+1; i++)
        {
            worldsButtons[i].interactable = true;
            worldsButtonsText[i].faceColor = availableColor;

        }


    }

   



}
