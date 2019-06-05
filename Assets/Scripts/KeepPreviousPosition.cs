using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPreviousPosition : MonoBehaviour
{
    public Transform player;

    public void Awake()
    {
        if (Globals.leftConversation == true)
        {
            Vector3 temp;
            temp.x = Globals.PlayerPositionX;
            temp.y = Globals.PlayerPositionY;
            temp.z = -0.1f;
            player.transform.position = temp;
        }
        Globals.leftConversation = false;
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKey("E") == true)
        {
            Globals.PlayerPositionX = player.position.x;
            Globals.PlayerPositionY = player.position.y;
        }
    }*/
}
