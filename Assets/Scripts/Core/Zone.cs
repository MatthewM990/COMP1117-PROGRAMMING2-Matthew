using NUnit.Framework.Constraints;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Zone : MonoBehaviour
{
    [Header("Zone Settings")]
    [SerializeField] private Color debugColour = new Color(0, 1, 0, 0.3f);

    private void Awake()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }


    // the "contract"
    // every child object must define what happens in this method.
    protected abstract void ApplyZoneEffect(Player player);

    // we use a trigger to detect the player
    private void OnTriggerStay2D(Collider2D collision)
    {
        // ensure the player is in this trigger
        if (collision.TryGetComponent(out Player player));
        {
            ApplyZoneEffect(player);
        }
    }



    // Debug purposes only!
    //Visual aid for the editor so you can see zones. 
    private void OnDrawGizmos()
    {
        Gizmos.color = debugColour;
        BoxCollider2D box = GetComponent<BoxCollider2D>();

        if (box != null)
        {
            Gizmos.DrawCube(transform.position + (Vector3)box.offset, box.size);
        }
    }
}
