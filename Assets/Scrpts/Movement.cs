using Unity.Cinemachine;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public CinemachineCamera vcam;
    public float cameraOffsetMultiplier = 2;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool jumpRequest;
    private float moveInput;
    private bool facingRight = true;
    private CinemachinePositionComposer composer; 

    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
       
       composer = vcam.GetCinemachineComponent(CinemachineCore.Stage.Body) as CinemachinePositionComposer;;
       rb = GetComponent<Rigidbody2D>();
       rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {   
       
        moveInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if (moveInput > 0 && !facingRight)
            Flip();
        else if (moveInput < 0 && facingRight)
            Flip();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position,0.5f,groundLayer);

        if(Input.GetButtonDown("Jump") && isGrounded)
            {   
                jumpRequest = true;
                // Debug.Log("jump");
            }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed,rb.linearVelocity.y);  
        if(jumpRequest)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x,jumpForce);
        jumpRequest = false;    
        
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
         // Set the tracked object offset
        composer.TargetOffset = new Vector3(transform.localScale.x*cameraOffsetMultiplier, 1.5f, 0f); // 
    }
}
