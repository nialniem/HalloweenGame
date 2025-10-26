using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public TMP_Text finalScoreText;
    public GameObject startGamePanel;

    void Start()
    {
        if (startGamePanel != null)
        {
            startGamePanel.SetActive(true);
            Time.timeScale = 0f; // Pauses game at launch
        }
    }

    public void StartGame()
    {
        if (startGamePanel != null)
            startGamePanel.SetActive(false);

        Time.timeScale = 1f; // Resume game
        startGamePanel.SetActive(false);

    }

    public void EndGame()
    {
        if (endGamePanel != null)
        {
            endGamePanel.SetActive(true);
            Time.timeScale = 0f;

            Score scoreScript = FindObjectOfType<Score>();
            if (scoreScript != null)
            {
                int finalScore = scoreScript.GetScore();
                finalScoreText.text = "Final Score: " + finalScore;
            }
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
