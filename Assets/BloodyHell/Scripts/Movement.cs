using Mono.Cecil;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] LayerMask groundMask;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private CapsuleCollider capsuleCollider;

    [Header("Speed")]
    [SerializeField] private float walkSpeed;

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
                break;
            case State.Rise:
                break;
            case State.Fall:
                break;
            case State.Run:
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
        inputMovement *= walkSpeed;

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
        inputMovement *= walkSpeed;

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
        inputMovement *= walkSpeed;

        //were falling so use gravity down
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

        //transform.localEulerAngles = new Vector3(0, 0, inputThisFrame.y);

        moveDirection = transform.TransformDirection(moveDirection);

        return moveDirection;
    }


    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, capsuleCollider.height / 2f + 0.1f, groundMask);
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
