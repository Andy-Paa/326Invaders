using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public Transform enemyRoot;
    public float speedMultiplier = 1.2f;
    public TextMeshProUGUI winText;

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
        AudioManager.instance.PlayScoreSound();
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
            winText.gameObject.SetActive(true);
            StartCoroutine(LoadSceneAfterDelay(3f));
        }
    }

    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("cre");
    }

    void OnDestroy()
    {
        Enemy.OnEnemyDied -= UpdateScore;
    }
}
