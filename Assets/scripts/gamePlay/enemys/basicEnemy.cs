using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    public float speed = 2f;
    public int scoreValue = 10;
    [SerializeField] AudioSource AudioSource;
    [SerializeField] AudioClip DestroySound;
    private void Start() // Changed from Awake to Start
    {
        GameObject audioObject = GameObject.FindWithTag("GlobalAudio");

        if (audioObject != null)
        {
            AudioSource = audioObject.GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogWarning($"Enemy {gameObject.name} could not find the GlobalAudio object!");
        }
    }
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            ScoreManager.instance.AddScore(scoreValue);
            if (AudioSource != null && DestroySound != null)
            {
                AudioSource.PlayOneShot(DestroySound);
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
