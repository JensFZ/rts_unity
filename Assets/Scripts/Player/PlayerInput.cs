using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private float keyboardPanSpeed = 5f;

    // Update is called once per frame
    private void Update()
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
