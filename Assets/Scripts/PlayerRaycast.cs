using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerRaycast : MonoBehaviour
{
    RaycastHit2D rayD;
    RaycastHit2D rayU;
    RaycastHit2D rayL;
    RaycastHit2D rayR;

    float d;
    float u;
    float l;
    float r;

    Vector2 origin;
    public LayerMask layerMask;
    
    void Update()
    {
        origin = transform.position;

        rayD = Physics2D.Raycast(origin, Vector2.down, 10f, layerMask);
        rayU = Physics2D.Raycast(origin, Vector2.up, 10f, layerMask);
        rayL = Physics2D.Raycast(origin, Vector2.left, 10f, layerMask);
        rayR = Physics2D.Raycast(origin, Vector2.right, 10f, layerMask);

        d = rayD.distance;
        u = rayU.distance;
        l = rayL.distance;
        r = rayR.distance;

        Debug.Log(d); //Doesn't work :(
    }
}
