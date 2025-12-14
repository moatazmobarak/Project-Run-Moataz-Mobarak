using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 6, -10);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        Vector3 targetPosition = player.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.position = smoothPosition;
    }
}
