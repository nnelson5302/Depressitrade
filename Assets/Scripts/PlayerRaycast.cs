using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerRaycast : MonoBehaviour
{
    RaycastHit2D rayD, rayU, rayL, rayR;
    float d, u, l, r;
    Vector2 origin;
    Vector2 nullPoint = new Vector2(0, 0);

    public LayerMask layerMask;

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

        rayD = Physics2D.Raycast(origin + new Vector2(0, -.5f), Vector2.down, 5f, layerMask);
        rayU = Physics2D.Raycast(origin + new Vector2(0, .5f), -Vector2.down, 5f, layerMask);
        rayL = Physics2D.Raycast(origin + new Vector2(-.5f, 0), Vector2.left, 5f, layerMask);
        rayR = Physics2D.Raycast(origin + new Vector2(.5f, 0), -Vector2.left, 5f, layerMask);

        d = rayD.distance;
        u = rayU.distance;
        l = rayL.distance;
        r = rayR.distance;

        Debug.DrawRay(origin + new Vector2(0, -.5f), Vector2.down * 5f, Color.red);
        Debug.DrawRay(origin + new Vector2(0,.5f), -Vector2.down * 5f, Color.cyan);
        Debug.DrawRay(origin + new Vector2(-.5f, 0), Vector2.left * 5f, Color.cyan);
        Debug.DrawRay(origin + new Vector2(.5f, 0), -Vector2.left * 5f, Color.cyan);

        if (rayD.point == nullPoint)
            Debug.Log("Null");
        else
            Debug.Log(d);

    }
}
