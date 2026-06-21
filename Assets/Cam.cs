using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float smoothSpeed = 1f; // Smooth factor
    public float fixedY = 0f; // Y position to freeze

    void LateUpdate()
    {
        if (player == null) return;

        // Desired position: follow player's X, keep Y fixed
        Vector3 desiredPosition = new Vector3(player.position.x, fixedY, transform.position.z);

        // Smoothly move the camera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
