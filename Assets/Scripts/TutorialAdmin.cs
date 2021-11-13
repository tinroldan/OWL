using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialAdmin : MonoBehaviour
{
    [SerializeField] UserSate state;
    [SerializeField] int tutorialIndex;
    Scene Scene;
    [SerializeField] GameObject[] Tutoriales = new GameObject[8];

    private void Start()
    {
        OnTutorial(tutorialIndex);
    }
    private void Update()
    {
        Scene = SceneManager.GetActiveScene();
        
        switch (Scene.buildIndex)
        {
            case 5:
                
                if (state.Tutorials[0] == false && state.Tutorials[1] == false)
                {
                    Tutoriales[0].SetActive(true);
                }
                break;
          


        }
    }
    public void SkipTuto(int index)
    {
        state.Tutorials[index] = true;
        UserSateSave.Save(state);
        for (int i = 0; i < state.Tutorials.Length; i++)
        {
            print("tutorial" + i + ": " + state.Tutorials[i]);
        }
    }
    private void OnTutorial(int index)
    {
        UserSateSave.Load(state);
        if (state.Tutorials[index])
        {
            Tutoriales[index].SetActive(false);
        }
        else
        {
            Tutoriales[index].SetActive(true);
        }
    }
}
