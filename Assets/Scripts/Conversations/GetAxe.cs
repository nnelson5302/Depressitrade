using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Anything with underscores on either side of it should be replaced with something specific to the conversation
public class GetAxe : ConversationBase
{
    public GetAxe(
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

    int sexist = 0;
    string[] axes = {"Broken axe", "Cheap axe", "Standard axe", "Professional axe", "Luxury axe"};
    int AxeSelection = 1;

    void Start()
    {
        Choice1.SetActive(false);
        Choice2.SetActive(false);
        ContinueButton.SetActive(false);
        Button1.onClick.AddListener(ChooseOption1);
        Button2.onClick.AddListener(ChooseOption2);
        ContButton.onClick.AddListener(Continue);
    }

    public override void Part1()
    {
        NPCText.text = "Hi, my name is Dorothy. What brings you here?";
        PlayerText1.text = "You're a woman?";
        PlayerText2.text = "I need to buy an axe.";
        Choosing(Part2a, Part3);
    }

    void Part2a()
    {
        NPCText.text = "Yes, I'm a woman. Do you have a problem with that?";
        PlayerText1.text = "No. Of course not!";
        if (Globals.parentType == "daddy")
        {
            PlayerText2.text = "Actually, I do. Women should be at home, not working as a blacksmith.";
            Choosing(Part2b, Part2c);
        }
        else
        {
            PlayerText2.text = "Actually, I do. Women like us should stay at home, not go to work!";
            Choosing(Part2b, Part2g);
        }
    }

    void Part2b()
    {
        NPCText.text = "Good. Now that we have the right to vote, we should be able to work in whatever job we want to.";
        Reading(Part2i);
    }

    void Part2c()
    {
        sexist++;
        NPCText.text = "Well if you really have a problem with it, maybe I'll go back to my kitchen.";
        Reading(Part2d);
    }

    void Part2d()
    {
        NPCText.text = "And then you'd never be able get whatever it is you came here for.";
        PlayerText1.text = "I was only curious";
        PlayerText2.text = "I'm sorry";
        Choosing(Part2e, Part2f);
    }

    void Part2e()
    {
        NPCText.text = "The world is changing so you better get used to it.";
        Reading(Part2i);
    }

    void Part2f()
    {
        NPCText.text = "It's okay. But you're going to start seeing more women working jobs and you should get used to it.";
        Reading(Part2i);
    }

    void Part2g()
    {
        NPCText.text = "Then what are you doing here? You're working, aren't you?";
        PlayerText1.text = "Oh yeah, that's right";
        PlayerText2.text = "Yes but I'm not a blacksmith. That's not womanly";
        Choosing(Part2i, Part2h);
    }

    void Part2h()
    {
        NPCText.text = "How about I do what I want and you do what you want? It shouldn't matter if it's 'womanly.'";
        Reading(Part2i);

    }

    void Part2i()
    {
        NPCText.text = "Anyway, what can I do you for?";
        PlayerText1.text = "I came to buy an axe.";
        if (Globals.parentType == "daddy")
        {
            PlayerText2.text = "You could do me for free, baby.";
            Choosing(Part3, Part2j);
        }
        else
        {
            PlayerText2.text = "I have to get an axe for someone.";
            Choosing(Part3, Part3);
        }
    }

    void Part2j()
    {
        sexist++;
        NPCText.text = "Seriously? That's how you're going to treat me?";
        Reading(Part2k);
    }

    void Part2k()
    {
        NPCText.text = "That's not the way to treat anybody you want to do business with, no matter their gender.";
        Reading(Part2l);
    }

    void Part2l()
    {
        NPCText.text = "Leave my shop! I'm not going to sell you anything.";
        PlayerText1.text = "Okay, bimbo.";
        PlayerText2.text = "Please give me one more chance! My family's lives are at stake";
        Choosing(Part2m, Part2n);
    }

    void Part2m()
    {
        sexist++;
        Globals.GameOver
            ("You were sexist to the woman you were supposed to by an axe from and she refused you service.\n" +
            "Turns out being sexist doesn't work out too well for you.\n" +
            "You go back to the farm poor and your wife leaves you once you tell her why you don't have the money.\n" +
            "She and your kids live long, happy lives and you die alone.");
    }

    void Part2n()
    {
        NPCText.text = "Fine. For your family. What the hell are you here for?";
        ContinueText.text = "I need to buy an axe.";
        Reading(Part3);
    }

    void Part3()
    {
        NPCText.text = "Alright, I have five options for axes.";
        Reading(Part4);
    }

    void Part4()
    {
        NPCText.text = "The first is a broken axe. I don't know why you'd want it but I'd sell it to you for $3.";
        Reading(Part5);
    }

    void Part5()
    {
        if (sexist >= 2)
        {
            NPCText.text = "Next, I have a cheap axe that I'm selling for $6.50";
        }
        else
        {
            NPCText.text = "Next, I have a cheap axe that I'm selling for $6";
        }
        Reading(Part6);
    }

    void Part6()
    {
        if (sexist >= 2)
        {
            NPCText.text = "Third is the standard axe that'll cost you $8.25";
        }
        else
        {
            NPCText.text = "Third is the standard axe that'll cost you $8";
        }
        Reading(Part7);
    }

    void Part7()
    {
        if (sexist >= 2)
        {
            NPCText.text = "Fourth, I have a professional-grade axe for $11";
        }
        else
        {
            NPCText.text = "Fourth, I have a professional-grade axe for $10";
        }
        Reading(Part8);
    }

    void Part8()
    {
        if (sexist >= 2)
        {
            NPCText.text = "And finally, I have a luxury axe that you can buy for $13.25";
        }
        else
        {
            NPCText.text = "And finally, I have a luxury axe that you can buy for $13";
        }
        Reading(Part9);
    }

    void Part9()
    {
        NPCText.text = "So which axe would you like to buy?";
        Debug.Log("Choice1Func is");
        Debug.Log(Choice1Func == null);
        PlayerText1.text = axes[AxeSelection - 1];
        PlayerText2.text = "Next";
        choice = 999;
        Choosing();
    }

    void Part10a()
    {
        NPCText.text = "You want to buy the broken axe, huh? Interesting choice.";
        PlayerText1.text = "No! I changed my mind!";
        PlayerText2.text = "Yep, that's the one!";
        Choosing(Part9, Part11a);
    }

    void Part10b()
    {
        NPCText.text = "The cheap axe is probably worth your money. Is is the one?";
        PlayerText1.text = "No! I changed my mind!";
        PlayerText2.text = "Yep, that's the one!";
        Choosing(Part9, Part11b);
    }

    void Part10c()
    {
        NPCText.text = "This is a solid axe. Are you going to buy it?";
        PlayerText1.text = "No! I changed my mind!";
        PlayerText2.text = "Yep, that's the one!";
        Choosing(Part9, Part11c);
    }

    void Part10d()
    {
        NPCText.text = "Ah, the professional axe. It's great if you use your axe a lot. You're buying it?";
        PlayerText1.text = "No! I changed my mind!";
        PlayerText2.text = "Yep, that's the one!";
        Choosing(Part9, Part11d);
    }

    void Part10e()
    {
        NPCText.text = "Fancy! This is a real nice axe. Worth the money. Are you going to spend it?";
        PlayerText1.text = "No! I changed my mind!";
        PlayerText2.text = "Yep, that's the one!";
        Choosing(Part9, Part11e);
    }

    void Part11a()
    {
        Globals.axe++;
        NPCText.text = "Okay then... enjoy your broken axe, I guess.";
        Reading(EndConversation);
    }

    void Part11b()
    {
        Globals.axe++;
        NPCText.text = "Thanks for buying the axe! Just make sure you don't try too much with it. It isn't quite as strong as some other axes I sell.";
        Reading(EndConversation);
    }

    void Part11c()
    {
        Globals.axe++;
        NPCText.text = "Thanks for buying the axe! It's a great one!";
        Reading(EndConversation);
    }

    void Part11d()
    {
        Globals.axe++;
        NPCText.text = "Thanks for buying the professional axe! It's one of the best axes around!";
        Reading(EndConversation);
    }

    void Part11e()
    {
        Globals.axe++;
        NPCText.text = "Thanks for buying the luxury axe! It really is as good as it sounds.";
        Reading(EndConversation);
    }

    public override void ChooseOption1()
    {
        Debug.Log("You chose option 1");
        NotChoosing();
        if (choice == 999)
        {
            Debug.Log("Option 1 if 1");
            Globals.AxeType = AxeSelection;
            if (AxeSelection == 1)
            {
                Debug.Log("Part10a");
                Part10a();
            }
            else if (AxeSelection == 2)
            {
                Part10b();
            }
            else if (AxeSelection == 3)
            {
                Part10c();
            }
            else if (AxeSelection == 4)
            {
                Part10d();
            }
            else if (AxeSelection == 5)
            {
                Part10e();
            }
        }
    }

    public override void ChooseOption2()
    {
        NotChoosing();
        if (choice == 999)
        {
            if (AxeSelection >= 5)
            {
                AxeSelection = 1;
            }
            else
            {
                AxeSelection++;
            }
            Part9();
        }
    }
}