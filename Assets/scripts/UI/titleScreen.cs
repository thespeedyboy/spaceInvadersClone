using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class titleScreen : MonoBehaviour
{
    public TMP_Text highScoreText;
    void Start()
    {
        highScoreText.text = "High Score: " +
            PlayerPrefs.GetInt("HighScore", 0);
    }
    private void Update()
    {
        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene("Clone");
        }
    }
}
