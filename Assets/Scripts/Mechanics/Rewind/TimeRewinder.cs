using UnityEngine;
using UnityEngine.InputSystem;

public class TimeRewinder : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int maxFrames = 300;
    [SerializeField] private bool isRewinding = false;

    private CircularBuffer buffer;

    private void Awake()
    {
        buffer = new CircularBuffer(maxFrames);
    }

    // Handle the "Rewind" action from the Input System
    public void OnRewind(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            isRewinding = true;
            Debug.Log("Rewind Performed");
        }
        else if (context.canceled)
        {
            isRewinding = false;
            Debug.Log("Rewind Cancelled");
        }
    }


    private void FixedUpdate()
    {
        if(isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    // record
    private void Record()
    {
        buffer.Push(Random.Range(0, 1000));      // Push a random integer into the buffer
    }

    // rewind
    private void Rewind()
    {
        if(buffer.Count > 0)      // make sure my buffer has something in it
        {
            int tempInt = buffer.Pop();
            Debug.Log("Item Popped from Circular Buffer: " + tempInt);
        }
        else
        {
            isRewinding = false;    // Stop if we run out of items to proccess
        }
    }

}
