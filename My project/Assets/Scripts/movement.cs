using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction jump;
    [SerializeField] InputAction move;
    

    [SerializeField] float jumpForce = 7f;
    [SerializeField] float moveSpeed = 4f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.2f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] public bool isGrounded;

    [SerializeField] Transform wallCheck;
    //[SerializeField] float wallDistance = 0.2f;
    [SerializeField] LayerMask wallLayer;
    //[SerializeField] bool isTouchingWall;


    [SerializeField] AudioClip walk1SFX;
    [SerializeField] AudioClip walk2SFX;

    [SerializeField] bool canWingBoost;
    //[SerializeField] bool canWallJump;
    //[SerializeField] bool inAir;
    Vector3 wallJumpDirection;



    public Rigidbody rb;
    AudioSource audioSource;
    Vector2 playerVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        canWingBoost = false;
        //canWallJump = false;
        //inAir = false;
    }
    private void Start()
    {
        jump.performed += ctx => HandleJump();
        //jump.performed += ctx => CheckLanded();
    }


    private void OnEnable()
    {
        jump.Enable(); 
        move.Enable();
    }

    private void Update()
    {
        CheckGrounded();
        //CheckTouchingWall();
        if (isGrounded)
        {
            canWingBoost = true;
            //inAir = false;
        }
    }

    private void FixedUpdate()
    {
        HandleMove();
        //if (!isGrounded)
        //{
        //    inAir = true;

        //    if (inAir)
        //    { canWingBoost = true; }

        //    else if (!inAir)
        //    { canWingBoost = false; }
        //}
        //if (isGrounded)
        //{
        //    canWingBoost = false;
        //    inAir = false;
        //}
        
        //HandleWallJump();
    }

    private void HandleJump()
    {
        if (isGrounded || canWingBoost)
        {
            Vector2 playerVelocity = rb.linearVelocity;
            playerVelocity.y = 0f;
            rb.linearVelocity = playerVelocity;

            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            canWingBoost = !canWingBoost;
        }
        //if (isGrounded)
        //{
        //    inAir = false;
        //}
        //if (inAir == true)
        //{
        //    canWingBoost = true;
        //}
        //else if (inAir == false)
        //{
        //    canWingBoost = false;
        //}



        //if (canWingBoost)
        //{
        //    canWallJump = !canWallJump;
        //}
        //if (!canWallJump)
        //{
        //    if (canWingBoost)
        //    {
        //        canWallJump = !canWallJump;
        //    }
        //}
        //else if (canWallJump)
        //{
        //    //Debug.Log("Wall Layer via Raycast");
        //    //Vector2 playerVelocity = rb.linearVelocity;
        //    //playerVelocity.y = 0f;
        //    //rb.linearVelocity = playerVelocity;

        //    //rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        //    canWallJump = !canWallJump;
        //}

    }
    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (isGrounded && hit.transform.CompareTag("JumpableWall"))
    //    {
    //        //canWallJump = true;
    //        wallJumpDirection = hit.normal;
    //        Debug.DrawLine(hit.point, hit.normal + hit.point, Color.blue);
    //    }
    //    else
    //    {
    //        canWallJump = false;
    //    }
    //}
    //private void HandleWallJump()
    //{
    //    if (jump.IsPressed() && !canWallJump)
    //    {
    //        if (canWingBoost)
    //        {
    //            canWallJump = !canWallJump;
    //        }
    //    }
    //    else if (jump.IsPressed() && canWallJump)
    //    {
    //        Debug.Log("Wall Layer via Raycast");
    //        Vector2 playerVelocity = rb.linearVelocity;
    //        playerVelocity.y = 0f;
    //        rb.linearVelocity = playerVelocity;

    //        rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
    //        canWallJump = !canWallJump;
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

        //if (move.IsPressed())
        //{
        //    if (!audioSource.isPlaying && isGrounded)
        //    {
        //        audioSource.PlayOneShot(walk1SFX, walk1SFX.length);
        //        //audioSource.PlayOneShot(walk2SFX);
        //    }
        //    else
        //    {
        //        audioSource.Stop();
        //    }
        //}
    }

    void CheckGrounded()
    {
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundDistance, groundLayer);        
    }

    //void CheckTouchingWall()
    //{
    //    isTouchingWall = Physics.Raycast(wallCheck.position, Vector3.forward, wallDistance, wallLayer);
    //}

    //void CheckLanded()
    //{
    //    if (isGrounded && !inAir)
    //    {
    //        canWingBoost = false;
    //    }
    //}
}

