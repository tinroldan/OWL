using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerM : MonoBehaviour
{
    [SerializeField] AudioClip WinClip, LoseClip;
    [Header("Player Value")]
    public float speed, jumpForce;
    
    private AudioSource playerSource;
    public float initialSpeed;

    public bool go;

    private Rigidbody2D rb2d;

    [SerializeField]
    Animator anim;

    [SerializeField]
    GameObject menuF, menuW;

    [Header("Player VFX")]
    [SerializeField] ParticleSystem speedPS;
    [SerializeField] ParticleSystem SlowPS;
    [SerializeField] ParticleSystem SizeUpPS;
    [SerializeField] ParticleSystem DirRightPS;
    [SerializeField] ParticleSystem DirLeftPS;

    Vector3 initialPos;
    Vector3 initialScale;

    [SerializeField]
    int indexWorld;
    [SerializeField]
    bool finalLevel=false;

    [SerializeField] GameObject shadow;

    UserSate state;

    TimerScore score;
    void Start()
    {
        state = GameObject.FindGameObjectWithTag("userState").GetComponent<UserSate>();
        score = GameObject.FindGameObjectWithTag("UiElements").GetComponent<TimerScore>();
        playerSource = GetComponent<AudioSource>();
        anim.SetBool("Walk", false);
        go = false;
        initialPos = transform.position;
        initialSpeed = speed;
        initialScale = this.gameObject.transform.localScale;

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
        score.levelEnd = true;

        menuW.SetActive(true);
        Time.timeScale = 0;

        if(finalLevel==true&&indexWorld> state.past_worlds)
        {
            state.past_worlds = indexWorld;
            UserSateSave.Save(state);
        }

        score.SetScore();

        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("Jump", false);

            shadow.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("cheese"))
        {

            Ganar();

            if (state.music)
                playerSource.PlayOneShot(WinClip);
        }

        if (col.CompareTag("fire"))
        {
            Perder();
            //go = false;
            //anim.SetBool("Walk", false);
            //SceneManager.LoadScene("Main");

            if (state.music)
                playerSource.PlayOneShot(LoseClip);

        }
    }

    [Header("Input Value")]
    public int input;
    public void OnInput(int input)
    {
        if (input >= 0 && input <= 7)
        {
            print("Input: " + input);

            switch (input)
            {
                case 0://jump

                    rb2d = GetComponent<Rigidbody2D>();
                    shadow.SetActive(false);
                    anim.SetBool("Jump", true);

                    if (speed<=2&&speed>=-2)
                    {
                        rb2d.AddForce(new Vector2(0, jumpForce*2), ForceMode2D.Impulse);

                    }
                    else
                    {
                        rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

                    }

                    break;

                case 1://slow

                    speed = speed / 2;
                    if (SlowPS != null)
                    {
                        SlowPS.Play();
                    }                    
                    StartCoroutine(TimerSpeed(2.5f));

                    break;

                case 2://speed

                    speed = speed * 2;
                    if (speedPS != null)
                    {
                        speedPS.Play();
                    }                   
                    StartCoroutine(TimerSpeed(1.5f));

                    break;

                case 3://left
                    speed = speed * -1;
                    initialSpeed = speed;
                    this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x * -1, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);                    
                    if (initialSpeed<0)
                    {
                        DirLeftPS.Play();
                    }
                    else
                    {
                        DirRightPS.Play();

                    }
                    break;

                case 4://right
                    break;

                case 5://gravity
                    break;

                case 6://dash
                    break;

                case 7://size

                    gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x / 2, gameObject.transform.localScale.y / 2,gameObject.transform.localScale.z / 2);
                    StartCoroutine(TimerSize());
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

    private IEnumerator TimerSize()
    {
        yield return new WaitForSeconds(2f);

        if(gameObject.transform.localScale.x<0)
        {
            initialScale.x = initialScale.x * -1;
        }

        gameObject.transform.localScale = initialScale;
        SizeUpPS.Play();
        print("return scale");
    }



    public void GO()
    {
        go = true;
        anim.SetBool("Walk", true);

    }
}
