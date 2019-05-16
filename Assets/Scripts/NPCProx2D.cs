using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCProx2D : MonoBehaviour
{
    public GameObject chatPanel;
    public GameObject NPC;
	string ConversationScene = "Conversation";
	public string NPCName;

    Vector2 NPCPos;
    Vector2 playerPos;

    void Update()
    {
        playerPos = GetComponent<Transform>().position;
        NPCPos = NPC.GetComponent<Transform>().position;

        if (Vector3.Distance(NPCPos, playerPos) <= 1.5f) //forms a line segment using the two points
        {
            chatPanel.SetActive(true); //shows the 'E' panel

        }
        else
        {
            chatPanel.SetActive(false); //makes the 'E' panel dissapear
        }
        if (Input.GetKey(KeyCode.E) == true && Vector3.Distance(NPCPos, playerPos) <= 10) //checks to make sure "E" key is pressed and that you are less than 11 units away from Tom
        {
			Globals.ConversationPerson = NPCName;
            SceneManager.LoadScene(ConversationScene); //Opens the conversation scene
        }
    }
}
