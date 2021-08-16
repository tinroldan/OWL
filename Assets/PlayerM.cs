using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerM : MonoBehaviour
{
    [Header("Player Value")]
    [SerializeField]
    float speed, jumpForce;

    float initialSpeed;

    private bool go;

    private Rigidbody2D rb2d;


    Vector2 initialPos;
    void Start()
    {
        go = false;
        initialPos = transform.position;
        initialSpeed = speed;
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

    [Header("Input Value")]
    public int input;
    public void OnInput(int input)
    {
        if (input >= 0 && input <= 6)
        {
            print("Input: " + input);

            switch (input)
            {
                case 0://jump

                    rb2d = GetComponent<Rigidbody2D>();

                    rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

                    break;

                case 1://slow

                    speed = speed / 2;
                    StartCoroutine(TimerSpeed());

                    break;

                case 2://speed

                    speed = speed * 2;
                    StartCoroutine(TimerSpeed());

                    break;

                case 3://left
                    break;

                case 4://right
                    break;

                case 5://gravity
                    break;

                case 6://dash
                    break;

                case 7://size
                    break;

            }
        }
    }

    public void OnDamage()
    {
    }

    private IEnumerator TimerSpeed()
    {
        yield return new WaitForSeconds(1.5f);

        speed = initialSpeed;
        print("return");
    }



    public void GO()
    {
        go = true;
    }
}
