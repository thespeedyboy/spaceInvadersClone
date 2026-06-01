using UnityEngine;
using UnityEngine.Events;

public class shooting : MonoBehaviour
{
    [Header("Shooting settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject SpawnPoint;
    [SerializeField] float BulletSpeed = 10f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float bulletLifetime = 3f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioSource audioSource;
    [Header("Events")]
    public UnityEvent onShoot; // Hook up animations, sounds, etc.

    private float nextFireTime = 0f;

    // This method will be called automatically by Player Input
    public void PlayShootSound()
    {
        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }
    public void OnShoot()
    {
        if (Time.time >= nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void FireBullet()
    {
        // Spawn the bullet
        GameObject bullet = Instantiate(bulletPrefab, SpawnPoint.transform.position, Quaternion.identity);

        // Give it velocity
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.up * BulletSpeed;
        }

        // Destroy after lifetime
        Destroy(bullet, bulletLifetime);

        // Invoke any UnityEvents
        onShoot?.Invoke();
    }


}
