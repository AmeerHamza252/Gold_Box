using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] LayerMask aimlayerMask;
    Animator animator;
    void Awake() => animator = GetComponent<Animator>();
    
        
    
    //private float speed = 40.0f;
    //private float rotationspeed = 720.0f;
    //private Rigidbody playerRb;
    //private float forwardSpeed = 400.0f;
    //private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        //playerRb = GetComponent<Rigidbody>();
        //_anim = GetComponentInChildren<Animator>();
        //if (_anim == null) 
        //{
        //    Debug.Log("Animator is null");
        //}
    }

    // Update is called once per frame
    void Update()
    {

        AimTowardsMouse();

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        if (movement.magnitude > 0)
        {
            movement.Normalize();
            movement *= speed * Time.deltaTime;
            transform.Translate(movement, Space.World);
        }
        float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
        float velocityx = Vector3.Dot(movement.normalized, transform.right);

        animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
        animator.SetFloat("VelocityX", velocityZ, 0.1f, Time.deltaTime);



        //RightMovement();
        //LeftMovement();
        //ForwardMovement();
        //BackwardMovement();
        //Movement();
    }
    void AimTowardsMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, aimlayerMask))
        {
            var direction = hitInfo.point - transform.position;
            direction.y = 0f;transform.forward = direction;
            direction.Normalize();


        }
    }
    //void Movement()
    //{
    //    playerRb.AddForce(Vector3.forward * speed * Time.deltaTime);
    //    horizontalInput = Input.GetAxis("Horizontal");
    //    verticalInput = Input.GetAxis("Vertical");

    //    transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
    //    transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

    //    Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
    //    movement.Normalize();
    //    transform.Translate(movement * speed * Time.deltaTime);

    //    if (movement != Vector3.zero)
    //    {
    //        transform.forward = movement;
    //        Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
    //        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationspeed * Time.deltaTime);
    //    }
    //}

    //void RightMovement() 
    //{
    //    if (Input.GetKey(KeyCode.RightArrow)) 
    //    {
    //        Debug.Log("here in right movement");
    //        playerRb.AddForce(Vector3.right * speed * Time.deltaTime,ForceMode.Impulse);
    //    }
    //}

    //void LeftMovement()
    //{
    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        Debug.Log("here in Left movement");
    //        playerRb.AddForce(Vector3.left * speed * Time.deltaTime, ForceMode.Impulse);
    //    }
    //}

    //void ForwardMovement()
    //{
    //    if (Input.GetKey(KeyCode.UpArrow))
    //    { 
    //        Debug.Log("here in forward movement");
    //        playerRb.AddForce(Vector3.forward * forwardSpeed * Time.deltaTime, ForceMode.Impulse);
    //    }
    //}

    //void BackwardMovement()
    //{
    //    if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        Debug.Log("here in backward movement");
    //        playerRb.AddForce(Vector3.back * forwardSpeed * Time.deltaTime, ForceMode.Impulse);
    //    }
    //}
}
