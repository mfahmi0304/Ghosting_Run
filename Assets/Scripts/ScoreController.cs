using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int currentScore = 0;
    private float currentMana = 0.0f;

    private void Start()
    {
        // reset
        currentScore = 0;
    }
    public float GetCurrentScore()
    {
        return currentScore;
    }

    public void IncreaseCurrentScore(int increment)
    {
        currentScore += increment;
    }

    public void IncreaseMana(float increment)
    {
        currentMana += increment;
        Debug.Log(currentMana);
    }

    public void FinishScoring()
    {
        //set high score
        if (currentScore > ScoreData.highScore)
        {
            ScoreData.highScore = currentScore;
        }
    }
}
