using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class TimerScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textScore;
    [SerializeField] int initialScore,levelIndex;
    public int score;
    float scoreFloat;
    public bool levelEnd;
    UserSate state;
    private void Start()
    {
        state = GameObject.FindGameObjectWithTag("userState").GetComponent<UserSate>();
        score = initialScore;
        scoreFloat = initialScore;
        levelEnd = false;
    }

    private void Update()
    {
        if(levelEnd==false)
        {
            if(scoreFloat > 0)
            {
                scoreFloat -= Time.deltaTime;
                

            }
            else
            {
                levelEnd = true;
                if(scoreFloat<0)
                {
                    score = 0;
                }
                else
                {
                    score = (int)scoreFloat;

                }
            }
            textScore.text = "Score: " + scoreFloat.ToString("f0");
        }
        else
        {
            if (scoreFloat < 0)
            {
                score = 0;
            }
            else
            {
                score = (int)scoreFloat;
                //print(score);
            }
        }
        
    }

    public void SetScore()
    {
        if (levelIndex>0)
        {
            if (scoreFloat < 0)
            {
                score = 0;
            }
            else
            {
                score = (int)scoreFloat;
                //print(score);
            }
            if(score> state.score[levelIndex - 1])
            {
                state.score[levelIndex - 1] = score;
            }
            print("score in this level was: " + state.score[levelIndex - 1]);
        }

        UserSateSave.Save(state);
    }
    


}

//{
////TextMeshProUGUI Timer;
////[SerializeField] int initialScore;
////private float nextChange;
////private double scoreDown = 0f;
////public int actualScore;
////void Start()
////{
////    Timer = GetComponent<TextMeshProUGUI>();
////    Timer.text = initialScore.ToString();
////    actualScore = initialScore;
////}
////private void Update()
////{
////    //Timing();
////}

////public void Timing()
////{
////    scoreDown += Time.deltaTime;
////    if (Time.time >= nextChange && actualScore > 0)
////    {
////        actualScore -= (int)scoreDown;

////        nextChange = Time.time + 1;
////    }
////    else if (actualScore <= 0)
////    {
////        actualScore = 0;
////    }
////    Timer.text = actualScore.ToString();

////}
//}
