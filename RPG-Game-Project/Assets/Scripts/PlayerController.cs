//This provides basic collection types like arrays, lists, and dictionaries
using System.Collections;
//This adds support for general collections like List<T>, etc
using System.Collections.Generic;
//This is Unity's core library and provides tools like MonoBehaviour, Transform, Rigidbody, Collider, and others
using UnityEngine;

public class PlayerMovement : MonoBehaviour // Allows use of all UnityEngine features (used for all GameObjects)
{
    public float moveSpeed;
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;
    public int maxJumpCount;

    private Rigidbody2D rb;
    private bool facingLeft = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;
    private int jumpCount;

    // This runs before void Start() and is typically used for setting up internal references
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void start()
    {
        jumpCount = maxJumpCount;
    }

    void Update() // Update runs once per frame
    {
        // Give a value of -1 (moving left), 0 (no input), and 1 (moving right)
        moveDirection = Input.GetAxis("Horizontal");
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects); // Moved here for immediate ground detection
        if (isGrounded)
        {
            jumpCount = maxJumpCount;
        }
        
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            isJumping = true;
        }

        if (moveDirection < 0 && !facingLeft)
        {
            FlipCharacter();
        }
        else if (moveDirection > 0 && facingLeft)
        {
            FlipCharacter();
        }
    }

    private void FixedUpdate()
    {
        // Updates the Rigidbody's velocity for smooth movement
        rb.velocity = new Vector2(moveSpeed * moveDirection, rb.velocity.y);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpCount--;
        }
        isJumping = false;
    }

    private void FlipCharacter()
    {
        facingLeft = !facingLeft;
        transform.Rotate(0f, 180f, 0f);
    }
}
