using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Constants;

public class BirdController : MonoBehaviour
{
    public float forwardSpeed = 5f; // Constant forward speed
    public float turnSpeed = 3f; // Speed at which the bird turns
    public float ascendSpeed = 2f; // Speed at which the bird ascends/descends
    public float maxPitchAngle = 30f; // Maximum pitch angle of the bird
    public float maxYawAngle = 30f; // Maximum yaw angle of the bird
    public float glideSpeed; // Speed at which bird glides in a direction

    private Rigidbody rb;

    private float endPosition;

    private Vector3 _startPosition;

    private bool collectedNectar;
    public bool CollectedNectar
    {
        get => collectedNectar;
        private set
        {
            collectedNectar = value;
            OnNectarCollected?.Invoke();
        }
    }
    public event Action OnNectarCollected;

    private bool onDamange;
    public bool Damage
    {
        get => onDamange;
        private set
        {
            onDamange = value;
            OnDamage?.Invoke();
        }
    }
    public event Action OnDamage;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
      
        _startPosition = transform.position;
        endPosition = -2670f;
    }

    private void OnEnable()
    {
        GameManager.Instance.OnGameStateChanged += HandleGameStateChanged;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameStateChanged -= HandleGameStateChanged;
    }

    private void HandleGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Playing:
                break;
            default:
                break;
        }
    }

    void Update()
    {
        if (GameManager.Instance.CurrentState == GameState.Playing)
        {  // Get input for turning and ascending/descending
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Calculate new rotation
            float yaw = horizontalInput * turnSpeed;
            float pitch = -verticalInput * ascendSpeed;

            pitch = Mathf.Clamp(pitch, -maxPitchAngle, maxPitchAngle);
            yaw = Mathf.Clamp(yaw, -maxYawAngle, maxYawAngle);

            // Apply rotation to the bird
            // transform.Rotate(pitch * Time.deltaTime, yaw * Time.deltaTime, 0);
            // transform.Rotate(pitch * Time.deltaTime, 0, 0);

            if (transform.position.y <= 4f && verticalInput <= 0f)
            {
                verticalInput = 0f;
            }
            rb.velocity = (transform.forward * forwardSpeed) + (transform.right * horizontalInput * glideSpeed) + (transform.up * verticalInput * glideSpeed);

            GameEndCheck();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Handle collision logic here
        // e.g., End the game if the bird hits an obstacle
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Nectar")
        {
            CollectedNectar = true;
            Destroy(collider.gameObject);
        } 
        else if (collider.gameObject.layer == 11)
        {
            Damage = true;
        }
    }

    void GameEndCheck()
    {
        if (gameObject.transform.position.z < endPosition)
        {
            GameManager.Instance.CurrentState = (GameState.GameOver);
        }
    }

    internal void Restart()
    {
        transform.position = _startPosition;
    }
}
