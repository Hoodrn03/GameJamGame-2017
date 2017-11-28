using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------
//                      Header
//
//     This is used to make the player move and 
//      allows them to jump. 
//
//--------------------------------------------------

public class PlayerMovement : MonoBehaviour
{

    // Used to as a value for the player's Speed.
    [SerializeField]
    private float PlayerSpeed;

    // Used to as a value for the player's Jump Height.
    [SerializeField]
    public float jumpHeight;

    // Used to reference gravity flip.
    GravityFlip GravityFlip;

    // Used to control the player's velocity.
    private Vector3 playerVelocity;


    //left and right control
    private Vector3 currentScale;           //used to alter transform
    private bool facingRight = true;        //holds directions of player

    //Check if grounded (on floor)

    private bool isGrounded;

    //animation components
    private Animator playerAnimator;
    private float movementSpeed = 0;        //variables that relate to parameters
    private bool jumped = false;
    int jumpHash = Animator.StringToHash("Jump");
    bool InDark;
    private Quaternion rotationAmount;
    private Vector3 displacementAmount;

    // Used to check weather the player is in the up or down world.
    private bool HasRotated1 = false;
    private bool HasRotated2 = true;


    // Use this for initialization
    void Start()
    {
        // These are used for the default sets and gets. 
        currentScale = transform.localScale;

        playerVelocity = GetComponent<Rigidbody>().velocity;

        playerAnimator = GetComponent<Animator>();

        GravityFlip = GameObject.FindWithTag("Water").GetComponent<GravityFlip>();

    }


    void FixedUpdate()
    {
        currentScale = transform.localScale;

        if (Input.GetAxis("Horizontal") > 0 && !facingRight)
            FlipHorizontal();
        else if (Input.GetAxis("Horizontal") < 0 && facingRight)
            FlipHorizontal();


        if (GravityFlip.GetGravity_IsFlipped() == true && HasRotated1 == false)
        {


            transform.Rotate(180, 180, 0);
            transform.Translate(0, -2, 0);


            playerAnimator.SetBool("InDark", true);
            HasRotated1 = true;
            HasRotated2 = false;



        }
        if (GravityFlip.GetGravity_IsFlipped() == false && HasRotated2 == false)
        {
            transform.Rotate(-180, -180, 0);
            transform.Translate(0, -2, 0);
            playerAnimator.SetBool("InDark", false);
            HasRotated1 = false;
            HasRotated2 = true;


        }




    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Platform")
        {
            isGrounded = true;

        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Platform")
        {
            isGrounded = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        playerVelocity = GetComponent<Rigidbody>().velocity;
        playerVelocity.z = 0;
        if (Input.GetAxis("Horizontal") != 0)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(PlayerSpeed * Input.GetAxis("Horizontal"), playerVelocity.y, playerVelocity.z);
            float move = Input.GetAxis("Horizontal");
            playerAnimator.SetFloat("Speed", move);
            //set movement speed that will be used for the transitions of the player states in the animations
            movementSpeed = Mathf.Abs(Input.GetAxis("Horizontal"));

        }


        if (isGrounded == true)
        {
            //character jumps
            if (Input.GetButtonDown("Jump"))
            {
                playerAnimator.SetTrigger(jumpHash);
                CharacterJump();
            }
        }
    }


    private void CharacterJump()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(playerVelocity.x, jumpHeight, playerVelocity.z);

    }

    private void FlipHorizontal()
    {
        facingRight = !facingRight;
        currentScale.z *= -1;
        transform.localScale = currentScale;
    }

    // Reset the velocity of the player - used on player death
    public void ResetVelocity()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Swapping the players jump height - used on death in the dark world
    public void SwapJumpHeight()
    {
        jumpHeight = -jumpHeight;
    }
}

//--------------------------------------------------------
//                         Header
//
//              Code Written By Ben Sparkes 
//--------------------------------------------------------