using UnityEngine;
using Unity.Cinemachine;

[RequireComponent(typeof(CinemachineImpulseSource))]
public class TremorZone : Zone
{
    private CinemachineImpulseSource impulseSource;
    private bool hasTriggered = false;

    private void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    protected override void ApplyZoneEffect(Player player)
    {
        if (!hasTriggered)
        {
            hasTriggered = true;

            if (impulseSource != null)
            {
                impulseSource.GenerateImpulse();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
        {
            hasTriggered = false;
        }
    }

}
