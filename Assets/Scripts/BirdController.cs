using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float forwardSpeed = 5f; // Constant forward speed
    public float turnSpeed = 3f; // Speed at which the bird turns
    public float ascendSpeed = 2f; // Speed at which the bird ascends/descends
    public float maxPitchAngle = 30f; // Maximum pitch angle of the bird
    public float maxYawAngle = 30f; // Maximum yaw angle of the bird

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Disable gravity to control the bird's vertical movement manually
    }

    void Update()
    {
        // Move the bird forward constantly
        rb.velocity = transform.forward * forwardSpeed;

        // Get input for turning and ascending/descending
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate new rotation
        float yaw = horizontalInput * turnSpeed;
        float pitch = -verticalInput * ascendSpeed;

        // Clamp the pitch and yaw angles
        pitch = Mathf.Clamp(pitch, -maxPitchAngle, maxPitchAngle);
        yaw = Mathf.Clamp(yaw, -maxYawAngle, maxYawAngle);

        // Apply rotation to the bird
        transform.Rotate(pitch * Time.deltaTime, yaw * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Handle collision logic here
        // e.g., End the game if the bird hits an obstacle
    }
}
