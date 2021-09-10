using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public RectTransform mainMenu;
    public GameObject botonOpen;
    
    public void OpenMenu()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.3f);
        botonOpen.gameObject.SetActive(false);
    }

    public void CloseMenu()
    {
        mainMenu.DOAnchorPos(new Vector2(0, -303), 0.3f);
        StartCoroutine(OnButton());
    }

    IEnumerator OnButton()
    {
        yield return new WaitForSeconds(0.3f);
        botonOpen.gameObject.SetActive(true);

    }
}
