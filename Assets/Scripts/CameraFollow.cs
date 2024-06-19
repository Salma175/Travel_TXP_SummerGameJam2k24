using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public GamePlayManager gamePlayManager;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        // Use a damping factor for smoother transition
        float dampingFactor = 1f - Mathf.Exp(-smoothSpeed * Time.deltaTime);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        if (gamePlayManager.gameRunning){
            transform.position = smoothedPosition;
        }

        transform.LookAt(target);
    }
}

