using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerM : MonoBehaviour
{
    [Header("Player Value")]
    public float speed, jumpForce;

    public float initialSpeed;

    private bool go;

    private Rigidbody2D rb2d;

    [SerializeField]
    Animator anim;

    [SerializeField]
    GameObject menuF, menuW;


    Vector3 initialPos;
    void Start()
    {
        anim.SetBool("Walk", false);
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

    //public void Restart()//esto es mero machetazo xD
    //{
    //    transform.position = initialPos;

    //    go = false;
    //    anim.SetBool("Walk", false);
    //    SceneManager.LoadScene("Main");
    //    Time.timeScale = 1;

    //}

    public void Perder()//esto es otro machetazzo xD
    {
        menuF.SetActive(true);
        Time.timeScale = 0;
    }
    public void Ganar()//esto es otro machetazzo xD
    {
        menuW.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("cheese"))
        {

            Ganar();
        }

        if (col.CompareTag("fire"))
        {
            Perder();
            //go = false;
            //anim.SetBool("Walk", false);
            //SceneManager.LoadScene("Main");


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
                    StartCoroutine(TimerSpeed(2.5f));

                    break;

                case 2://speed

                    speed = speed * 2;
                    StartCoroutine(TimerSpeed(1.5f));

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

    private IEnumerator TimerSpeed(float returnSpeed)
    {
        yield return new WaitForSeconds(returnSpeed);

        speed = initialSpeed;
        //print("return");
    }



    public void GO()
    {
        go = true;
        anim.SetBool("Walk", true);

    }
}
