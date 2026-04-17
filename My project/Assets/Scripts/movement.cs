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

    
    [SerializeField] AudioClip walk1SFX;
    [SerializeField] AudioClip walk2SFX;

    //[SerializeField] bool canWingBoost;


    Rigidbody rb;
    AudioSource audioSource;
    Vector2 playerVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        //canWingBoost = false;
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
        //HandleWingBoost();
    }
    private void HandleJump()
    {
        if (jump.IsPressed() && isGrounded)
        {
            playerVelocity = rb.linearVelocity;
            playerVelocity.y = 0f;
            rb.linearVelocity = playerVelocity;

            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            //canWingBoost = true;
        }
    }
    //private void HandleWingBoost()
    //{
    //    if (jump.IsPressed() && (canWingBoost = true))
    //    {
    //        playerVelocity = rb.linearVelocity;
    //        playerVelocity.y = 0f;
    //        rb.linearVelocity = playerVelocity;

    //        rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
    //        canWingBoost = false;
    //    }
    //}
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

        if (move.IsPressed())
        {
            if (!audioSource.isPlaying && isGrounded)
            {
                audioSource.PlayOneShot(walk1SFX, walk1SFX.length);
                //audioSource.PlayOneShot(walk2SFX);
            }
            else
            {
                audioSource.Stop();
            }
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundDistance, groundLayer);        
    
    }
 }

