using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Speed")]
    public float baseSpeed = 10f;
    public float maxSpeed = 20f;
    public float speedIncreaseRate = 0.5f;

    [Header("Lane Movement")]
    public float laneDistance = 3f;
    public float laneChangeSpeed = 10f;

    [Header("Jump")]
    public float jumpForce = 6f;
    public float groundCheckDistance = 1.4f;

    private Rigidbody rb;
    private Animator animator;

    private int currentLane = 0;
    private bool isGrounded;
    private bool jumpRequested;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // Lane input
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            ChangeLane(-1);

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            ChangeLane(1);

        // Jump input (buffered safely)
        if (Input.GetKeyDown(KeyCode.Space))
            jumpRequested = true;
    }

    void FixedUpdate()
    {
        CheckGrounded();

        // Forward speed scaling
        float speed = Mathf.Min(
            baseSpeed + Time.timeSinceLevelLoad * speedIncreaseRate,
            maxSpeed
        );

        rb.velocity = new Vector3(
            rb.velocity.x,
            rb.velocity.y,
            speed
        );

        // Lane movement
        Vector3 targetPosition = rb.position;
        targetPosition.x = currentLane * laneDistance;

        Vector3 newPosition = Vector3.Lerp(
            rb.position,
            targetPosition,
            laneChangeSpeed * Time.fixedDeltaTime
        );

        rb.MovePosition(newPosition);

        // Jump execution (physics-safe)
        if (jumpRequested && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        jumpRequested = false;

        // Animator updates (AFTER physics & ground check)
        animator.SetBool("isGrounded", isGrounded);
    }

    void ChangeLane(int direction)
    {
        currentLane += direction;
        currentLane = Mathf.Clamp(currentLane, -1, 1);
    }

    void CheckGrounded()
    {
        Vector3 origin = transform.position + Vector3.up * 0.2f;
        isGrounded = Physics.Raycast(origin, Vector3.down, groundCheckDistance);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.instance.GameOver();
        }
    }
}
