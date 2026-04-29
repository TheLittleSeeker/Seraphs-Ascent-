using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class ActivePower : MonoBehaviour
{
    //[SerializeField] PowerSO startingPower;
    [SerializeField] TMP_Text ammoText;

    //PowerSO currentPowerSO;
    ////StarterAssetsInputs input;
    //Power currentPower;
    //Animator anim;


    int currentAmmo;
    private float TimeSinceLastShot = 0f;

    const string SHOOT_STRING = "Shoot";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SwitchPower(startingPower);
        //AdjustAmmo(currentPower.MagazineSize);

    }

    // Update is called once per frame
    void Update()
    {
        TimeSinceLastShot += Time.deltaTime;
        //HandleShoot();

    }
    //void HandleShoot()
    //{
    //    if (!input.shoot) return;

    //    if (TimeSinceLastShot >= currentPowerSO.FireRate && currentAmmo > 0)
    //    {
    //        anim.Play(SHOOT_STRING, 0, 0f);
    //        currentWeapon.Shoot(currentPowerSO);
    //        TimeSinceLastShot = 0f;
    //        AdjustAmmo(-1);
    //    }

    //    if (!currentPowerSO.IsAutomatic)
    //    {
    //        input.ShootInput(false);
    //    }

    //}
    //public void AdjustAmmo(int amount)
    //{
    //    currentAmmo += amount;

    //    if (currentAmmo > currentPowerSO.MagazineSize)
    //    {
    //        currentAmmo = currentPowerSO.MagazineSize;
    //    }

    //    ammoText.text = currentAmmo.ToString("D2");
    //}

    //public void SwitchWeapon(PowerSO powerSO)
    //{
    //    if (currentWeapon)
    //    {
    //        Destroy(currentWeapon.gameObject);
    //    }
    //    Power newPower = Instantiate(powerSO.PowerPrefab, transform).GetComponent<Power>();
    //    currentPower = newPower;
    //    this.currentPowerSO = powerSO;
    //    AdjustAmmo(currentPowerSO.MagazineSize);
    //}
}
