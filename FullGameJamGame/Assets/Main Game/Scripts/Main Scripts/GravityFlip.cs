using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------
//                      Header
//
//  This is used to flip the gravity when the player
//  touches the water in the center of the map. 
//
//--------------------------------------------------------

public class GravityFlip : MonoBehaviour
{
    
    // This will hold the value for fade speed || how long it takes for the screen to either 
    // fade in or out. 
    [SerializeField]
    private float fFadeSpeed;

    // This is used to hold the value for the max alpha of the upper screen
    [SerializeField]
    private float fMaxAlphaUpper;

    // This is used to hold the value for the max alpha of the lower screen
    [SerializeField]
    private float fMaxAlphaLower;

    // This is used to check weather or not the gravity has been flipped or not. 
    private bool gravity_IsFlipped;

    // This is used to change which affect is displayed on the screen, this one is for the upper screen.
    private bool bUpperDecrease = false;
    private bool bUpperIncrease = false;

    // This is used to change which affect is displayed on the screen, this one is for the lower screen.
    private bool bLowerDecrease = false;
    private bool bLowerIncrease = false;

    // This will hold a reference to the player's game object.
    [SerializeField]
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        ResetFlip();
    }

    // Used to reset alpha values to initiation
    public void ResetFlip()
    {
        Renderer BackgroundLightRenderer = GameObject.FindWithTag("BackgroundLight").GetComponent<Renderer>();
        Renderer BackgroundDarkRenderer = GameObject.FindWithTag("BackgroundDark").GetComponent<Renderer>();
        BackgroundLightRenderer.enabled = true;
        BackgroundDarkRenderer.enabled = false;


        gravity_IsFlipped = false;
        Physics.gravity = new Vector3(0, -9.81f, 0);

        CameraMove CameraMove = GameObject.FindWithTag("MainCamera").GetComponent<CameraMove>();
        CameraMove.SetCameraOffSet(new Vector3(0, 3.5f, -8));

        //upper unrendered
        Renderer ScreenUpperRenderer = GameObject.FindWithTag("ScreenUpper").GetComponent<Renderer>();
        ScreenUpperRenderer.enabled = false;

        //upper alpha set to 0
        Color upper_color = ScreenUpperRenderer.material.color;
        upper_color.a = 0;
        ScreenUpperRenderer.material.color = upper_color;

        //lower rendered (default)

        //lower alpha set to 1 (default)
        Renderer ScreenLowerRenderer = GameObject.FindWithTag("ScreenLower").GetComponent<Renderer>();
        Color lower_color = ScreenLowerRenderer.material.color;
        lower_color.a = fMaxAlphaLower;
        ScreenLowerRenderer.material.color = lower_color;

        PlayerMovement PlayerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        PlayerMovement.ResetVelocity();

    }

    // Used to get is the gravity is currently flipped
    public bool GetGravity_IsFlipped()
    {
        return gravity_IsFlipped;
    }



    // This will trigger when the player collides with whatever the script is attacthed to. 
    private void OnTriggerExit(Collider collider)
    {
        
        // This will get access to the player movement script.
		PlayerMovement PlayerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        CameraMove CameraMove = GameObject.FindWithTag("MainCamera").GetComponent<CameraMove>();
        Renderer BackgroundLightRenderer = GameObject.FindWithTag("BackgroundLight").GetComponent<Renderer>();
        Renderer BackgroundDarkRenderer = GameObject.FindWithTag("BackgroundDark").GetComponent<Renderer>();

        // If the collider is the player : 
        if (collider.name == "Player")
        {
            
            // This will reverse the player's jump height so that it will be the inverse of what it currently is.
            PlayerMovement.jumpHeight = -PlayerMovement.jumpHeight;

            // If gravity flip is currently false : 
            if (gravity_IsFlipped == false)
            {
                BackgroundLightRenderer.enabled = false;
                BackgroundDarkRenderer.enabled = true;
                // Changes the current value for gravity. So the player goes up. 
                CameraMove.SetCameraOffSet(new Vector3(0, -2.5f, -8));
                Physics.gravity = new Vector3(0, 9.81f, 0);
                
                // Then gravity flip is changed to true.  
                gravity_IsFlipped = true;

                //upper rendered
                Renderer ScreenUpperRenderer = GameObject.FindWithTag("ScreenUpper").GetComponent<Renderer>();
                ScreenUpperRenderer.enabled = true;

                //upper alpha increases to 1
                bUpperIncrease = true;

                //lower alpha decreases to 0 and unrendered
                bLowerDecrease = true;

                //lower unrendered
            }

            // Otherwise : 
            else
            {
                BackgroundLightRenderer.enabled = true;
                BackgroundDarkRenderer.enabled = false;
                // Gravity flip is changed to false.
                gravity_IsFlipped = false;

                // and gravity is reset to its origional value.
                Physics.gravity = new Vector3(0, -9.81f, 0);
                CameraMove.SetCameraOffSet(new Vector3(0, 3.5f, -8));

                //upper alpha decrease to 0
                //upper unrendered
                bUpperDecrease = true;

                //lower rendered
                Renderer ScreenLowerRenderer = GameObject.FindWithTag("ScreenLower").GetComponent<Renderer>();
                ScreenLowerRenderer.enabled = true;

                bLowerIncrease = true;
                //lower alpha value increase to 1.
            }
        }
    }


    // This is used to change the current render effect on the upper screen.
    void UpperIncrease()
    {
        // This gets the upper screen's renderer component.
        Renderer ScreenUpperRenderer = GameObject.FindWithTag("ScreenUpper").GetComponent<Renderer>();

        // This will create a temp variable for the upper screen color.
        Color color = ScreenUpperRenderer.material.color;

        // This will change the colour of the screen depending upon the current fade speed.
        color.a += fFadeSpeed;

        // This sets color of the screen to be equal to the newly made color variable.
        ScreenUpperRenderer.material.color = color;

        // If the color variable has reached the maximum defined value for it's color:
        if (color.a >= fMaxAlphaUpper)
        {
            // Then the screen will stop increasing it's color.
            bUpperIncrease = false;
        }
    }

    // This is used to change the current render effect on the lower screen.
    void LowerDecrease()
    {
        // This gets the upper screen's renderer component.
        Renderer ScreenLowerRenderer = GameObject.FindWithTag("ScreenLower").GetComponent<Renderer>();

        // This will create a temp variable for the upper screen color.
        Color color = ScreenLowerRenderer.material.color;

        // This will change the colour of the screen depending upon the current fade speed.
        color.a -= fFadeSpeed;

        // This sets color of the screen to be equal to the newly made color variable.
        ScreenLowerRenderer.material.color = color;

        // If the color variable has reached the minimum defined value for it's color:
        if (color.a <= 0)
        {
            // It will stop decreasing. 
            bLowerDecrease = false;
            ScreenLowerRenderer.enabled = false;
        }
    }


    // This is used to change the current render effect on the upper screen.
    void UpperDecrease()
    {

        // This gets the upper screen's renderer component.
        Renderer ScreenUpperRenderer = GameObject.FindWithTag("ScreenUpper").GetComponent<Renderer>();

        // This will create a temp variable for the upper screen color.
        Color color = ScreenUpperRenderer.material.color;

        // This will change the colour of the screen depending upon the current fade speed.
        color.a -= fFadeSpeed;

        // This sets color of the screen to be equal to the newly made color variable.
        ScreenUpperRenderer.material.color = color;

        // If the color variable has reached the minimum defined value for it's color:
        if (color.a <= 0)
        {
            // It will stop decreasing.
            bUpperDecrease = false;
            ScreenUpperRenderer.enabled = false;
        }
    }

    // This is used to change the current render effect on the upper screen.
    void LowerIncrease()
    {
        // This gets the upper screen's renderer component.
        Renderer ScreenLowerRenderer = GameObject.FindWithTag("ScreenLower").GetComponent<Renderer>();

        // This will create a temp variable for the upper screen color.
        Color color = ScreenLowerRenderer.material.color;

        // This will change the colour of the screen depending upon the current fade speed.
        color.a += fFadeSpeed;

        // This sets color of the screen to be equal to the newly made color variable.
        ScreenLowerRenderer.material.color = color;

        // If the color variable has reached the minimum defined value for it's color:
        if (color.a >= fMaxAlphaLower)
        {
            // Then the screen will stop increasing it's color.
            bLowerIncrease = false;
        }
    }

    

    // Update is called once per frame
    void Update()
    {
       //Upper alpha increase to 1

        if (bUpperIncrease == true)
        {
            UpperIncrease();
        }

        //Lower alpha decrease to 0 (then unrendered)
        if (bLowerDecrease == true)
        {
            LowerDecrease();
        }


        //Upper alpha decrease to 0 (then unrendered)
        if (bUpperDecrease == true)
        {
            UpperDecrease();
        }

        //Lower alpha increase to 1
        if (bLowerIncrease == true)
        {
            LowerIncrease();
        }
    }
}

//--------------------------------------------------------
//                      Footer 
//
//              Code Written By Tom Woodley
//--------------------------------------------------------