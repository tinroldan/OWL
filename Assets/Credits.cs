using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] GameObject[] ui_components;
    [SerializeField] GameObject credits;
    [SerializeField] Animator anim;
    public void ShowCredits()
    {
        credits.SetActive(true);
        for (int i = 0; i < ui_components.Length; i++)
        {
            ui_components[i].SetActive(false);
        }
        anim.SetBool("credits", true);
    }

    public void HideCredits()
    {
        for (int i = 0; i < ui_components.Length; i++)
        {
            ui_components[i].SetActive(true);
        }
        credits.SetActive(false);
        anim.SetBool("credits", false);

    }
}
