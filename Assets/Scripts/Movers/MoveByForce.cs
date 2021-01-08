using UnityEngine;


/**
 *  This component allows the player to add force to its object using the arrow keys.
 *  Works with a 3D RigidBody.
 */
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TouchDetector))]
public class MoveByForce : MonoBehaviour
{
    [Tooltip("The horizontal force that the player's feet use for walking, in newtons.")]
    [SerializeField] float walkForce = 5f;

    [Tooltip("The vertical force that the player's feet use for jumping, in newtons.")]
    [SerializeField] float jumpImpulse = 5f;

    [Range(0, 1f)]
    [SerializeField] float slowDownAtJump = 0.5f;

    private Rigidbody rb;

    public float turnSmoothTime = 0.001f;
    private float turnSmoothVelocity;
    public ForceMode walkForceMode = ForceMode.Impulse;
    public ForceMode jumpForceMode = ForceMode.Impulse;
    private bool playerWantsToJump = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
   
    }


    private void Update()
    {
        // Keyboard events are tested each frame, so we should check them here.
        if (Input.GetKeyDown(KeyCode.Space))
            playerWantsToJump = true;

        
         // allow to walk and jump 
           //float horizontal = Input.GetAxis("Horizontal");
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(vertical, 0f, horizontal).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);


                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                rb.AddForce(moveDir.normalized * walkForce, walkForceMode);

            }
            if (direction.magnitude == 0)
            {
                rb.velocity = new Vector3(rb.velocity.x * 0.99f, rb.velocity.y * 0.99f, rb.velocity.z * 0.99f); 
            }

                if (playerWantsToJump)
            {            // Since it is active only once per frame, and FixedUpdate may not run in that frame!

                rb.velocity = new Vector3(rb.velocity.x * slowDownAtJump, rb.velocity.y, rb.velocity.z);
                rb.AddForce(new Vector3(0, jumpImpulse, 0), jumpForceMode);
                playerWantsToJump = false;
            }
        }
    
}