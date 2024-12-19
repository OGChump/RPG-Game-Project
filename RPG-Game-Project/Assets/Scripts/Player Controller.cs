using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    public float jumpForce = 5f; // Jumping force
    public LayerMask groundLayer; // Layer for ground detection

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        CheckGround();

        if (Input.GetAxis("Vertical") * jumpForce > 0 && isGrounded)
        {
            Jump();
        }
    }

    // Move the player left/right
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontal, 0, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    // Jump logic
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // Check if the player is on the ground
    private void CheckGround()
    {
        // Check if the player's feet are touching the ground layer
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
    }
}
