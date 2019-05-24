using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TomConvo2 : ConversationBase
{
    public TomConvo2(
		Text _NPCText,
		Text _PlayerText1,
		Text _PlayerText2,
		GameObject _Choice1,
		GameObject _Choice2,
		GameObject _ContinueButton,
        GameObject _MoneyPanel,
        Text _MoneyText
	) : base(
        _NPCText,
        _PlayerText1,
        _PlayerText2,
        _Choice1,
        _Choice2,
        _ContinueButton,
        _MoneyPanel,
        _MoneyText
    ) {}

    public override void Part1()
    {
		if(!Globals.HadFirstDickConversation) {
			NPCText.text = "Did you go to Potato Hill yet?";
			ContinueText.text = "No.";
			Reading(Part2z);
		} else {
			Globals.HadSecondTomConversation = true;
			NPCText.text = "Did you get me some wood?";
			PlayerText1.text = "Yes, of course.";
			PlayerText2.text = "No.";
			choice = 1;
			Choosing();
		}
    }
	
	void Part2z(){
		NPCText.text = "Well, what are you waiting for? Just open your map and click on Potato Hill to go there.";
		Reading(EndConversation);
	}
	
    void Part2a()
    {
        if(Globals.wood >= 20){
            NPCText.text = "Great! I owe you $3.50 then! Thank you! I'll inform you if I require your assistance in the future.";
            cont = 1;
            Reading();
        } else {
            NPCText.text = "So... Where is it then? You don't actually have it???";
            cont = 2;
            Reading();
        }
    }

    void Part2b()
    {
        NPCText.text = "You're useless. This is why you were put up for adoption. Get out of Libertyville and don't ever come back!";
        cont = 2;
        Reading();
    }

    void Part3()
    {
        GiveMoney(350);
		Globals.wood -= 20;
        cont = 3;
        Reading();
    }

    public override void ChooseOption1()
    {
        if (choice == 1)
        {
            Part2a();
        }
    }

    public override void ChooseOption2()
    {
        if (choice == 1)
        {
            Part2b();
        }
    }

    public override void Continue()
    {
        if (cont == 1)
        {
            Part3();
        }
        else if (cont == 2)
        {
            Globals.GameOver("You failed to complete a simple task given to you.");
        }
        else if (cont == 3)
        {
            EndConversation();
        }
    }
}
