using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Callbacks;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // Side Movement
    public int speed;
    public Animator MyAnim;
    public SpriteRenderer MySprite;


    // Jumping

    [SerializeField] float JumpTime;
    [SerializeField] float jumpForce;
    [SerializeField] float FallMultiplayer;
    [SerializeField] float JumpMultiplayer;
    public bool grounded;
    Vector2 vecGravity;
    public Rigidbody2D playerBody;



    bool isJumping;
    float jumpCounter;


    void Start()
    {
        MyAnim = GetComponent<Animator>(); 
        MySprite = GetComponent<SpriteRenderer>();
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        playerBody = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        // JUmping Code

        if (Input.GetKey(KeyCode.Space) && grounded){
            //player jumps
            MyAnim.SetTrigger("Jump");
            MyAnim.SetBool("Jumping", true);
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);
            isJumping = true;
            jumpCounter = 0;

        }

        jumpCounter += Time.deltaTime;

        if(jumpCounter >= JumpTime){
            isJumping = false;
        }


        if(playerBody.velocity.y < 0){
            playerBody.velocity -= vecGravity * FallMultiplayer * Time.deltaTime;
        }
        
        if(playerBody.velocity.y > 0 && isJumping){
            playerBody.velocity += vecGravity * JumpMultiplayer * Time.deltaTime;
        }

        if(Input.GetButtonUp("Jump")){
            isJumping = false;
            MyAnim.SetBool("Jumping", false);
        }
        

        
        float moveinput = Input.GetAxisRaw("Horizontal");

        // Flipping Character Direction

        if(moveinput < 0){
            MySprite.flipX = true;

        }
        else if (moveinput > 0){
            MySprite.flipX = false;
        }

        // Running animation

        if(moveinput == 0){
            MyAnim.SetBool("Running", false);
            MyAnim.SetBool("Walking", false);        }
        if(moveinput > 0 && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) ){
            MyAnim.SetBool("Running", true);
            MyAnim.SetBool("Walking", false);  
            
        }
        if(moveinput < 0 && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift)){
            MyAnim.SetBool("Running", true);
            MyAnim.SetBool("Walking", false);  
            
        }

        //Walking Animation

        if(moveinput > 0  && (!Input.GetKey(KeyCode.LeftShift))){
            MyAnim.SetBool("Walking", true);
            MyAnim.SetBool("Running", false);  
            
        }
        if(moveinput < 0 && (!Input.GetKey(KeyCode.LeftShift))){
            MyAnim.SetBool("Walking", true);
            MyAnim.SetBool("Running", false);  
            
        }


        if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift)){
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));

            
        }   
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift)){
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
            
        } 

        if(Input.GetKey(KeyCode.D) ){

            transform.Translate(new Vector2((speed - 2) * Time.deltaTime, 0));

            
        }   
        if(Input.GetKey(KeyCode.A)){
            transform.Translate(new Vector2(-(speed - 2) * Time.deltaTime, 0));
            
        } 


       
  
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            grounded = true;
            Debug.Log("Grounded");
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            grounded = false;
            Debug.Log("UnGrounded");
        }
    }

    

}

