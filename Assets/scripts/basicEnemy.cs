using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    public int scoreValue = 10;
    public float speed = 2f;
    void Update()
    {
        // Move enemy downward
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if hit by a bullet
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); // destroy bullet
                                           // Add score
            ScoreManager.instance.AddScore(scoreValue);

            Destroy(gameObject);           // destroy enemy
        }
    }
}
