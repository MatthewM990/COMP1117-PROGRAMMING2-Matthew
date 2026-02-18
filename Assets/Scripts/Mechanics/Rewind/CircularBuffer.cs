using System.Collections.Generic;

public class CircularBuffer
{
    // Collection itself
    private List<int> buffer;
    //capacity
    private int capacity;

    // constructor - allow me to create a CircularBuffer with a given capacity
    public CircularBuffer(int capacity)
    {
        buffer = new List<int>(capacity);
        this.capacity = capacity;
    }

    // Public property

    /*public int Count
    //{
    //    get 
    //    { 
    //        return buffer.Count; 
    //    }
    }
    */

    public int Count => buffer.Count;

    // Buffer Operations
    // =================
    // 1. Push (adding new information to the buffer)
    public void Push(int item)
    {
        // CHeck if my buffer is at or above capacity
        if (buffer.Count >= capacity)
        {
            buffer.RemoveAt(0);        // Removes the oldest data
        }

        buffer.Add(item);
    }
    // 2. Pop (removing the next piece of information)
    public int Pop()
    {
        if (buffer.Count == 0) return -1;

        int lastIndex = buffer.Count - 1;
        int item = buffer[lastIndex];      // Create a copy of the item in the buffer[lastIndex] and stores it in 'item'
        buffer.RemoveAt(lastIndex);        // Removes the item at lastIndex

        return item;
    }
}
