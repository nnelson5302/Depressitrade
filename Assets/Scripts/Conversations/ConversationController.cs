using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationController : MonoBehaviour
{
    public Text NPCText;
    public Text PlayerText1;
    public Text PlayerText2;
    public GameObject Choice1;
    public GameObject Choice2;
    public GameObject ContinueButton;
    public GameObject MoneyPanel;
    public Text MoneyText;

    public void Start(){
        if(Globals.ConversationPerson == "Example"){
            ExampleConversation conversation = new ExampleConversation(NPCText, PlayerText1, PlayerText2, Choice1, Choice2, ContinueButton, MoneyPanel, MoneyText);
            conversation.Part1();
        }
    }
}
