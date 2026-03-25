using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float tiltAmount = 15f;    
    [SerializeField] private float tiltSpeed = 10f;      
    [SerializeField] private float movementSpeed = 8f;
    [SerializeField] private float acceleration = 12f;
    [SerializeField] private float deceleration = 25f;

    // Screen bounds
    [SerializeField] private float leftBound = -8f;
    [SerializeField] private float rightBound = 8f;

    private Rigidbody2D rb;
    private float moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Important for smooth visuals
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    private void FixedUpdate()
    {
        HandleMovement();
        ClampPosition();
        HandleTilt();
    }

    private void HandleMovement()
    {
        float targetSpeed = moveInput * movementSpeed;
        float speedDifference = targetSpeed - rb.linearVelocity.x;

        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;

        float movement = speedDifference * accelRate;

        float newVelocityX = rb.linearVelocity.x + movement * Time.fixedDeltaTime;

        rb.linearVelocity = new Vector2(newVelocityX, rb.linearVelocity.y);
    }

    private void ClampPosition()
    {
        Vector2 pos = rb.position;
        pos.x = Mathf.Clamp(pos.x, leftBound, rightBound);
        rb.position = pos;
    }
    private void HandleTilt()
{
    float targetTilt = -moveInput * tiltAmount;

    float newZ = Mathf.LerpAngle(
        rb.rotation,
        targetTilt,
        tiltSpeed * Time.fixedDeltaTime
    );

    rb.MoveRotation(newZ);
}

    // Input stays the same
    public void Move(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        moveInput = input.x;
    }
}

