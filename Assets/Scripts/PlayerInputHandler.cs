using UnityEngine;
using UnityEngine.InputSystem;

// Read input from the Input System.
public class PlayerInputHandler : MonoBehaviour
{
    // What inputs can my player do right now.
    // 1. Move left and right
    // 2. Jump
    private Vector2 moveInput; // left and right movement
    private bool jumpTriggered = false; // Jumping?

    // public properties to read input values
    public Vector2 MoveInput
    {
        // Read-Only
        get { return moveInput; } 
    }

    public bool JumpTriggered
    {
        // Read-Only
        get { return jumpTriggered; }
    }

    public void OnMove(InputAction.CallbackContext context)
    {

        // Save input to the field
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started) // I started to push the button
        {
            jumpTriggered = true;
        }
        else if(context.canceled) // I have let go of the button
        {
            jumpTriggered = false;
        }
    }
}
