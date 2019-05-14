using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    SpriteRenderer sprite;
    //The following is for PlayerRaycast
    RaycastHit2D rayD, rayU, rayL, rayR;
    float d, u, l, r; 
   Vector2 origin;
    Vector2 nullPoint = new Vector2(0, 0);
    Vector2 hitPoint;
    const float rayDist = 0.9f;
    const float offset = 0.25f;
    Scene curScene;

    public LayerMask doorLayer;
    public GameObject doorPanel;
    public Text doorText;

    //The following is for playerMove
    int speed = 5;
    int runSpeed = 7;
    Vector2 movement;


    void Start()
    {
        player.transform.position = new Vector2(41, -30); //Spawn at this location in the currently open scene (aka libertyville)
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(doorPanel);
        DontDestroyOnLoad(doorText);
        DontDestroyOnLoad(this);

        //The following is for PlayerRaycast
        curScene = SceneManager.GetActiveScene();


         d = rayD.distance;
         u = rayU.distance;
         l = rayL.distance;
         r = rayR.distance;
        
    }

    void Update()
    {
        //The following is for playerMove
        doorPanel = GameObject.Find("Door Panel");
       // doorText = doorPanel.transform.GetChild(0); ///uuuuuuuuuuuuuuuuuuuuuuuuhhhhhhhh
        Debug.Log(origin);
        if (Input.GetKey("left shift") == true) //the run option, uses the left shift key to change speed
            movement = new Vector2(Input.GetAxis("Horizontal") * runSpeed /*uses a & d keys*/, Input.GetAxis("Vertical") * runSpeed /*uses w & s keys*/); //run Vector3
        else
            movement = new Vector2(Input.GetAxis("Horizontal") * speed /*uses a & d keys*/, Input.GetAxis("Vertical") * speed /*uses w & s keys*/); //walk Vector3

        player.transform.GetComponent<Rigidbody2D>().velocity = movement; //assigns the input variable to the gameObject as a velocity
           //The following is for PlayerRaycast
           origin = player.GetComponent<Transform>().position;
           rayD = Physics2D.Raycast(origin + new Vector2(0, -offset), Vector2.down, rayDist, doorLayer);
           rayU = Physics2D.Raycast(origin + new Vector2(0, offset), -Vector2.down, rayDist, doorLayer);
           rayL = Physics2D.Raycast(origin + new Vector2(-offset, 0), Vector2.left, rayDist, doorLayer);
           rayR = Physics2D.Raycast(origin + new Vector2(offset, 0), -Vector2.left, rayDist, doorLayer);

           d = rayD.distance;
           u = rayU.distance;
           l = rayL.distance;
           r = rayR.distance;

           Debug.DrawRay(origin + new Vector2(0, -offset), Vector2.down * rayDist, Color.red);
           Debug.DrawRay(origin + new Vector2(0, offset), -Vector2.down * rayDist, Color.cyan);
           Debug.DrawRay(origin + new Vector2(-offset, 0), Vector2.left * rayDist, Color.cyan);
           Debug.DrawRay(origin + new Vector2(offset, 0), -Vector2.left * rayDist, Color.cyan);

           doorCheck();
           doorEnter();

           if (Vector3.Distance(origin, hitPoint) <= rayDist)
           {
               doorPanel.SetActive(true);
               doorText.GetComponent<Text>().text = "Q";
           }
           else
           {
               doorPanel.SetActive(false);
           }

           doorEntry();
    }

    void doorCheck()
    {
        if (rayD.point == nullPoint)
            d = -1;
        else
            d = rayD.distance;
        if (rayU.point == nullPoint)
            u = -1;
        else
            u = rayU.distance;
        if (rayL.point == nullPoint)
            l = -1;
        else
            l = rayL.distance;
        if (rayR.point == nullPoint)
            r = -1;
        else
            r = rayR.distance;
    }
    void doorEnter()
    {
        if (d > u && d > l && d > r)
            hitPoint = rayD.point;
        else if (u > d && u > l && u > r)
            hitPoint = rayU.point;
        else if (l > r && l > u && l > d)
            hitPoint = rayL.point;
        else if (r > d && r > u && r > l)
            hitPoint = rayR.point;
        else if (d == -1 && u == -1 && l == -1 && r == -1)
            hitPoint = new Vector2(0, 0);

        hitPoint.x = Mathf.FloorToInt(hitPoint.x);
        hitPoint.y = Mathf.FloorToInt(hitPoint.y);

        //Debug.Log(hitPoint);
    }
    void doorEntry()
    {
        //Debug.Log(curScene.name);
        if (Input.GetKey(KeyCode.Q) == true && doorPanel.activeInHierarchy)
        {
            //  Debug.Log("oof");
            if (hitPoint.x == 46 && hitPoint.y == -30 && curScene.name == "2D libertyville")
            {
                SceneManager.LoadScene("Tom Inside");
                //  Debug.Log("True");
            }

            if (hitPoint.x == 44 && hitPoint.y == -28 && curScene.name == "Tom Inside")
            {
                SceneManager.LoadScene("2D Libertyville");
                transform.position = new Vector2(46.5f, -29.5f);
                // Debug.Log("True");
            }
        }
    } 
}
