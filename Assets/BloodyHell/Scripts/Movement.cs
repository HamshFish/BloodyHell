using Mono.Cecil;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region State Setup

    public enum State
    {
        Walk,
        Rise,
        Fall,
        Run
    }

    [SerializeField] private State currentState;

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



    #endregion

    #region Temp Varibles

    [SerializeField] private float speedWalk;
    [SerializeField] private float jumpPower;

    [SerializeField] private float gravityUp, gravityDown;

    [SerializeField] LayerMask groundMask;

    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;

    [SerializeField] private int jumpsAllowed = 2;
    private int jumpsRemaining;

    #endregion

    #region General

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;

        jumpsRemaining = jumpsAllowed;
    }



    #endregion

    #region Moving


    private Vector3 GetMovementFromInput()
    {

        Vector2 inputThisFrame = new Vector2();

        inputThisFrame.x = Input.GetAxis("Horizontal");
        inputThisFrame.y = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(inputThisFrame.x, 0, inputThisFrame.y);

        // moveDirection = transform.TransformDirection(moveDirection);
    }

    

    #endregion
}
