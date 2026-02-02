using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement; //for text updates

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb; //new Rigidbody variable
    private float movementX; //x value for movement
    private float movementY; //y value for movement

    private float lastJumpTime = -999f;
    private bool isGrounded = true;
    private int count; //player scorehttps://chatgpt.com/
    private int lives; //player lives

    public float speed = 10f; //player speed
    public float jumpForce = 5f; //jump height
    public float jumpCooldown = .5f; //jump cooldown
    public TextMeshProUGUI countText; //ui player score
    public TextMeshProUGUI livesText; //ui player lives




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        lives = 3;
        SetCountText();
        livesText.text = "Lives: " + lives.ToString();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 dir = (transform.position - collision.transform.position).normalized;
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(dir * speed * 2 + Vector3.up * 10f, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Collectable"))
        {
            count++;
            SetCountText(); return;
        }
        if (obj.CompareTag("Damage"))
        {
            SetLivesCount(); return;
        } else
        {
            return;
        }

    }

    void SetLivesCount()
    {
        lives--;
        livesText.text = "Lives: " + lives.ToString();

        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            SceneManager.LoadScene("EndScreen");
        }
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
