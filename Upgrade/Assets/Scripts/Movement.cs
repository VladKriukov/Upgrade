using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public bool leftShift;
    public bool jump;

    [SerializeField] private float walkingSpeed;
    [SerializeField] private float runningSpeed;
    [SerializeField] private float climbingSpeed;
    [SerializeField] private float jumpStrength;
    [SerializeField] private float fallStrength = 8f;
    [SerializeField] private float smallJumpStrength = 7f;

    //[SerializeField] float jumpCooldown;
    [SerializeField] private Vector3 checkStartPos = new Vector3(0, 0.5f, 0);

    [SerializeField] private float checkDistance = 0.1f;
    [SerializeField] private LayerMask lLayerMask;

    private float currentSpeed;
    private float cooldown;

    private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private float horizontalSpeed;
    private float verticalSpeed;
    private bool isFacingRight = true;
    private bool isGrounded;
    private bool canSprintInAir;
    private bool isClimbing;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!animator && GetComponent<Animator>() != null) animator = GetComponent<Animator>();
        GameManager.inGame = true;
    }

    private void Update()
    {
        if (GameManager.inGame == true)
        {
            rb.simulated = true;
            if (!GameManager.lockMovements)
            {
                CheckInput();
                CheckDirection();
                GroundCheck();
                Jump();
            }

            if (animator != null)
            {
                animator.SetFloat("Speed", Mathf.Abs(horizontalSpeed));
                animator.SetFloat("VerticalSpeed", verticalSpeed);
                animator.SetBool("IsGrounded", isGrounded);
            }

            if (cooldown > 0) cooldown -= Time.deltaTime;
        }
        else
        {
            rb.simulated = false;
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.lockMovements)
        {
            rb.velocity = new Vector2(horizontal * currentSpeed, rb.velocity.y);
            if (isClimbing) rb.velocity = new Vector2(rb.velocity.x, vertical * climbingSpeed);
        }
    }

    private void CheckInput()
    {
        //currentSpeed = leftShift ? runningSpeed : walkingSpeed;

        if (leftShift && !canSprintInAir && isGrounded)
        {
            currentSpeed = runningSpeed;
            Debug.Log("Sprinting");
        }
        else
        {
            currentSpeed = walkingSpeed;
        }
    }

    private void CheckDirection()
    {
        horizontalSpeed = rb.velocity.x;
        verticalSpeed = rb.velocity.y;

        if (horizontalSpeed < -0.1f)
        {
            horizontalSpeed = -horizontalSpeed;
            if (isFacingRight) Flip();
        }
        else if (horizontalSpeed != 0 && !isFacingRight) Flip();
    }

    private void Flip()
    {
        transform.localScale = Flipper.Flip(transform);
        isFacingRight = !isFacingRight;
    }

    private void Jump()
    {
        if (isGrounded && jump) JumpUp();
        if (!isClimbing)
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += new Vector2(0, -fallStrength * Time.deltaTime);
            }
            else if (rb.velocity.y > 0 && !jump)
            {
                rb.velocity += new Vector2(0, -smallJumpStrength * Time.deltaTime);
            }
        }
    }

    private void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - checkStartPos, -Vector2.up, checkDistance, lLayerMask);
        Debug.DrawLine(transform.position - checkStartPos, new Vector3(transform.position.x, transform.position.y - checkStartPos.y - checkDistance, transform.position.z), Color.red);
        isGrounded = hit.collider;
    }

    public void JumpUp(float additionalForce = 1)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpStrength * additionalForce);
        //cooldown = jumpCooldown;
        StopClimbing();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladders") && vertical != 0)
        {
            isClimbing = true;
            rb.gravityScale = 0;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladders")) StopClimbing();
    }

    void StopClimbing()
    {
        isClimbing = false;
        rb.gravityScale = 1;
    }
}