using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

enum FadeTipe { Fade_in, Fade_out };

public class SimpleSceneChange : MonoBehaviour
{

    [Header("Add image if the change scene need Fade")]
    [SerializeField] Image fadeImage;

    private void Awake()
    {
        if (fadeImage != null)
        {
            fadeImage.gameObject.SetActive(true);

            StartCoroutine(FadeIN(""));

        }
        Time.timeScale = 1;

    }


    public void ChangeScene(string scene)
    {
        if (fadeImage != null)
        {
            StartCoroutine(FadeOUT(scene));

        }
        else
        {
            SceneManager.LoadScene(scene);

        }

    }

    public void CloseApp()
    {
        //if (fadeImage != null)
        //{
        //    StartCoroutine(FadeOUT("Quit"));

        //}
        //else
        //{
            Application.Quit();
        //}
    }

    public void ResetScene()
    {
        if (fadeImage != null)
        {
            StartCoroutine(FadeOUT(SceneManager.GetActiveScene().name));

        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }



    }

    IEnumerator FadeIN(string scene)
    {
        fadeImage.gameObject.SetActive(true);

        for (float f = 1.1f; f >= 0; f -= 0.02f)
        {
            Color c = fadeImage.color;
            c.a = f;
            fadeImage.color = c;
            yield return null;
        }

    }






    IEnumerator FadeOUT(string scene)
    {
        fadeImage.gameObject.SetActive(true);


        for (float f = 0f; f <= 1.1; f += 0.02f)
        {
            Color c = fadeImage.color;
            c.a = f;
            fadeImage.color = c;
            yield return null;
        }

        if (!string.IsNullOrEmpty(scene))
        {
            SceneManager.LoadScene(scene);
            yield return null;
        }
        else if (scene == "Quit")
        {
            Application.Quit();
            yield return null;
        }



    }
}
