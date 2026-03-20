using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    [SerializeField] InputAction propel;
    [SerializeField] float propelForce = 100f;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnEnable()
    {
        propel.Enable(); 
    }


    private void FixedUpdate()
    {
        if (propel.IsPressed())
        {
            //rb.AddRelativeForce(Vector3.up * propelForce * Time.fixedDeltaTime);

            Vector2 playerVelocity = rb.linearVelocity;
            playerVelocity.y = 0f;
            rb.linearVelocity = playerVelocity;

            rb.AddForce(Vector2.up * propelForce, ForceMode.Impulse);
        }
    }
}
