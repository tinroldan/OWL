using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu]
public class TutorialController : ScriptableObject
{
    public event UnityAction _Understand;
    

    public void HideTutorial()
    {
        _Understand?.Invoke();
    }
}
