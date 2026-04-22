using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    void OnEnable()
    {
        scoreText.text = "Score: " + ScoreManager.instance.score;

        highScoreText.text = "High Score: " +
            PlayerPrefs.GetInt("HighScore", 0);
    }
}
