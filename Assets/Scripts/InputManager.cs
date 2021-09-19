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

    private bool actived;


    [Header("Show distance")]
    public float dist;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        clipSource = GameObject.FindGameObjectWithTag("cliprec").GetComponent<AudioSource>();

    }
    void Start()
    {
        actived = false;
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
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, maxDist / 2);
    }
}
