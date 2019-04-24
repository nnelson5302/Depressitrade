using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public int runSpeed;

    void Update()
    {
        Vector2 movement;


        if (Input.GetKey("left shift") == true) //the run option, uses the left shift key to change speed
            movement = new Vector2(Input.GetAxis("Horizontal") * runSpeed /*uses a & d keys*/, Input.GetAxis("Vertical") * runSpeed /*uses w & s keys*/); //run Vector3
        else
            movement = new Vector2(Input.GetAxis("Horizontal") * speed /*uses a & d keys*/, Input.GetAxis("Vertical") * speed /*uses w & s keys*/); //walk Vector3

        transform.GetComponent<Rigidbody2D>().velocity = movement; //assigns the input variable to the gameObject as a velocity
    }
}

