using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerRaycast : MonoBehaviour
{
    RaycastHit2D rayD, rayU, rayL, rayR;
    float d, u, l, r;
    Vector2 origin;
    Vector2 nullPoint = new Vector2(0, 0);
    Vector2 hitPoint;
    const float rayDist = 0.9f;
    const float offset = 0.25f;

    public LayerMask layerMask;
    public GameObject doorPanel;
    public Text doorText;

    void Start()
    {
        origin = transform.position;

        d = rayD.distance;
        u = rayU.distance;
        l = rayL.distance;
        r = rayR.distance;
    }

    void Update()
    {
        origin = transform.position;

        rayD = Physics2D.Raycast(origin + new Vector2(0, -offset), Vector2.down, rayDist, layerMask);
        rayU = Physics2D.Raycast(origin + new Vector2(0, offset), -Vector2.down, rayDist, layerMask);
        rayL = Physics2D.Raycast(origin + new Vector2(-offset, 0), Vector2.left, rayDist, layerMask);
        rayR = Physics2D.Raycast(origin + new Vector2(offset, 0), -Vector2.left, rayDist, layerMask);

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

        if(Vector3.Distance(origin, hitPoint) <= rayDist)
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
        /**/
        if (rayU.point == nullPoint)
            u = -1;
        else
            u = rayU.distance;
        /**/
        if (rayL.point == nullPoint)
            l = -1;
        else
            l = rayL.distance;
        /**/
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

        Debug.Log(hitPoint);
    }

    void doorEntry()
    {
        if (Input.GetKey(KeyCode.Q) == true && doorPanel.activeInHierarchy) {
            Debug.Log("oof");
            if (hitPoint.x == 46 && hitPoint.y == -30 /* && SceneManager.GetActiveScene().name == "2D Liberyville"*/)
            {
                SceneManager.LoadScene("Tom Inside");
                Debug.Log("True");
            }
            if (hitPoint.x == 44 && hitPoint.y == -28 /* && SceneManager.GetActiveScene().name == "2D Liberyville"*/)
            {
                SceneManager.LoadScene("2D Libertyville");
                Debug.Log("True");
            }
        }
    }
}
