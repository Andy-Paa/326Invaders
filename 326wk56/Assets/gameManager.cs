using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public Transform enemyRoot;
    public float speedMultiplier = 1.2f;

    private int score = 0;
    private int highScore;
    private int enemyCount;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = $"High Score: {highScore:D4}";

        enemyCount = enemyRoot.childCount;
        Enemy.OnEnemyDied += UpdateScore;
    }

    void UpdateScore(int points)
    {
        score += points;
        scoreText.text = $"Score: {score:D4}";

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = $"High Score: {highScore:D4}";
        }

        enemyCount--;
        if (enemyCount > 0)
        {
            enemyRoot.GetComponent<MoveEnemyRoot>().speed *= speedMultiplier;
        }
        else
        {
            Debug.Log("All enemies defeated!");
        }
    }

    void OnDestroy()
    {
        Enemy.OnEnemyDied -= UpdateScore;
    }
}
