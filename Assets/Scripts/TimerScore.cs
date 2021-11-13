using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class TimerScore : MonoBehaviour
{
    TextMeshProUGUI Timer;
    [SerializeField] int initialScore;
    private float nextChange;
    private double scoreDown = 0f;
    public int actualScore;
    void Start()
    {
        Timer = GetComponent<TextMeshProUGUI>();
        Timer.text = initialScore.ToString();
        actualScore = initialScore;
    }
    private void Update()
    {
        Timing();
    }

    public void Timing()
    {
        scoreDown += Time.deltaTime;
        if (Time.time >= nextChange && actualScore > 0)
        {
            actualScore -= (int)scoreDown;

            nextChange = Time.time + 1;
        }
        else if (actualScore <= 0)
        {
            actualScore = 0;
        }
        Timer.text = actualScore.ToString();

    }
}
