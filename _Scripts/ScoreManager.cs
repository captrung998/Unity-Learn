using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public static int remainingTime = 40;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    public static float timeMoveSpeed = 0.004f;

    [SerializeField]
    private GemFall gameFall;

    void Start()
    {
        StartCoroutine(CountdownTimer());
    }

    void Update()
    {
        scoreText.text = "Score: " + score + " | " + "Time " + remainingTime;
    }

    public static void AddScore(int amount)
    {
        score += amount;
    }

    public static void SubScore(int amount)
    {
        score -= amount;
    }

    private IEnumerator CountdownTimer()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }
        GameOver();
    }

    private void GameOver()
    {
        Time.timeScale = 0;        
        gameOverText.text = "Game Over\nScore: " + score;
        gameOverPanel.SetActive(true);
        gameFall.StopAll();
    }
}
