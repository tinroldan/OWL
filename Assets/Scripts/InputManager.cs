using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InputManager : MonoBehaviour
{

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

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        clipSource = GameObject.FindGameObjectWithTag("cliprec").GetComponent<AudioSource>();
        moveMe = GameObject.FindGameObjectWithTag("Manager").GetComponent<MoveInputs>();

    }
    void Start()
    {
        actived = false;

        if (moveMe!=null)
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


        if (dist <= maxDist)
        {
            player.gameObject.GetComponent<PlayerM>().OnInput(input);
            actived = true;
            clipSource.PlayOneShot(InputClip);
            Effect.Play();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, maxDist / 2);
    }
}
