using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public GameObject gameOverUI;
    public float returnDelay = 3f;

    public bool gameOverTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameOverTriggered) return;

        if (collision.CompareTag("Enemy"))
        {
            StartCoroutine(GameOverRoutine());
        }
    }

    IEnumerator GameOverRoutine()
    {
        gameOverTriggered = true;

        Time.timeScale = 0f;
        gameOverUI.SetActive(true);

        yield return new WaitForSecondsRealtime(returnDelay);

        Time.timeScale = 1f;
        SceneManager.LoadScene("title");
    }
}
