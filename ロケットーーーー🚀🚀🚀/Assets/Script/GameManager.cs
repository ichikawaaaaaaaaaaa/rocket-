using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Score")]
    public TextMeshProUGUI scoreText;

    private int score;

    [Header("Game Over")]
    public int maxMissedMeteors = 5;

    private int missedCount;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateScore();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = $"SCORE : {score}";
    }

    public void MeteorHitGround()
    {
        missedCount++;

        if (missedCount >= maxMissedMeteors)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        Debug.Log("GAME OVER");
        Time.timeScale = 0;
    }
}