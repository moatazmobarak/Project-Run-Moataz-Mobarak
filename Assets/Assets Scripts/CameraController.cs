using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Target")]
    public Transform player;

    [Header("Follow")]
    public Vector3 offset = new Vector3(0f, 4f, -7f);
    public float followSmoothness = 5f;

    [Header("FOV")]
    public float baseFOV = 60f;
    public float maxFOV = 75f;
    public float speedForMaxFOV = 20f;

    private Camera cam;
    private Rigidbody playerRb;

    void Start()
    {
        cam = GetComponent<Camera>();
        playerRb = player.GetComponent<Rigidbody>();
        cam.fieldOfView = baseFOV;
    }

    void LateUpdate()
    {
        if (!player) return;

        // Smooth follow
        Vector3 targetPos = player.position + offset;
        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            followSmoothness * Time.deltaTime
        );

        // Dynamic FOV based on speed
        float speed = playerRb.velocity.z;
        float t = Mathf.Clamp01(speed / speedForMaxFOV);
        cam.fieldOfView = Mathf.Lerp(baseFOV, maxFOV, t);
    }
}
