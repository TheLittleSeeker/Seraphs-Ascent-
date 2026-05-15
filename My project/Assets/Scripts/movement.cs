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
    [SerializeField] float wallDistance = 0.2f;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] bool isTouchingWall;


    [SerializeField] AudioClip walk1SFX;
    [SerializeField] AudioClip walk2SFX;

    [SerializeField] bool canWingBoost;
    [SerializeField] bool canWallJump = false;
    //[SerializeField] bool inAir;
    float wallJumpDirection;

    Vector2 wallJumpForce = new Vector2(5f, 10f);



    public Rigidbody rb;
    AudioSource audioSource;
    Vector2 playerVelocity;

    float moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        canWingBoost = false;
        canWallJump = false;
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
        //WallCheck();
        if (isGrounded)
        {
            canWallJump = false;
            //inAir = false;
        }
    }

    void FixedUpdate()
    {
        HandleMove();

        if (WallCheck() && !isGrounded && moveInput != 0)
        {
            canWallJump = true;
            canWingBoost = false;
            wallJumpDirection = -transform.localScale.x;
        }

        //HandleWallJump();
    }

    private void HandleJump()
    {
        if (isGrounded || canWingBoost)
        {
            Vector2 playerVelocity = rb.linearVelocity;
            playerVelocity.y = 0f;
            rb.linearVelocity = playerVelocity;
            canWallJump = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            canWingBoost = !canWingBoost;
        }


        else if (canWallJump && !isGrounded)
        {
            rb.linearVelocity = new Vector2(wallJumpDirection * wallJumpForce.x, wallJumpForce.y);
            canWallJump = false;
        }
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
        moveInput = move.ReadValue<float>();
        playerVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        rb.linearVelocity = playerVelocity;

        if (moveInput != 0f)
        {
            float yRotation = moveInput > 0 ? 0f : 180f;
            rb.MoveRotation(Quaternion.Euler(0, yRotation, 0));
            //GetComponentInChildren<Animator>().SetTrigger("Moving");
        }
        //else
        //{
        //    GetComponentInChildren<Animator>().ResetTrigger("Moving");
        //}

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

    bool WallCheck()
    {
        return Physics.Raycast(wallCheck.position, Vector3.right, wallDistance, wallLayer) ||
               Physics.Raycast(wallCheck.position, Vector3.left, wallDistance, wallLayer);
    }

    //void CheckLanded()
    //{
    //    if (isGrounded && !inAir)
    //    {
    //        canWingBoost = false;
    //    }
    //}
}

