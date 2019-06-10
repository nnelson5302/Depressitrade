using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player2D : MonoBehaviour
{
    public int speed;
    public int runSpeed;
    public Animator MildredAnimation;

    void Update()
    {
        if (!Globals.FreezePlayerPosition)
        {
            Vector2 movement;


            if (Input.GetKey("left shift") == true)
            {
                //the run option, uses the left shift key to change speed
                movement = new Vector2(Input.GetAxis("Horizontal") * runSpeed /*uses a & d keys*/, Input.GetAxis("Vertical") * runSpeed /*uses w & s keys*/); //run Vector3
                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {
                    MildredAnimation.SetFloat("speed", runSpeed);
                }
                else
                {
                    MildredAnimation.SetFloat("speed", 0);
                }
            }
            else
            {
                movement = new Vector2(Input.GetAxis("Horizontal") * speed /*uses a & d keys*/, Input.GetAxis("Vertical") * speed /*uses w & s keys*/); //walk Vector3
                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {
                    MildredAnimation.SetFloat("speed", speed);
                    if(Input.GetAxis("Horizontal") < 0)
                    {
                        MildredAnimation.SetInteger("direction", 4);
                    }
                    else if (Input.GetAxis("Horizontal") > 0)
                    {
                        MildredAnimation.SetInteger("direction", 3);
                    }
                    else if (Input.GetAxis("Vertical") < 0)
                    {
                        MildredAnimation.SetInteger("direction", 1);
                    }
                    else if (Input.GetAxis("Vertical") > 0)
                    {
                        MildredAnimation.SetInteger("direction", 2);
                    }
                }
                else
                {
                    MildredAnimation.SetFloat("speed", 0);
                }
            }
            /*
            if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
            {
                MildredAnimation.SetInteger("direction", 1);
            }
            else if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
            {
                Debug.Log("Setting direction to 2");
                MildredAnimation.SetInteger("direction", 2);
            }
            else if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
            {
                Debug.Log("Setting direction to 3");
                MildredAnimation.SetInteger("direction", 4);
            }
            else if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
            {
                Debug.Log("Setting direction to 4");
                MildredAnimation.SetInteger("direction", 3);
            }


            if (Input.GetKeyUp("down") || Input.GetKeyUp("s"))
            {
                if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
                {
                    MildredAnimation.SetInteger("direction", 1);
                }
                else if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
                {
                    Debug.Log("Setting direction to 2");
                    MildredAnimation.SetInteger("direction", 2);
                }
                else if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
                {
                    Debug.Log("Setting direction to 3");
                    MildredAnimation.SetInteger("direction", 4);
                }
                else if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
                {
                    Debug.Log("Setting direction to 4");
                    MildredAnimation.SetInteger("direction", 3);
                }
            }
            else if (Input.GetKeyUp("up") || Input.GetKeyUp("w"))
            {
                if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
                {
                    MildredAnimation.SetInteger("direction", 1);
                }
                else if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
                {
                    Debug.Log("Setting direction to 2");
                    MildredAnimation.SetInteger("direction", 2);
                }
                else if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
                {
                    Debug.Log("Setting direction to 3");
                    MildredAnimation.SetInteger("direction", 4);
                }
                else if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
                {
                    Debug.Log("Setting direction to 4");
                    MildredAnimation.SetInteger("direction", 3);
                }
            }
            else if (Input.GetKeyUp("left") || Input.GetKeyUp("a"))
            {
                if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
                {
                    MildredAnimation.SetInteger("direction", 1);
                }
                else if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
                {
                    Debug.Log("Setting direction to 2");
                    MildredAnimation.SetInteger("direction", 2);
                }
                else if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
                {
                    Debug.Log("Setting direction to 3");
                    MildredAnimation.SetInteger("direction", 4);
                }
                else if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
                {
                    Debug.Log("Setting direction to 4");
                    MildredAnimation.SetInteger("direction", 3);
                }
            }
            else if (Input.GetKeyUp("right") || Input.GetKeyUp("d"))
            {
                if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
                {
                    MildredAnimation.SetInteger("direction", 1);
                }
                else if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
                {
                    Debug.Log("Setting direction to 2");
                    MildredAnimation.SetInteger("direction", 2);
                }
                else if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
                {
                    Debug.Log("Setting direction to 3");
                    MildredAnimation.SetInteger("direction", 4);
                }
                else if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
                {
                    Debug.Log("Setting direction to 4");
                    MildredAnimation.SetInteger("direction", 3);
                }
            }
            */
            transform.GetComponent<Rigidbody2D>().velocity = movement; //assigns the input variable to the gameObject as a velocity

        }
    }
}
