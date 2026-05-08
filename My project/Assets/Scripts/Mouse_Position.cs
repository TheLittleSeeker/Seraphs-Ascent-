using UnityEngine;
using UnityEngine.InputSystem;

public class Mouse_Position : MonoBehaviour
{
    public GameObject cube;
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
        //// This code constantly checks for mouse position
        mouse_pos = Mouse.current.position.ReadValue();
        mouse_pos.z = 10f;
        mouse_world_pos = Camera.main.ScreenToWorldPoint(mouse_pos);
        transform.position = mouse_world_pos;
        //crosshairRect.position = Mouse.current.position.ReadValue();
        //Debug.Log(mouse_pos);


        //// This code would only check mouse position on click
        //if (Mouse.current.leftButton.wasPressedThisFrame)
        //{
        //    mouse_pos = Mouse.current.position.ReadValue();
        //    mouse_pos.z = Camera.main.nearClipPlane * 33f;
        //    mouse_world_pos = Camera.main.ScreenToWorldPoint(mouse_pos);
        //    Instantiate(cube, mouse_world_pos, Quaternion.identity);
        //}
    }
}
