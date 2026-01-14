using UnityEngine;
using UnityEngine.InputSystem;

public class TestEnemy : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private int damageToDeal = 15;
    public void OnAttack(InputValue value)
    {
        if(value.isPressed)
        {
            if (playerController != null)
            {

                playerController.TakeDamage(damageToDeal);
            }
        }
        else
        {
            Debug.LogWarning("TESTENEMY.CS: PlayerController is null");
        }
    }
}
