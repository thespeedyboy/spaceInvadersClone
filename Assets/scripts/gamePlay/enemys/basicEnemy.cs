using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    public float speed = 2f;
    public int scoreValue = 10;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            ScoreManager.instance.AddScore(scoreValue);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
