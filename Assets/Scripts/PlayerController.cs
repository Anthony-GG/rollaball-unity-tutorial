using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb; //new Rigidbody variable
    private float movementX; //x value for movement
    private float movementY; //y value for movement

    private float lastJumpTime = -999f;
    private bool isGrounded = true;

    public float speed = 10f; //player speed
    public float jumpForce = 5f; //jump height
    public float jumpCooldown = .5f; //jump cooldown




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    void OnMove(InputValue movementValue) //OnMove function that takes movementValues and translates them to movement
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); //converts player input vector to movement
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnJump(InputValue value)
    {
        if (!value.isPressed || !isGrounded)
        {
            return;
        }

        if (Time.time - lastJumpTime < jumpCooldown)
        {
            return;
        }

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        lastJumpTime = Time.time;
        isGrounded = false;
    }
}
