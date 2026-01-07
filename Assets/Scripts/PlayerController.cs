using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerStats stats;


    //Components
    private Rigidbody2D rBody;

    //Field variables
    private Vector2 moveInput;

    void Awake()
    {
        // Initialize
        rBody = GetComponent<Rigidbody2D>();
       
        stats = new PlayerStats();
        int something = stats.MoveSpeed;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    void ApplyMovement()
    {
        float velocityX = moveInput.x;

        rBody.linearVelocity = new Vector2(velocityX, rBody.linearVelocity.y);
    }
}
