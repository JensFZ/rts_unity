using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private CinemachineCamera cinemachineCamera;
    [SerializeField] private float keyboardPanSpeed = 5f;
    [SerializeField] private float zoomSpeed = 1f;

    private CinemachineFollow cinemachineFollow;
    private float zoomStartTime;
    private Vector3 startingFollowOffset;
    // Update is called once per frame

    void Awake()
    {
        if (!cinemachineCamera.TryGetComponent(out cinemachineFollow))
        {
            Debug.LogError("CinemachineFollow component not found on the assigned Cinemachine Camera.");
            return;
        }
        startingFollowOffset = cinemachineFollow.FollowOffset;
    }

    private void Update()
    {
        HandlePanning();
    }

    private void HandlePanning()
    {
        Vector2 moveAmount = Vector2.zero; // Initialize movement vector

        if (Keyboard.current.upArrowKey.isPressed)
        {
            moveAmount.y += keyboardPanSpeed; // Move up
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            moveAmount.y -= keyboardPanSpeed; // Move down
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            moveAmount.x -= keyboardPanSpeed; // Move left
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            moveAmount.x += keyboardPanSpeed; // Move right
        }

        moveAmount *= Time.deltaTime; // Scale movement by delta time
        // Move the camera
        cameraTarget.position += new Vector3(moveAmount.x, 0, moveAmount.y);
    }
}
