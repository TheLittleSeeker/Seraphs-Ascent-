using UnityEngine;
using UnityEngine.InputSystem;

public class Mouse_Position : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject projectile;

    public Transform player;
    public float distanceToPlayer;
    [SerializeField] Sprite crossHair;
    [SerializeField] int missileCount;


    private RectTransform crosshairRect;
    //Vector3 mouse_pos;
    //Vector3 mouse_world_pos;

    private void Start()
    {
        //Cursor.visible = false;
        crosshairRect = GetComponent<RectTransform>();
        missileCount = 3;
    }

    void Update()
    {
        GetMousePosition();
        FireProjectile();
    }

    private void GetMousePosition()
    {
        Vector3 pos = Mouse.current.position.ReadValue();
        pos.z = 4f;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }

    private void FireProjectile()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && missileCount >= 3)
        {
            Instantiate(projectile, spawnPoint.position, transform.rotation);
        }
        else
        {
            //Destroy(gameObject)
        }
    }
}
