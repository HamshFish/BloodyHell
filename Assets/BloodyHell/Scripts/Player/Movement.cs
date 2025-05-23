using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform groundCheck;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private CapsuleCollider capsuleCollider;
    [SerializeField] private Camera cam;

    [Header("Speed")]
    [SerializeField] public float walkSpeed = 10f;
    [SerializeField] public float sprintSpeed = 40;
    public float currentSpeed;


    [Header("Jumping")]
    [SerializeField] private float jumpPower;
    [SerializeField] private float gravityUp, gravityDown;
    [SerializeField] private int jumpsAllowed = 2;
    private int jumpsRemaining;

    [Header("State Testing")]
    [SerializeField] private State currentState;

    public enum State
    {
        Walk,
        Rise,
        Fall,
        Run
    }


    private void Update()
    {
        switch (currentState)
        {
            case State.Walk:
                WalkState();
                break;
            case State.Rise:
                RiseState();
                break;
            case State.Fall:
                FallState();
                break;
        }

    }

    private void WalkState()
    {
        // while on ground we have max jumps
        jumpsRemaining = jumpsAllowed;

        // gets our input direction from local space
        Vector3 inputMovement = GetMovementFromInput();

        // increase our movement speed
        inputMovement *= currentSpeed;

        // as long as were on the ground dont build up vertical speed
        inputMovement.y = Mathf.Clamp(rb.linearVelocity.y - gravityDown * Time.deltaTime, 0f, float.PositiveInfinity);

        //apply movement to rigidbody
        rb.linearVelocity = inputMovement;

        if (!IsGrounded())
        {
            // we should be falling
            currentState = State.Fall;

            // they can only jump once if fell off ground
            jumpsRemaining -= 1;
        }
        else
        {
            if (Input.GetButton("Jump"))
            {
                //go to rise state
                RiseAtSpeed(jumpPower);
                jumpsRemaining -= 1;
            }
        }
    }
    private void RiseState()
    {
        Vector3 inputMovement = GetMovementFromInput();
        inputMovement *= currentSpeed;

        //were rising now so use up gravity
        inputMovement.y = rb.linearVelocity.y - gravityUp * Time.deltaTime;

        rb.linearVelocity = inputMovement;

        // if linearVelocity y is less than 0, were falling
        if (rb.linearVelocity.y < 0f)
        {
            currentState = State.Fall;
        }

        //check for double jump
        if (jumpsRemaining > 0 && Input.GetButtonDown("Jump"))
        {
            RiseAtSpeed(jumpPower);
            jumpsRemaining -= 1;
        }
    }
    private void FallState()
    {
        Vector3 inputMovement = GetMovementFromInput();
        inputMovement *= currentSpeed;

        //were falling now so use down gravity
        inputMovement.y = rb.linearVelocity.y - gravityDown * Time.deltaTime;


        rb.linearVelocity = inputMovement;


        if (IsGrounded())
        {
            currentState = State.Walk;
        }

        //check for double jump
        if (jumpsRemaining > 0 && Input.GetButtonDown("Jump"))
        {
            RiseAtSpeed(jumpPower);
            jumpsRemaining -= 1;
        }
    }

    private void RiseAtSpeed(float speed)
    {
        //give our rigid body upward speed
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, speed, rb.linearVelocity.y);

        currentState = State.Rise;
    }

    private Vector3 GetMovementFromInput()
    {

        Vector2 inputThisFrame = new Vector2();

        inputThisFrame.x = Input.GetAxis("Horizontal");
        inputThisFrame.y = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(inputThisFrame.x, 0, inputThisFrame.y);

        if(moveDirection != Vector3.zero)
        {
            moveDirection.Normalize();
        }

        moveDirection = cam.transform.TransformDirection(moveDirection);

        moveDirection.y = 0f;
        moveDirection = moveDirection.normalized * moveDirection.magnitude;

        rb.AddForce(moveDirection * currentSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);

       if (IsGrounded())
        {
            Vector3 goalMovement = moveDirection * currentSpeed;
            Vector3 newVelocity = Vector3.Lerp(rb.linearVelocity, goalMovement, Time.deltaTime * 1f);
            rb.linearVelocity = newVelocity;

        }


        return moveDirection;
    }


    private bool IsGrounded()
    {
        return Physics.OverlapSphere(groundCheck.position, 0.1f,groundMask).Length > 0;
        
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;

        jumpsRemaining = jumpsAllowed;
    }


}
