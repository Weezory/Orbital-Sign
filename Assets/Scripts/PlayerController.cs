using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 2f;
    public float jumpForce = 2f;
    public LayerMask whatIsGround;

    private float moveDirection;
    public bool isGrounded;
    [FormerlySerializedAs("isDoubleJumping")] public bool canDoubleJump;

    private Rigidbody2D playerRB;
    private SpriteRenderer spriteRenderer;
    private Vector2 startPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Left/Right Movement
        playerRB.linearVelocityX = moveDirection * moveSpeed;

        GroundCheck();
        
    }



    // Left & Right Movement
    private void OnMove(InputValue value)
    {
        // Read the X/Y inpit from keyboard
        Vector2 input = value.Get<Vector2>();
        moveDirection = input.x;

        // Do not flip is not pressing anything
        // = = - Comparison
        //! - No Equal
        if (input.x != 0)
        {
            spriteRenderer.flipX = (input.x < 0);
        }
        // Set the animator boolean to true or false
    }
    

    private void OnJump(InputValue value)
    {
        if (canDoubleJump == true)
        {
            //Ensures that player always jumps at a specfific speed
            playerRB.linearVelocityY = jumpForce;
        }

        if (isGrounded == false && canDoubleJump)
        {
            canDoubleJump = false;
        }
    }
    
    
    private void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position,
            Vector2.one * 0.1f, 
            0,
            Vector2.down,
            0.2f,
            whatIsGround.value
        );
        isGrounded = hit.collider != null;

        if (isGrounded)
        {
            canDoubleJump = true;
        }
        
    }

    public void die()
    {
        transform.position = RespawnController.Instance.respawnPoint.position;
        playerRB.linearVelocityY = 0;
    }
}
