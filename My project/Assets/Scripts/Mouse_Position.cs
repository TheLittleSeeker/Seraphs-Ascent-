using UnityEngine;
using UnityEngine.InputSystem;

public class Mouse_Position : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject projectile;

    public Transform player;
    public float distanceToPlayer;
    [SerializeField] Sprite crossHair;
    private RectTransform crosshairRect;

    

    Vector3 mouse_pos;
    Vector3 mouse_world_pos;

    private void Start()
    {
        //Cursor.visible = false;
        crosshairRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        GetMousePosition();
        FireProjectile();

        //// This code constantly checks for mouse position
        //mouse_pos = Mouse.current.position.ReadValue();
        //mouse_pos.z = 10f;
        //mouse_world_pos = Camera.main.ScreenToWorldPoint(mouse_pos);
        //transform.position = mouse_world_pos;
        //crosshairRect.position = Mouse.current.position.ReadValue();
        //Debug.Log(mouse_pos);


        //// This code would only check mouse position on click

    }

    private void GetMousePosition()
    {
        Vector3 pos = Mouse.current.position.ReadValue();
        pos.z = 4f;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }

    private void FireProjectile()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Instantiate(projectile, spawnPoint.position, transform.rotation);
        }
    }
}
