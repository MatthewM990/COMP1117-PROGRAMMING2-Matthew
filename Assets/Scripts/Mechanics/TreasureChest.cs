using UnityEngine;

public class TreasureChest : MonoBehaviour, IInteractable
{
    [Header("Loot Settings")]
    [SerializeField] private GameObject gemPrefab; // "___Prefab" is convention
    [SerializeField] private int gemCount = 3;
    [SerializeField] private float launchForce = 5f;

    [Header("Visuals")]
    [SerializeField] private Sprite openChestSprite;

    private SpriteRenderer sRend;
    private bool isOpened = false;

    private void Awake()
    {
        sRend = GetComponent<SpriteRenderer>();  // Caching your reference
    }

    public void Interact()
    {
        // Safety Check
        if(isOpened)
        {
            // if chest is open, do nothing and leave.
            return;
        }

        isOpened = true;
        OpenChest();
    }

    private void OpenChest()
    {
        // 1. change visual state to open
        if(sRend != null && openChestSprite != null)
        {
            sRend.sprite = openChestSprite;
        }
        // 2. Spew Gems
        for(int i = 0; i < gemCount; i++)
        {
            GameObject gem = Instantiate(gemPrefab, transform.position, Quaternion.identity);
            Rigidbody2D gemRB = gem.GetComponent<Rigidbody2D>();

            // Safety check
            if(gemRB != null)
            {
                // launch it up in the air
                // create a "fountain" effect
                Vector2 force = new Vector2(Random.Range(-1f, 1f), 1.5f).normalized * launchForce;
                gemRB.AddForce(force, ForceMode2D.Impulse);
            }
        }
    }
}
