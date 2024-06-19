using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public float forwardSpeed = 5f; // Constant forward speed
    public float turnSpeed = 3f; // Speed at which the bird turns
    public float ascendSpeed = 2f; // Speed at which the bird ascends/descends
    public float maxPitchAngle = 30f; // Maximum pitch angle of the bird
    public float maxYawAngle = 30f; // Maximum yaw angle of the bird
    public float glideSpeed; // Speed at which bird glides in a direction

    public GamePlayManager gamePlayManager;
    private Rigidbody rb;

    private float endPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Disable gravity to control the bird's vertical movement manually
        if (SceneManager.GetActiveScene().name == Constants.SceneName.Env1.ToString()){
            endPosition = -2670f;
        }
    }

    void Update()
    {
        // Move the bird forward constantly
        // rb.velocity = ;

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
        // transform.Rotate(pitch * Time.deltaTime, yaw * Time.deltaTime, 0);
        // transform.Rotate(pitch * Time.deltaTime, 0, 0);

        if (gameObject.transform.position.y <= 4f && verticalInput <= 0f){
            verticalInput = 0f;
        }
        rb.velocity = (transform.forward * forwardSpeed) + (transform.right * horizontalInput * glideSpeed) + (transform.up * verticalInput * glideSpeed);
        GameEndCheck();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Handle collision logic here
        // e.g., End the game if the bird hits an obstacle
    }

    void OnTriggerEnter(Collider collider){
        // Debug.Log(collider.name);
        // Debug.Log(collider.gameObject.layer);
        // Debug.Log(collider.gameObject.tag);
        if (collider.gameObject.tag == "Nectar"){
            gamePlayManager.birdHealth = 1f;
            Destroy(collider.gameObject);
        } else if (collider.gameObject.layer == 11)
        {
            gamePlayManager.birdHealth -= .2f;
            // gamePlayManager.GameOver();
        }
    }

    void GameEndCheck(){
        if (gamePlayManager.gameRunning && gameObject.transform.position.z < endPosition){
            gamePlayManager.GameWon();
        }
    }
}
