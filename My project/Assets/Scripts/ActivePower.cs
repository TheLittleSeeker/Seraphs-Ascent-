using TMPro;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.InputSystem;

public class ActivePower : MonoBehaviour
{
    [SerializeField] PowerSO startingPower;
    [SerializeField] TMP_Text ammoText;

    PowerSO currentPowerSO;
    public InputAction shoot;
    Power currentPower;
    //Animator anim;


    int currentAmmo;
    private float TimeSinceLastShot = 0f;

    const string SHOOT_STRING = "Shoot";

    private void Awake()
    {
        //shoot.performed += OnShoot;
    }

    void Start()
    {
        SwitchPower(startingPower);
        AdjustAmmo(currentPowerSO.MagazineSize);

    }

    
    void Update()
    {
        TimeSinceLastShot += Time.deltaTime;
        //HandleShoot();

    }
    void HandleShoot()
    {
        //if (!attack.shoot) return;

        if (TimeSinceLastShot >= currentPowerSO.FireRate && currentAmmo > 0)
        {
            //anim.Play(SHOOT_STRING, 0, 0f);
            currentPower.Shoot(currentPowerSO);
            TimeSinceLastShot = 0f;
            AdjustAmmo(-1);
        }

        if (!currentPowerSO.IsAutomatic)
        {
            //attack.ShootInput(false);
        }

    }
    public void AdjustAmmo(int amount)
    {
        currentAmmo += amount;

        if (currentAmmo > currentPowerSO.MagazineSize)
        {
            currentAmmo = currentPowerSO.MagazineSize;
        }

        ammoText.text = currentAmmo.ToString("D2");
    }

    public void SwitchPower(PowerSO powerSO)
    {
        if (currentPower)
        {
            Destroy(currentPower.gameObject);
        }
        Power newPower = Instantiate(powerSO.PowerPrefab, transform).GetComponent<Power>();
        currentPower = newPower;
        this.currentPowerSO = powerSO;
        AdjustAmmo(currentPowerSO.MagazineSize);
    }
}
