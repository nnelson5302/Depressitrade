using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DickConvo1 : ConversationBase
{
	public DickConvo1(
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
		Globals.HadFirstDickConversation = true;
        DickSize(35);
        NPCText.text = "Hi, my name is Richard but you can call me Dick. Do you need some wood?";
        PlayerText1.text = "Yeah. I heard you have the best wood around.";
        PlayerText2.text = "Tom sent me here to get some.";
        choice = 1;
        Choosing();
    }

    void Part2a()
    {
        NPCText.text = "Why thank you! I pride myself on my wood.";
        cont = 1;
        Reading();
    }

    void Part2b()
    {
        NPCText.text = "Ah, yes. Tom has always liked my wood.";
        cont = 1;
        Reading();
    }

    void Part3()
    {
        NPCText.text = "What kind of wood are you looking for?";
        PlayerText1.text = "I was told to get 20 planks of wood.";
        PlayerText2.text = "Um... well... I'm actually interested in more than one type of wood...";
        choice = 2;
        Choosing();
    }

    void Part3b()
    {
        DickSize(25);
        NPCText.text = "Well I have lots of kinds of wood. I have planks of all sizes, blocks, boards, and more. What kinds interest you?";
        PlayerText1.text = "Oops, I misspoke earlier. I was sent to get 20 planks.";
        PlayerText2.text = "Well if those are the only options, I just want 20 planks.";
        choice = 3;
        Choosing();
    }

    void Part4a()
    {
        NPCText.text = "Great! That will be three dollars.";
        PlayerText1.text = "Three dollars? Please, sir. Tom's only paying me $5.00!";
        PlayerText2.text = "No way! You won't be able to scam me you Twit!!";
        choice = 4;
        Choosing();
    }

    void Part4b()
    {
        DickSize(35);
        NPCText.text = "Er... okay then. That will be three dollars.";
        PlayerText1.text = "Three dollars? Please, sir. Tom's only paying me $5.00!";
        PlayerText2.text = "No way! You won't be able to scam me you Twit!!";
        choice = 4;
        Choosing();
    }

    void Part5a()
    {
        NPCText.text = "Well, you seem nice. For you I could do $2.75.";
        PlayerText1.text = "Thank you, sir. It means a lot!";
        PlayerText2.text = "Lower.";
        choice = 5;
        Choosing();
    }

    void Part5b()
    {
        NPCText.text = "Do manners mean nothing to you, child?? Kids these days...";
        cont = 2;
        Reading();
    }

    void Part5c()
    {
        NPCText.text = "You know what?? Just to teach you a lesson, I'm going to charge you $3.10";
        PlayerText1.text = "No way, fopdoodle!";
        PlayerText2.text = "Fine.";
        choice = 6;
        Choosing();
    }
    
    void Part5d()
    {
        NPCText.color = new Color(255, 0, 30);
        NPCText.text = "Hi, it's the game developers taking over for a bit.";
        PlayerText1.text = "Wut?";
        PlayerText2.text = "K...";
        choice = 7;
        Choosing();
    }

    void Part5e()
    {
        NPCText.text = "Why did you even play this game if you're going to keep saying no?";
        PlayerText1.text = "Cuz it's fun to be mean.";
        PlayerText2.text = "I'm sorry. I didn't mean to hurt your feelings.";
        choice = 8;
        Choosing();
    }

    void Part5f()
    {
        DickSize(25);
        NPCText.text = "I could make your family die right now becuase you don't get any money but I'm feeling nice.";
        cont = 3;
        Reading();
    }

    void Part5g()
    {
        NPCText.text = "I'm fine. Just don't let it happen again.";
        cont = 3;
        Reading();
    }

    void Part5h()
    {
        DickSize(30);
        NPCText.text = "So I'm just going to pretend you agreed and we'll get on with the game, k? Byeee";
        PlayerText1.text = "k.";
        PlayerText2.text = "Okey Dokey Artichokey!";
        choice = 9;
        Choosing();
    }

    void Part5i()
    {
        NPCText.text = "And just like that, it's back up to $3.00.";
        PlayerText1.text = "Oh come on lubberwort!";
        PlayerText2.text = "Alright, I guess I can do $3.00.";
        choice = 10;
        Choosing();
    }

    void Part6a()
    {
        NPCText.text = "Alright, it's a done deal! $2.75 it is!";
		cont = 4;
		SpendMoney(275);
		Globals.wood += 20;
		Reading();
    }

    void Part6b()
    {
        DickSize(30);
        NPCText.text = "Thank god you're at least somewhat agreeable. Well here's your wood. Good day!";
		cont = 4;
		SpendMoney(310);
		Globals.wood += 20;
		Reading();
    }

    void Part6c()
    {
        DickSize(25);
        NPCText.color = new Color(0, 0, 0);
        NPCText.text = "The devs got involved? Well at least they talked some sense into ya. Take your wood and leave.";
		cont = 4;
		SpendMoney(310);
		Globals.wood += 20;
		Reading();
    }

    void Part6d()
    {
        NPCText.text = "I'm only so generous and $3.00 is a fair price anyway. Good luck!";
		cont = 4;
		SpendMoney(300);
		Globals.wood += 20;
		Reading();
    }

    public override void ChooseOption1()
    {
        NotChoosing();
        if (choice == 1)
        {
            Part2a();
        }
        else if (choice == 2)
        {
            Part4a();
        }
        else if (choice == 3)
        {
            Part4b();
        }
        else if (choice == 4)
        {
            Part5a();
        }
        else if (choice == 5)
        {
            Part6a();
        }
        else if (choice == 6)
        {
            Part5d();
        }
        else if (choice == 7)
        {
            Part5e();
        }
        else if (choice == 8)
        {
            Part5f();
        }
        else if (choice == 9)
        {
            Part6c();
        }
        else if (choice == 10)
        {
            Part5b();
        }
    }

    public override void ChooseOption2()
    {
        NotChoosing();
        if (choice==1)
        {
            Part2b();
        }
        else if (choice == 2)
        {
            Part3b();
        }
        else if (choice == 3)
        {
            Part4b();
        }
        else if (choice == 4)
        {
            Part5b();
        }
        else if (choice == 5)
        {
            Part5i();
        }
        else if (choice == 6)
        {
            Part6b();
        }
        else if (choice == 7)
        {
            Part5e();
        }
        else if (choice == 8)
        {
            Part5g();
        }
        else if (choice == 9)
        {
            Part6c();
        }
        else if (choice == 10)
        {
            Part6d();
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
            Part5c();
        }
        else if (cont == 3)
        {
            Part5h();
        }
		else if (cont == 4)
		{
			EndConversation();
		}
    }

    void DickSize(int girth)
    {
        NPCText.fontSize = girth;
    }
}
