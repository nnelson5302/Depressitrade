using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TomConvo1 : ConversationBase {
    
    public TomConvo1(
        Text _NPCText,
        Text _PlayerText1,
        Text _PlayerText2,
        GameObject _Choice1,
        GameObject _Choice2,
        GameObject _ContinueButton,
        GameObject _NPC,
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
        _MoneyPanel,
        _MoneyText
    )
    { }

    bool rememberedName;

    public override void Part1()
    {
		Globals.HadFirstTomConversation = true;
        NPCText.fontSize = 35;
        NPCText.text = "Hey! It's nice to see you again!";
        PlayerText1.text = "It's been a while, Tom!";
        PlayerText2.text = "Who are you?";
        choice = 1;
        Choosing();
    }
    
    void Part2a()
    {
        NPCText.text = "Well some of us have succesful jobs.";
        cont = 1;
        Reading();
    }
    
    void Part2b()
    {
        NPCText.text = "I'm your friend Tom! It figures you'd forget me already.";
        cont = 1;
        Reading();
    }
    
    void Part3()
    {
        NPCText.fontSize = 25;
        NPCText.text = "I heard that your family is going through some tough times. I could pay you to do a few jobs for me.";
        PlayerText1.text = "I don't need your help.";
        PlayerText2.text = "What do you want me to do?";
        choice = 2;
        Choosing();
    }

    void Part3c()
    {
        if (rememberedName==true)
        {
            NPCText.text = "You're not in a place to be picky with the state of your farm.";
        }
        if (rememberedName == false)
        {
            NPCText.text = "Come on! Help a friend out! I mean so much to you that you forgot my name, remember?";
        }
        cont = 2;
        Reading();
    }

    void Part4()
    {
        NPCText.fontSize = 26;
        NPCText.text = "I'm running low on wood. If you can get me 20 planks of wood. I'll pay you $6.00.";
        PlayerText1.text = "Only $6.00!?!";
        PlayerText2.text = "Thanks, Tim!";
        choice = 3;
        Choosing();
    }

    void Part5a()
    {
        NPCText.text = "Times are hard. Take what you can get, Ninnyhammer!";
		ContinueText.fontSize = 60;
		ContinueText.text = "Where can I get wood?";
        Reading(Part6);

    }

    void Part5b()
    {
        if (rememberedName == true)
        {
            NPCText.text = "My name's Tom! Wow! I thought we were friends!!";
        }
        if (rememberedName == false)
        {
            if (playerName == "Mildred")
            {
                NPCText.text = "Ugh! Whatever. It's fine. Have fun, Mildew.";
            }
            else if (playerName == "Walter")
            {
                NPCText.text = "Ugh! Whatever. It's fine. Have fun, Waldo.";
            }
        }
        cont = 3;
		ContinueText.fontSize = 60;
		ContinueText.text = "Where can I get wood?";
        Reading(Part6);
    }
	
	void Part6()
	{
		NPCText.text = "You can buy some from my friend Dick, in Potato Hill. Use your map to get there.";
		//ContinueText.text = "Continue";
		cont = 4;
		Reading();
	}
    
    public override void ChooseOption1()
    {
        NotChoosing();
        if (choice==1)
        {
            Part2a();
            rememberedName = true;
        }
        else if (choice == 2)
        {
            Part3c();
        }
        else if (choice == 3)
        {
            Part5a();
        }
    }
    
    public override void ChooseOption2() {
        NotChoosing();
        if (choice == 1)
        {
            Part2b();
            rememberedName = false;
        }
        else if (choice == 2)
        {
           Part4();
        }
        else if (choice == 3)
        {
            Part5b();
        }
    }

    public override void Continue()
    {
        NotReading();
        if (cont == 1)
        {
            Part3();
        }
        else if (cont == 2)
        {
            Part4();
        }
        else if(cont == 3)
        {
			EndConversation();
        }
		else if(cont == 4)
		{	
			EndConversation();
		}
    }
}