using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        Debug.Log("picked up coin.");
    }
}
