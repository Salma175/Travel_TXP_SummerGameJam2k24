using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    private bool _shouldFollow = false;

    private void Start()
    {
        _shouldFollow = GameManager.Instance.CurrentState == Constants.GameState.Playing;
        GameManager.Instance.OnGameStateChanged += HandleGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStateChanged -= HandleGameStateChanged;
    }

    private void HandleGameStateChanged(Constants.GameState state)
    {
        switch (state)
        {
            case Constants.GameState.Playing:
                _shouldFollow = true;
                break;
            default:
                _shouldFollow = false;
                break;
        }
    }

    void LateUpdate()
    {
        if (_shouldFollow)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            transform.LookAt(target);
        }
    }
}

