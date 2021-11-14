using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class TutorialAdmin : MonoBehaviour
{
    UserSate state;
    [SerializeField] int tutorialIndex;
    Scene Scene;
    [SerializeField] GameObject Tutorial;
    [SerializeField] GameObject uiComponents;


           
    //public UnityEvent eventTutorial;// 


    private void Start()
    {
        state = GameObject.FindGameObjectWithTag("userState").GetComponent<UserSate>();

        //eventTutorial?.Invoke();
        OnTutorial(tutorialIndex);
    }
    private void Update()
    {
        //Scene = SceneManager.GetActiveScene();
        
        //switch (Scene.buildIndex)
        //{
        //    case 5:
                
        //        if (state.Tutorials[0] == false && state.Tutorials[1] == false)
        //        {
        //            Tutorial.SetActive(true);
        //        }
        //        break;
          
        //}
    }
    public void SkipTuto(int index)
    {
        state.Tutorials[index] = true;
        for (int i = 0; i < state.Tutorials.Length; i++)
        {
            print("tutorial" + i + ": " + state.Tutorials[i]);
        }
        UserSateSave.Save(state);

    }
    private void OnTutorial(int index)
    {
        UserSateSave.Load(state);
        if (state.Tutorials[index])
        {
            if (Tutorial != null)
            {
                Tutorial.SetActive(false);

            }
            if (uiComponents != null)
            {

                uiComponents.SetActive(true);

            }
        }
        else
        {
            if (Tutorial != null)
            {
                Tutorial.SetActive(true);

            }
            if (uiComponents!=null)
            {
                
                    uiComponents.SetActive(false);
                
            }
        }
    }
}
