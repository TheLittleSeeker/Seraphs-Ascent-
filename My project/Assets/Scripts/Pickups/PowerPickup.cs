using UnityEngine;

public class PowerPickup : Pickup
{
    [SerializeField] PowerSO powerSO;

    protected override void OnPickup(ActivePower activePower)
    {
        activePower.SwitchPower(powerSO);
    }
}
