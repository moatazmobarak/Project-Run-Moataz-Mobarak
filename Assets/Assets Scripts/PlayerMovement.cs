using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 10f;

    public float laneDistance = 3f;
    public float laneChangeSpeed = 10f;
    public float jumpForce = 6f;

    private Animator animator;
    private Rigidbody rb;
    private int currentLane = 0;
    private bool isGrounded;

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

        // Jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Forward movement
        Vector3 forwardMove = Vector3.forward * forwardSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);

        // Lane movement
        Vector3 targetPosition = rb.position;
        targetPosition.x = currentLane * laneDistance;

        Vector3 newPosition = Vector3.Lerp(
            rb.position,
            targetPosition,
            laneChangeSpeed * Time.fixedDeltaTime
        );

        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("yVelocity", rb.linearVelocity.y);


        rb.MovePosition(newPosition);

        // Ground check
        CheckGrounded();
    }

    void ChangeLane(int direction)
    {
        currentLane += direction;
        currentLane = Mathf.Clamp(currentLane, -1, 1);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    void CheckGrounded()
    {
        float rayLength = 1.1f;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, rayLength);
    }
    void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Obstacle"))
    {
        GameManager.instance.GameOver();
    }
}

}
