using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSateSave : MonoBehaviour
{
   public static void Save(MonoBehaviour componente)
    {
        Debug.Log(JsonUtility.ToJson(componente));

        PlayerPrefs.SetString("userState", JsonUtility.ToJson(componente));
    }

    public static void Load(MonoBehaviour componente)
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("userState"), componente);
    }
}
