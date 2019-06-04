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
    public GameObject TextBox;
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
                    conversationType = typeof(TomConvo1);
                }
                else if (!Globals.HadSecondTomConversation)
                {
                    conversationType = typeof(TomConvo2);
                }
                else if (!Globals.HadThirdTomConversation && Globals.HadFirstGangConversation)
                {
                    conversationType = typeof(TomConvo4);
                }
                else {
                    conversationType = typeof(TomConvo3);
                }
                break;
			case "Dick":
                if (!Globals.HadFirstDickConversation)
                {
                    conversationType = typeof(DickConvo1);
                }
                else if (!Globals.HadSecondDickConversation)
                {
                    conversationType = typeof(DickWantsAxe);
                }
                else if (Globals.axe>=1)
                {
                    conversationType = typeof(GiveAxe);
                }
                else
                {
                    conversationType = typeof(Dick);
                }
				break;
            case "Dorothy":
                if (!Globals.GotAxe)
                {
                    conversationType = typeof(GetAxe);
                }
                else
                {
                    conversationType = typeof(Dorothy);
                }
                break;
            case "El Pacone":
                if (!Globals.HadFirstGangConversation)
                {
                    conversationType = typeof(GangConvo1);
                }
                else
                {
                    conversationType = typeof(GangBlurb1);
                }
                break;
        }
        ConversationBase conversation = Activator.CreateInstance(conversationType, NPCText, PlayerText1, PlayerText2, Choice1, Choice2, ContinueButton, NPC, TextBox, MoneyPanel, MoneyText) as ConversationBase;
        conversation.Part1();
    }
}
