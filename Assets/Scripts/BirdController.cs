using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float flapForce = 300f;  // Force applied when the bird flaps
    public float forwardSpeed = 5f; // Constant forward speed
    public float maxPitchAngle = 30f; // Maximum pitch angle of the bird

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Move the bird forward constantly
        rb.velocity = new Vector3(forwardSpeed, rb.velocity.y, rb.velocity.z);

        // Check for input to make the bird flap
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }

        // Adjust bird's pitch based on vertical velocity
        AdjustPitch();
    }

    void Flap()
    {
        // Apply an upward force to the bird
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset Y velocity to zero before applying the flap force
        rb.AddForce(Vector3.up * flapForce);
    }

    void AdjustPitch()
    {
        // Calculate the pitch angle based on vertical speed
        float pitch = Mathf.Clamp(rb.velocity.y * maxPitchAngle / flapForce, -maxPitchAngle, maxPitchAngle);
        transform.rotation = Quaternion.Euler(pitch, 0, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Handle collision logic here
        // e.g., End the game if the bird hits an obstacle
    }
}
