using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    [SerializeField] InputAction jump;
    [SerializeField] InputAction move;
    

    [SerializeField] float jumpForce = 7f;
    [SerializeField] float moveSpeed = 4f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.2f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] bool isGrounded;

    Rigidbody rb;
    Vector2 playerVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnEnable()
    {
        jump.Enable(); 
        move.Enable();
    }

    private void Update()
    {
        CheckGrounded();
    }

    private void FixedUpdate()
    {
        HandleJump();
        HandleMove();
    }
    private void HandleJump()
    {
        if (jump.IsPressed() && isGrounded)
        {
            playerVelocity = rb.linearVelocity;
            playerVelocity.y = 0f;
            rb.linearVelocity = playerVelocity;

            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void HandleMove()
    {            
        float moveInput = move.ReadValue<float>();
        playerVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        rb.linearVelocity = playerVelocity;

        if (moveInput != 0f)
        {
            float yRotation = moveInput > 0 ? 0f : 180f;
            rb.MoveRotation(Quaternion.Euler(0, yRotation, 0));
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundDistance, groundLayer);        
    
    }
 }

