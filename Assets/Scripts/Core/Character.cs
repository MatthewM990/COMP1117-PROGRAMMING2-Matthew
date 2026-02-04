using UnityEngine;

[RequireComponent (typeof(Animator))]
public abstract class Character : MonoBehaviour
{
    // Private Variables
    [Header("Character Stats")]
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;


    protected bool isDead = false;
    protected Animator anim;

    // Public properties
    public float MoveSpeed
    {
        // Read-only
        get { return moveSpeed; }
    }

    public bool IsDead
    {
        // Read-Only
        get { return isDead; }
    }

    protected int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        // Level of Protection 
        if(isDead)
        {
            return;
        }

        CurrentHealth -= amount;
        Debug.Log($"{gameObject.name} HP is now: {CurrentHealth}");

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    // each child object will implement their own death
    public abstract void Die();
}
