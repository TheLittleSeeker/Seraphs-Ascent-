using UnityEngine;
using UnityEngine.InputSystem;

public class Power : MonoBehaviour
{
    private InputActionMap Player;
    private Vector2 mousePosition;
    //[SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactionLayer;

    //private void Awake()
    //{
    //    Player.Enable();
    //}
    public void Shoot(PowerSO powerSO)
    {
        //muzzleFlash.Play();

        RaycastHit hit;

        //if 
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactionLayer, QueryTriggerInteraction.Ignore))
        {
            //Instantiate(powerSO.HitVFXPrefab, hit.point, Quaternion.identity);
            Enemy_Health enemyHealth = hit.collider.GetComponentInParent<Enemy_Health>();
            enemyHealth?.TakeDamage(powerSO.Damage);
        }
    }
}