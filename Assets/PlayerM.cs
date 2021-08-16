﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerM : MonoBehaviour
{
    [Header("Player Value")]
    [SerializeField]
    float speed;

    private bool go;

    Vector2 initialPos;
    void Start()
    {
        go = false;
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            transform.position += new Vector3(1, 0, 0) * (Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("cheese"))
        {
            go = false;
        }

        if (col.CompareTag("fire"))
        {
            transform.position = initialPos;
            go = false;
        }
    }

    public void OnInput(int input)
    {
        switch (input)
        {
            case 0:
                break;

            case 1:
                break;

            case 2:
                break;

            case 3:
                break;

            case 4:
                break;

            case 5:
                break;


        }
    }
    


    public void GO()
    {
        go = true;
    }
}
