using JetBrains.Annotations;
using UnityEngine;

public class Enemy : Character
{
    [Header("Enemy Settings")]
    [SerializeField] private float patrolDistance = 5.0f;

    private Vector2 startPos; // Starting Position
    private int direction = -1; // Direction my enemy is facing

    protected SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Awake()
    {
        base.Awake();

        // Could remove this since we are not doing anything specific.
        // But we are keeping it to make changes in the future.
        startPos = transform.position;
    }

    protected virtual void Update()
    {
        // Calculate the boundaries of my movement
        float leftBoundary = startPos.x - patrolDistance;
        float rightBoundary = startPos.x + patrolDistance;

        // Move my enemy
        transform.Translate(Vector2.right * direction * MoveSpeed * Time.deltaTime);

        // Flip the enemy when it hits a boundary
        if (transform.position.x >= rightBoundary)
        {
            direction = -1;     // Face to the left
            spriteRenderer.flipX = false;  // flip left

        }
        else if (transform.position.x <= leftBoundary)
        {
            direction = 1;      // Face to the right
            spriteRenderer.flipX = true; // flip right

        }
    }

        public override void Die()
        {
            Debug.Log("Enemy is dead");
            
        }
 }

