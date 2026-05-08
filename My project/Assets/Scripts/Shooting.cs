using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Shooting : MonoBehaviour
{

    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        var mouse = Mouse.current;
        if (mouse != null)
        {
            Vector2 position = mouse.position.ReadValue();
        }


        //mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        //Vector3 rotation = mousePos - transform.position;

        //float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.Euler(0, 0, rotZ);

        //if (!canFire)
        //{
        //    timer += Time.deltaTime;
        //    if (timer > timeBetweenFiring)
        //    {
        //        canFire = true;
        //        timer = 0;
        //    }

        //    if (Mouse.current.leftButton.isPressed && canFire)
        //    {
        //        canFire = false;
        //        Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        //    }
        //}
    }
}
