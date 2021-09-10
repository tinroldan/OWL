using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    Animator anim;
    [SerializeField]
    GameObject objectMenu;
    [SerializeField]
    GameObject buttonIn, buttonOut;


    private void Start()
    {
        objectMenu.SetActive(false);
        buttonIn.SetActive(true);
        buttonOut.SetActive(false);

    }
    public void ShowMenu()
    {
        anim.SetBool("showMenu", true);
        objectMenu.SetActive(true);

        buttonIn.SetActive(false);

        buttonOut.SetActive(true);
    }

    public void HidenMenu()
    {


        anim.SetBool("showMenu", false);
        buttonIn.SetActive(true);

        buttonOut.SetActive(false);

    }

    public void OffMenu()
    {
        objectMenu.SetActive(false);

    }
}
