using System;
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
    public GameObject NPC;
    public GameObject MoneyPanel;
    public Text MoneyText;

    public void Start(){
        Type conversationType = null;
        switch(Globals.ConversationPerson){
            case "Example":
                conversationType = typeof(ExampleConversation);
                break;
            case "Tom":
                if(!Globals.HadFirstTomConversation){
                    //conversationType = typeof(TomConvo1);
                    conversationType = typeof(TomConvo4);
                }
                else {
                    conversationType = typeof(TomConvo2);
                }
                break;
			case "Dick":
                if (!Globals.HadFirstDickConversation)
                {
                    conversationType = typeof(DickConvo1);
                }
                else if (Globals.axe>=1)
                {
                    conversationType = typeof(GiveAxe);
                }
                else
                {
                    conversationType = typeof(DickWantsAxe);
                }
				break;
        }
        ConversationBase conversation = Activator.CreateInstance(conversationType, NPCText, PlayerText1, PlayerText2, Choice1, Choice2, ContinueButton, NPC, MoneyPanel, MoneyText) as ConversationBase;
        conversation.Part1();
    }
}
