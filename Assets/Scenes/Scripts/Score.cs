using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{

    public Text scoreText;
    public GameObject attackObject; // Assign this in the Inspector
    

    int score = 0;

    void Start()
    {
        

        scoreText.text = score.ToString() + " POINTS";

    }

    public int GetScore()
    {
        return score;
    }
    public void AddPoints(int amount)
    {
        score += amount;
        scoreText.text = score.ToString() + " POINTS";
    }
}
