using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    [SerializeField] private float movementSpeed = 5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleMovement();
    }
   private void HandleMovement()
   {
       float moveInput = Input.GetAxis("Horizontal");
       Vector2 velocity = rb.linearVelocity;
       velocity.x = moveInput * movementSpeed;
       rb.linearVelocity = velocity;
   }
}

