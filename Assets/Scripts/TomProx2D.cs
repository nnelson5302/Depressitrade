using UnityEngine;
using UnityEngine.SceneManagement;

public class TomProx2D : MonoBehaviour
{
    public GameObject chatPanel;
    public GameObject tom;

    Vector2 tomPos;
    Vector2 playerPos;

    void Update()
    {
        playerPos = GetComponent<Transform>().position;
        tomPos = tom.GetComponent<Transform>().position;

        if (Vector3.Distance(tomPos, playerPos) <= 1.5f) //forms a line segment using the two points
        {
            chatPanel.SetActive(true); //shows the 'E' panel

        }
        else
        {
            chatPanel.SetActive(false); //makes the 'E' panel dissapear
        }
        if (Input.GetKey(KeyCode.E) == true && Vector3.Distance(tomPos, playerPos) <= 10) //checks to make sure "E" key is pressed and that you are less than 11 units away from Tom
        {
            SceneManager.LoadScene("Tom conversation"); //Opens the scene with Tom
        }
    }
}
