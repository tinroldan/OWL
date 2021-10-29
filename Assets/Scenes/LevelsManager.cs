using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    UserSate state;
    [SerializeField]
    Button[] worldsButtons;

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
    }


}
