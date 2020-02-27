using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static Text scoreText;
    private static int score;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    public static void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    public static void RemoveScore()
    {
        score = 0;
        UpdateScoreText();
    }

    private static void UpdateScoreText()
    {
        scoreText.text = Convert.ToString(score);
    }
}