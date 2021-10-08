using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingToHide : MonoBehaviour
{
   [SerializeField] GameObject _ObjectToHide;
    public TutorialController _TutorialController;
    private void OnEnable()
    {
        _TutorialController._Understand += hiding; 
    }
    private void OnDisable()
    {
        _TutorialController._Understand -= hiding;
    }
    private void hiding()
    {
        _ObjectToHide.SetActive(false);
    }
}
