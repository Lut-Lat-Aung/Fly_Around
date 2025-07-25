using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float forwardSpeed = 20f;
    public float turnSpeed = 50f;
    public float tiltAmount = 30f;
    public float tiltSpeed = 5f;

    private float yaw;
    private float pitch;
    private float roll;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down

        // Apply yaw and pitch for direction
        yaw = horizontal * turnSpeed * Time.deltaTime;
        pitch = vertical * turnSpeed * Time.deltaTime;

        transform.Rotate(pitch, yaw, 0f, Space.Self);

        // Auto tilt based on movement (no need for shift)
        float targetRoll = -horizontal * tiltAmount;
        float targetPitchTilt = vertical * tiltAmount;

        // Smoothly transition roll and pitch
        float currentRoll = Mathf.LerpAngle(transform.localEulerAngles.z, targetRoll, Time.deltaTime * tiltSpeed);
        float currentPitch = Mathf.LerpAngle(transform.localEulerAngles.x, targetPitchTilt, Time.deltaTime * tiltSpeed);

        // Apply tilt rotation (preserve yaw)
        transform.localRotation = Quaternion.Euler(currentPitch, transform.localEulerAngles.y, currentRoll);

        // Move forward constantly
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }
}
