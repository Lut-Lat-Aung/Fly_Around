using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;           // The plane to follow
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Camera position offset
    public float followSpeed = 5f;     // How fast the camera follows the plane
    public float rotationSpeed = 5f;   // How fast the camera matches rotation (optional)

    void LateUpdate()
    {
        if (target == null) return;

        // Smoothly move to the target's position with offset
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Optionally, follow the target's rotation
        Quaternion desiredRotation = Quaternion.LookRotation(target.forward, target.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }
}
