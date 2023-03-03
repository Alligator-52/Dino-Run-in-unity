using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator playerAnimator;

    [Header("UI")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject newHsPanel;
    [SerializeField] private GameObject buttonPanel;
    [SerializeField] private GameObject instructionsPanel;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI hScoreText;

    private float score;
    private float scoreIncreaser = 6;
    private float highScore = 0;
    private float multiplier = 1f;

    private void Start()
    {
        score = 0f;
        highScore = PlayerPrefs.GetFloat("HighScore");
        hScoreText.text = highScore.ToString();
        multiplier = 1f;
        gameOverPanel.SetActive(false);
        buttonPanel.SetActive(true);
        instructionsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void FixedUpdate()
    {
        if(Time.timeScale == 1f)
        {
            score = (int)(scoreIncreaser * multiplier);
            scoreText.text = score.ToString();
            multiplier += (float)0.05;
            if (score >= highScore)
            {
                PlayerPrefs.SetFloat("HighScore", score);
                //hScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString();
                newHsPanel.SetActive(true);
            }
        }
        
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        playerAnimator.SetBool("isRunning", false);
        gameOverPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ClickAnywhere()
    {
        Time.timeScale = 1f;
        buttonPanel.SetActive(false);
        playerAnimator.SetBool("isRunning", true);
        instructionsPanel.SetActive(false);

    }


}
