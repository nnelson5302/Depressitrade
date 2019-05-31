using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleConversation : ConversationBase
{
    //You will unfortunately have to copy this constructor into every conversation.
    //Make sure to change ExampleConversation to the name of the conversation
    public ExampleConversation(
        Text _NPCText,
        Text _PlayerText1,
        Text _PlayerText2,
        GameObject _Choice1,
        GameObject _Choice2,
        GameObject _ContinueButton,
        GameObject _NPC,
        GameObject _TextBox,
        GameObject _MoneyPanel,
        Text _MoneyText
    ) : base(
        _NPCText,
        _PlayerText1,
        _PlayerText2,
        _Choice1,
        _Choice2,
        _ContinueButton,
        _NPC,
        _TextBox,
        _MoneyPanel,
        _MoneyText
    )
    { }

    //Make sure to change TomText or DickText to NPCText!

    //Entry point of conversation
    //Must be declared as public override
    public override void Part1(){
        NPCText.text = "Hello there.";
        PlayerText1.text = "Hi";
        PlayerText2.text = "I hate you";
        Choosing(Part2a,Part2b);
    }

    void Part2a(){
        NPCText.text = "I am talking for a long time for no reason";
        Reading(Part3);
    }

    //You can also use the old style for choosing parts.
    void Part3(){
        NPCText.text = "I'm still talking...";
        cont = 4;
        Reading();
    }

    void Part4(){
        NPCText.text = "Thank you for listening to me. I shall reward you with $5.00 for being nice.";
        GiveMoney(500);
        Reading(Part5);
    }

    //You can end the conversation by making an extra part that calls EndConversation
    void Part5(){
        EndConversation();
    }

    //Or you can have Reading call it directly
    void Part2b(){
        NPCText.text = "What did I ever do to you? Goodbye.";
        Reading(EndConversation);
    }
	
	// Be sure to add override to Continue and ChooseOption1/2, otherwise they won't be called
    public override void Continue(){
        if(cont == 4){
            Part4();
        }
    }
}
