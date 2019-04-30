using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCollisionDetector : MonoBehaviour
{
    public Rigidbody2D NPC; //Get the rigidbody of the NPCs 

    void OnCollisionEnter2D(Collision2D hitPlayer) //Detect a collision
    {
        if (hitPlayer.gameObject.tag.Equals("Player") == true) //If collision is with something tagged player
        {
            NPC.bodyType = RigidbodyType2D.Static; //Set to static
        }
    }

    void OnCollisionExit2D(Collision2D hitPlayer) //Detect the end of a collision
    {
        if (hitPlayer.gameObject.tag.Equals("Player") == true) //If collision is with something tagged player
        {
            NPC.bodyType = RigidbodyType2D.Dynamic; //Set to dynamic
        }
    }
}
