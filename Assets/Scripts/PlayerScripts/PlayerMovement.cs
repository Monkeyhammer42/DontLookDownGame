using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;

    private Rigidbody2D myBody;
    private Animator anim;

    public Transform groundCheckPosition;
    public LayerMask groundLayer;
    
    public LayerMask LeftSlopeLayer;
    public LayerMask RightSlopeLayer;
    private bool isGrounded;
    private bool isSloperight;
    private bool isSlopeleft;
    private bool jumped;
    private float jumpPower = 8f;
    public static int movespeed = 5;
    public Vector3 userDirection = Vector3.right;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
    void Start()
    {

    }

    void Update()
    {
        CheckIfGrounded();
        CheckIfSlope();



    }
    void FixedUpdate()
    {
        PlayerWalk();
        PlayerJump();
        PlayerSprint();
        PlayerSneak();
    }
    void PlayerWalk()
    {
    float h = Input.GetAxisRaw("Horizontal");
        if (h > 0) {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
            ChangeDirection (1);
        }
        else if (h < 0)
        {
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
            ChangeDirection (-1);
        }
        else {
            myBody.velocity = new Vector2 (0f, myBody.velocity.y); }

        anim.SetInteger("Speed", Mathf.Abs((int)myBody.velocity.x));

    }
    void ChangeDirection(int direction) {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }
    void DropDown(float height)
    {
        myBody.position = myBody.position + new Vector2(0f, height);
        
    }
    void CheckIfGrounded()
    {
        isGrounded = Physics2D.Raycast(groundCheckPosition.position, Vector2.down, 0.1f, groundLayer);
        if (isGrounded)
        {
            if (jumped)
            {
                jumped = false;

                anim.SetBool("Jump", false);
            }
        }

    }
    void PlayerJump()
    {
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                jumped = true;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpPower);
                anim.SetBool("Jump", true);
            }
        }else if(isSloperight){
            anim.SetBool("Jump", false);
        }
    }
   
    void PlayerSprint()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = 7.5f;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))

            {
                speed = 5f;
            }

        }
        else if (!Input.GetKey(KeyCode.LeftShift))

        {
            speed = 5f;
        }
    }

    void PlayerSneak()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.CapsLock))
            {
                speed = 2.5F;
                anim.SetBool("IsSneaking", true);
            }
            else if (Input.GetKeyUp(KeyCode.CapsLock))

            {
                speed = 5F;
                anim.SetBool("IsSneaking", false);
            }
        }
    }
    void Slideright()
    {

        transform.Translate(userDirection * movespeed * Time.deltaTime);

    }
    void LiftUp(float Raised)
    {
        myBody.position = myBody.position + new Vector2(0f, Raised);
        
    }

    void CheckIfSlope()
    {
        isSloperight = Physics2D.Raycast(groundCheckPosition.position, Vector2.down, 0.5f, RightSlopeLayer);
        isSlopeleft = Physics2D.Raycast(groundCheckPosition.position, Vector2.down, 0.5f, LeftSlopeLayer);
        if (isSlopeleft&&!isSloperight)
        {
              anim.SetBool("Slide", true);
            ChangeDirection(-1);
            DropDown(-.1f);
            
        }
        else if (!isSlopeleft &&!isSloperight)
        {
            anim.SetBool("Slide", false);
           
        }
       
        if (isSloperight&&!isSlopeleft)
        {


            anim.SetBool("Slide", true);
            Slideright();
            ChangeDirection(1);


        }
        else if (!isSloperight&&!isSlopeleft)
        {
            anim.SetBool("Slide", false);
            

        }

    }








} //class end

