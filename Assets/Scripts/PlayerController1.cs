using UnityEngine;

public class PlayerController1 : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    //[SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    //Refrences

    private CharacterController controller;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerMovement();
        Move();
    }

    void PlayerMovement()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //float  verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position,groundCheckDistance,groundMask);

        //make sure if player is fully grounded

        if (isGrounded && velocity.y < 0) 
        {
            velocity.y = -2.0f;
        }
        float moveZ = Input.GetAxis("Vertical");
        moveDirection = new Vector3(0, 0, moveZ);

        //Setting player forward direction

        moveDirection = transform.TransformDirection(moveDirection);

        //checking if player is grounded

        if (isGrounded) 
        {
            Debug.Log("is grounded");
            if (moveDirection != Vector3.zero)
            {
                WalkForward();
            }
            else if (moveDirection == Vector3.zero) 
            {
                Idle();
            }

            moveDirection *= moveSpeed;
        }

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void WalkForward() 
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("VelocityZ",1,0.1f, Time.deltaTime);
    }

    private void Idle() 
    {
        anim.SetFloat("Velocity",0,0.1f,Time.deltaTime);
    }

}
