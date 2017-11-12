using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GravityFlip : MonoBehaviour
{

    //PlayerMovement PlayerMovement;


    public bool gravity_IsFlipped = false;

    bool bUpperIncrease = false;
    bool bLowerDecrease = false;
    bool bUpperDecrease = false;
    bool bLowerIncrease = false;

    [SerializeField]
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        //upper unrendered
        Renderer ScreenUpperRenderer = GameObject.Find("ScreenUpper").GetComponent<Renderer>();
        ScreenUpperRenderer.enabled = false;
        //upper alpha set to 0
        Color upper_color = ScreenUpperRenderer.material.color;
        upper_color.a = 0;
        ScreenUpperRenderer.material.color = upper_color;

        //lower rendered (default)
        //lower alpha set to 1 (default)



    }

    private void OnTriggerExit(Collider collider)
    {
  
        PlayerMovement PlayerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        



        if (collider.name == "Player")
        {
            PlayerMovement.jumpHeight = -PlayerMovement.jumpHeight;
            if (gravity_IsFlipped == false)
            {
                Physics.gravity = new Vector3(0, 9.81f, 0);
                gravity_IsFlipped = true;

                //upper rendered
                Renderer ScreenUpperRenderer = GameObject.Find("ScreenUpper").GetComponent<Renderer>();
                ScreenUpperRenderer.enabled = true;

                //upper alpha increases to 1
                bUpperIncrease = true;



                //lower alpha decreases to 0 and unrendered
                bLowerDecrease = true;

                //lower unrendered
                





            }
            else
            {
                gravity_IsFlipped = false;
                Physics.gravity = new Vector3(0, -9.81f, 0);

                //upper alpha decrease to 0
                //upper unrendered
                bUpperDecrease = true;
              


                //lower rendered
                Renderer ScreenLowerRenderer = GameObject.Find("ScreenLower").GetComponent<Renderer>();
                ScreenLowerRenderer.enabled = true;

                bLowerIncrease = true;
                //lower alpha value increase to 1


            }
        }
    }

    void UpperIncrease()
    {
        Renderer ScreenUpperRenderer = GameObject.Find("ScreenUpper").GetComponent<Renderer>();
        Color color = ScreenUpperRenderer.material.color;
        color.a += 0.1f;
        ScreenUpperRenderer.material.color = color;

        if (color.a >= 1)
            bUpperIncrease = false;
          
    }

    void LowerDecrease()
    {
        Renderer ScreenLowerRenderer = GameObject.Find("ScreenLower").GetComponent<Renderer>();
        Color color = ScreenLowerRenderer.material.color;
        color.a -= 0.1f;
        ScreenLowerRenderer.material.color = color;

        if (color.a <= 0)
            bLowerDecrease= false;
            ScreenLowerRenderer.enabled = false;

    }

    void UpperDecrease()
    {
        Renderer ScreenUpperRenderer = GameObject.Find("ScreenUpper").GetComponent<Renderer>();
        Color color = ScreenUpperRenderer.material.color;
        color.a -= 0.1f;
        ScreenUpperRenderer.material.color = color;

        if (color.a <= 0)
        {
            bUpperDecrease = false;
            ScreenUpperRenderer.enabled = false;
        }
            

    }

    void LowerIncrease()
    {
        Renderer ScreenLowerRenderer = GameObject.Find("ScreenLower").GetComponent<Renderer>();
        Color color = ScreenLowerRenderer.material.color;
        color.a += 0.1f;
        ScreenLowerRenderer.material.color = color;

        if (color.a >= 1)
            bLowerIncrease = false;
        

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