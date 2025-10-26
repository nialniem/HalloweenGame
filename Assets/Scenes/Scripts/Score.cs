using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{

    public Text scoreText;
    public GameObject attackObject; // Assign this in the Inspector
    private Enemy attackScript;

    int score = 0;

    void Start()
    {
        attackScript = attackObject.GetComponent<Enemy>();

        scoreText.text = score.ToString() + " POINTS";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddPoints(int amount)
    {
        score += amount;
        scoreText.text = score.ToString() + " POINTS";
    }
}
