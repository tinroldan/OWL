using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerSingle : MonoBehaviour
{
    public GameObject childObject;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
