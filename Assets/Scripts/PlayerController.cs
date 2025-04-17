using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpHigh = 15f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    private bool isGrounded;
    private Rigidbody2D rb;
    private Animator animator;
    public Joystick joystick;
    private float moveHorizontal;
    private float moveVertical;

    public Audio audio;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        UpdateAnimation();
    }

    private void HandleMovement()
    {
        moveHorizontal = joystick.Horizontal;
        rb.linearVelocity = new Vector2(moveHorizontal * moveSpeed, rb.linearVelocity.y);
        if (moveHorizontal > 0)
        {
            transform.localScale = new Vector3(2, 2, 1);
        }
        else if (moveHorizontal < 0) 
        {
            transform.localScale = new Vector3(-2,2,1);
        }
    }

    public void HandleJump()
    {
        moveVertical = joystick.Vertical;
        if (moveVertical>0.1 && isGrounded) 
        {
            audio.PlayJumpSound();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHigh);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }

    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
        bool isJumping = !isGrounded;
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping",isJumping);
    }
}
