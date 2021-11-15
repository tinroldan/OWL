using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    UserSate state;

    Transform player;
    [SerializeField]
    float maxDist;

    AudioSource clipSource;
    [SerializeField]
    AudioClip InputClip;

    [SerializeField]
    int input;

    [SerializeField]
    ParticleSystem Effect;

    private bool actived;

    public MoveInputs moveMe;

    [Header("Show distance")]
    public float dist;

    [SerializeField]//machetazo xD eliminar despues plis
    GameObject parent;

    public UnityEvent eventInput;

    private void Awake()
    {
        state = GameObject.FindGameObjectWithTag("userState").GetComponent<UserSate>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        if(state.music)
        {
            clipSource = GameObject.FindGameObjectWithTag("cliprec").GetComponent<AudioSource>();

        }
        else
        {
            clipSource = null;
        }
        moveMe = GameObject.FindGameObjectWithTag("Manager").GetComponent<MoveInputs>();

    }
    void Start()
    {

        actived = false;

        if (moveMe != null)
        {
            moveMe.gObject = parent.gameObject;
            //parent.transform.position = new Vector3( moveMe.touchPos.x, moveMe.touchPos.y,0);

        }
    }

    void Update()
    {
        if (!actived)
        {
            CheckDistance();

        }

    }

    public void CheckDistance()
    {
        dist = Vector2.Distance(player.position, transform.position);

        if (dist <= maxDist && player.gameObject.GetComponent<PlayerM>().go)
        {
            player.gameObject.GetComponent<PlayerM>().OnInput(input);
            eventInput?.Invoke();
            actived = true;

            if (clipSource != null)
                clipSource.PlayOneShot(InputClip);

            if (Effect != null)
            {
                Effect.Play();
            }
            
        }

    }

    public void ActiveAnim(Animator anim)
    {
        anim.SetBool("Active", true);
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, maxDist / 2);
    }
}
