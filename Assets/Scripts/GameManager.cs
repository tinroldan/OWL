using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] inputs;
    [SerializeField] MoveInputs moveInputs;

    PlayerM player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerM>();
    }
    public void ActiveInput(GameObject input)
    {
        input.SetActive(true);
    }

    public void InstantiateInput(int input)
    {
        moveInputs.inputInstance = inputs[input];
    }

    public void GOButton()
    {
        player.GO();
    }

    public void Pause(int pause)//temporal, otro machetazo xD
    {
        Time.timeScale = pause;
    }



    private void Update()
    {
        
    }
}
