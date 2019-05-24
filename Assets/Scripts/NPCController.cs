using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Transform OrgNPC; //Drag NPC prefab to
    float speed = 0.025f; //Speed of NPCs
    Vector3 initPos = new Vector3(0f, 0f, 0f); //NPCs inital spawning position
    Transform[] NPCs = new Transform[15]; //List of the transforms of NPCs so we can change position
    float[] npcDirX = new float[15]; //X direction NPC moves in
    float[] npcDirY = new float[15]; //Y direction NPC moves in
    Vector3[] npcMov = new Vector3[15]; //Vector used to add position to NPC
    bool[] mov = new bool[15]; //Stores whether or not each NPC is moving
    public Transform NPCParent;

    // Start is called before the first frame update
    void Start()
    {
       for (int i = 0; i < 15; i++) //Make this for loop go for however many NPCs you want
        {
            NPCs[i] = OrgNPC;
            NPCs[i] = Instantiate(OrgNPC); //These 2 lines instatiate the NPCs from the prefab

            initPos.x = Random.Range(-35, 35);
            initPos.y = Random.Range(-35, 35); //These 2 lines pick a random x and y for the specified range
            NPCs[i].localPosition = initPos; //This sets the generated position to the actual position

            mov[i] = (Random.value >= 0.5f); //Generates random number 0-1, true if >=0.5, false otherwise
            NPCs[i].SetParent(NPCParent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 60 == 0) //Set framerate to 60fps
        {
            for (int i = 0; i < 15; i++) 
            {
                mov[i] = (Random.value >= 0.5f); // 50/50 true/false

                if (mov[i] == true)
                {
                    npcDirX[i] = Random.Range(-1f, 1f);
                    npcDirY[i] = Random.Range(-1f, 1f); //Set direction to not zero, moves in a random direction
                }

                else
                {
                    npcDirX[i] = 0;
                    npcDirY[i] = 0; //Sets direction to 0 so NPC doesn't move

                }
            }
        }

        for (int i = 0; i < 15; i++)
        {
            npcMov[i] = new Vector3(npcDirX[i] * speed, npcDirY[i] * speed, 0f); //Sets amount to move by
            NPCs[i].position += npcMov[i]; //Adds position for motion
        }
    }
}
