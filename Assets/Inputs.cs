using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    private bool used;

    private Rigidbody2D rb2d;

    void Start()
    {
        used = false;
    }

    void Update()
    {
    }

    
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player") && !used)
        {
            rb2d = col.gameObject.GetComponent<Rigidbody2D>();

            rb2d.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);

            used = true;

        }
    }
}
