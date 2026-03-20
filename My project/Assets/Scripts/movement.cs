using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    [SerializeField] InputAction jump;
    [SerializeField] InputAction left;
    [SerializeField] InputAction right;

    [SerializeField] float jumpForce = 7f;
    [SerializeField] float walkForce = 4f;

    //bool canDoubleJump = true;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnEnable()
    {
        jump.Enable(); 
        left.Enable();
        right.Enable();
    }


    private void FixedUpdate()
    {
        if (jump.IsPressed())
        {
            //rb.AddRelativeForce(Vector3.up * propelForce * Time.fixedDeltaTime);

            Vector2 playerVelocity = rb.linearVelocity;
            playerVelocity.y = 0f;
            rb.linearVelocity = playerVelocity;

            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }

        if (left.IsPressed())
        {
         
            Vector2 playerVelocity = rb.linearVelocity;
            playerVelocity.x = 0f;
            rb.linearVelocity = playerVelocity;

            rb.AddForce(Vector2.left * walkForce, ForceMode.Impulse);
        }

        if (right.IsPressed())
        {
            //rb.AddRelativeForce(Vector3.up * propelForce * Time.fixedDeltaTime);

            Vector2 playerVelocity = rb.linearVelocity;
            playerVelocity.x = 0f;
            rb.linearVelocity = playerVelocity;

            rb.AddForce(Vector2.right * walkForce, ForceMode.Impulse);
        }
    }
}
