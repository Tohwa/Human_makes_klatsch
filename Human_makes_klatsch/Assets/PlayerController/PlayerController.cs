using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    /* private GroundCheck groundCheck;
     private Rigidbody rb2D;
     private float thrust = 1f;
     public float jumpInput;
     public bool jumpRdy = false;
    */
                     public float xRange = 10.0f;
                     public float horizontalInput;
    [Range(1, 8)]     public int health = 4;
    [Range(1f, 100f)] public float speed = 5.0f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float rayLength;

    [SerializeField] private LayerMask groundLayers;
    //[SerializeField] private bool grounded;
    //[SerializeField] private bool hasJumped = true;

    private Vector2 _moveValue;
    
    private void Start()
    {
     /*   groundCheck = GetComponentInChildren<GroundCheck>();
        rb2D = GetComponent<Rigidbody>();
     */
    }

    private void Update()
    {
        /*  if (transform.position.x < -xRange) 
          {
              transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
          }

          if (transform.position.x > xRange)
          {
              transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
          }


          horizontalInput = Input.GetAxis("Horizontal");
          transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

         */
        GameManager.Instance.SetGroundedStatus(CheckGrounded());


        //Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.black);

        if(GameManager.Instance.GetGroundedStatus())
        {

            GameManager.Instance.SetJumpStatus(false);
        }
        



    }

    private bool CheckGrounded()
    {
        
        
        var hitInfo = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayers);
        return hitInfo.collider;
        

    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {

            if (!GameManager.Instance.GetJumpStatus())
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        if (context.canceled)
        {
            GameManager.Instance.SetJumpStatus(true);
        }
      
        //Debug.Log(context);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_moveValue.x * speed * Time.deltaTime, rb.velocity.y);
    }
    public void UpdateDirection(InputAction.CallbackContext context)
    {
        _moveValue = context.ReadValue<Vector2>();
    }

}
