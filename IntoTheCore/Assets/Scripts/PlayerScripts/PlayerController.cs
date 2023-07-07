
using UnityEngine;

public class PlayerController : MonoCache
{
    private CharacterController controller;
    [SerializeField] float speed;
    
    [Header("Gravity")]
    [SerializeField] float gravity;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask whatIsGround;

    private Vector3 fallVelocity;
    private float adjustingGravity = -0.2f;
    private bool moveLock = false;
    private void Start()
    {
        controller = GetComponent<CharacterController>();

    }
    public override void OnUpdate()
    {
        if (moveLock)
        {
            return;
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 velocity = (transform.forward * vertical + transform.right * horizontal) * speed;
        controller.Move(velocity * Time.deltaTime);
        GravityCheck();
        controller.Move(fallVelocity * Time.deltaTime);
    }
    void GravityCheck()
    {
        if (!IsGrounded())
        {
            fallVelocity.y += gravity * Time.deltaTime;
        }
        else
        {
            fallVelocity.y = adjustingGravity;
        }
    }
    public void DisableControl()
    {
        moveLock = true;
    }
    public void EnableControl()
    {
        moveLock = false;
    }
    public bool IsGrounded()
    {
        return Physics.CheckSphere(GroundCheck.position, checkRadius, whatIsGround);
    }
    public void ReverseGravity()
    {
        gravity *= -1;
        adjustingGravity *= -1;
    }
}
