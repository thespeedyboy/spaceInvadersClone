using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public GameObject gameOverUI;
    [SerializeField] AudioSource AudioSource;
    [SerializeField] AudioClip GameOverSound;
    public float returnDelay = 4f;

    public bool gameOverTriggered = false;
    private void Awake()
    {
        GameObject audioObject = GameObject.FindWithTag("GlobalAudio");
        if (audioObject != null)
        {
            AudioSource = audioObject.GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogWarning($"DeathZone {gameObject.name} could not find the GlobalAudio object!");
        }
    }
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
        if (AudioSource != null && GameOverSound != null)
        {
            AudioSource.PlayOneShot(GameOverSound);
        }
        yield return new WaitForSecondsRealtime(returnDelay);

        Time.timeScale = 1f;
        SceneManager.LoadScene("title");
    }
}
