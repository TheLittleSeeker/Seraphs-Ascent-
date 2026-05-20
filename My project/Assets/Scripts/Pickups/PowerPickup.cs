using UnityEngine;

public class PowerPickup : Pickup
{
    //[SerializeField] PowerSO powerSO;

    private void Start()
    {

    }

    protected override void OnPickup(ActivePower activePower)
    {
        
        //activePower.SwitchPower(powerSO);
    }
}
