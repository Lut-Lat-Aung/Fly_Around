using UnityEngine;

public class PitStopTrigger : MonoBehaviour
{
    public float slowDownRate = 20f; // How fast to slow down

    private PlaneController plane;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            plane = other.GetComponent<PlaneController>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (plane != null && plane.forwardSpeed > 0)
        {
            plane.forwardSpeed -= slowDownRate * Time.deltaTime;
            if (plane.forwardSpeed < 0)
                plane.forwardSpeed = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            plane = null;
        }
    }
}
