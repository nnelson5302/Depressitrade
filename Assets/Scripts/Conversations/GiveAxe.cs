using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Anything with underscores on either side of it should be replaced with something specific to the conversation
public class GiveAxe : ConversationBase
{
    public GiveAxe(
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
    )
    { }

    void Start()
    {
        Choice1.SetActive(false);
        Choice2.SetActive(false);
        ContinueButton.SetActive(false);
        Button1.onClick.AddListener(ChooseOption1);
        Button2.onClick.AddListener(ChooseOption2);
        ContButton.onClick.AddListener(Continue);
    }

    //Make different parts of the story in voids

    //First part no matter what axe you bought
    override public void Part1()
    {
        if (Globals.dickfriend == true)
        {
            NPCText.text = "It's good to see you agian! Did you get me an axe?";
        }
        else
        {
            NPCText.text = "You're back! Did you get me an axe?";
        }
        PlayerText1.text = "No. I got myself an axe.";
        PlayerText2.text = "Yes, I have it right here.";
        choice = 1;
        Choosing();
    }

    void Part2a()
    {
        NPCText.text = "Is this some sort of joke?";
        PlayerText1.text = "Yeah, I'm just joking. I got you an axe.";
        PlayerText2.text = "Nope! I'm keeping the axe for myself.";
        Choosing(Part2c, Part2b);
    }

    void Part2b()
    {
        NPCText.text = "What about your family? And what about me?";
        PlayerText1.text = "I don't care. I got a nice axe so I'm keeping it.";
        PlayerText2.text = "Sorry, that was just a joke. Here's your axe.";
        Choosing(Part2d, Part2c);
    }
    void Part2c()
    {
        NPCText.text = "Great! Thank you so much! I really didn't want to have to travel to Beardsville myself.";
        cont = 1;
        Reading();
    }

    void Part2d()
    {
        Globals.GameOver(
            "You keep the axe and never get the money that your family needs.\n" +
            "You and your axe live happily ever after while your family dies of starvation."
        );
    }

    //Conversation if player bought the broken axe
    void Part101()
    {
        NPCText.text = "What kind of axe did you get me?";
        PlayerText1.text = "I bought you the cheapest axe I could find: a broken axe!";
        PlayerText2.text = "(Lie): He said it was a cheap axe.";
        choice = 101;
        Choosing();
    }

    void Part102a()
    {
        NPCText.text = "Why would you do that? The whole reason I wanted an axe is because mine was broken!";
        cont = 101;
        Reading();
    }

    void Part102b()
    {
        if (Globals.dickfriend == true)
        {
            NPCText.text = "What the hell? I thought we were friends! You're a terrible friend. I want you to know that. Leave and don't ever talk to me again.";
        }
        else
        {
            NPCText.text = "What the hell? I thought I could trust you! You're going to have to find somebody else to work for. Don't ever come back here!!";
        }
        Reading(ULoseBoiorGurl);
    }

    void ULoseBoiorGurl() {
        Globals.GameOver
            ("You bought a broken axe for Dick and he didn't pay you anything for it.\n" +
            "You go back to the farm poor and you and your " + Globals.spouseType + " die of malnourishment\n" +
            "Your kids grow up as orphans.");
    }
       
    void Part102c()
    {
        NPCText.text = "Do you really think I'm that doltish? That dimwitted? This axe is broken! It's not even a cheap axe!";
        Reading(Part102b);
    }

    //Conversation if player bought the cheap axe
    void Part201()
    {
        NPCText.text = "What kind of axe did you get me?";
        PlayerText1.text = "It was on the cheaper end. He said it was a cheap axe.";
        PlayerText2.text = "(Lie): I bought the standard axe.";
        Choosing(Part210a, Part220a);
    }

    void Part210a()
    {
        if (Globals.dickfriend == true)
        {
            NPCText.text = "Really? I would've liked a better axe.";
        }
        else
        {
            NPCText.text = "Really? I asked for a good axe. I don't want a cheap axe!";
        }
        Reading(Part210b);
    }

    void Part210b()
    {
        NPCText.text = "This is my job! I need a better axe than this!";
        Reading(Part210c);
    }
    
    void Part210c()
    {
        if (Globals.dickfriend == true)
        {
            NPCText.text = "Still, we're friends. And I'm feeling generous. I'll pay you 6 more dollars.";
            GiveMoney(600);
            ContinueText.text = "Exit Conversation";
            Reading(EndConversation);
        }
        else
        {
            NPCText.text = "I guess I'll give you something though. Here, take 5 more dollars. I'm feeling generous.";
            GiveMoney(500);
            ContinueText.text = "Exit Conversation";
            Reading(EndConversation);
        }
    }

    void Part220a()
    {
        NPCText.text = "Hmm, I guess they look a little different now. Styles change I suppose.";
        Reading(Part220b);
    }

    void Part220b()
    {
        NPCText.text = "Well that should be a good enough axe. Here, I'll pay you $8.50 more for it.";
        GiveMoney(850);
        ContinueText.text = "Exit Conversation";
        Reading(EndConversation);
    }


    //Conversation if player bought the standard axe
    void Part301()
    {
        NPCText.text = "What kind of axe did you get me?";
        PlayerText1.text = "I bought the standard axe.";
        PlayerText2.text = "(Lie): I bought the professional axe. One of her best!";
        Choosing(Part310, Part320);
    }

    void Part310()
    {
        NPCText.text = "Okay. That's a decent axe.";
        Reading(Part311);
    }

    void Part311()
    {
        NPCText.text = "Thanks for getting it for me. I really didn't want to travel to Beardsville.";
        Reading(Part312);
    }
    
    void Part312()
    {
        NPCText.text = "And it's a pretty good axe. I'll pay you $8.50 more for it.";
        GiveMoney(850);
        ContinueText.text = "Exit Conversation";
        Reading(EndConversation);
    }

    void Part320()
    {
        NPCText.text = "Okay. That looks a little different than I last remember it.";
        Reading(Part321);
    }

    void Part321()
    {
        if (Globals.dickfriend == true)
        {
            NPCText.text = "But we're friends and you wouldn't lie to me. She probably just changed the style.";
        }
        else
        {
            NPCText.text = "But I trust that you wouldn't lie to me. She probably just changed the style.";
        }
        Reading(Part322);
    }

    void Part322()
    {
        NPCText.text = "This is exactly the axe I wanted! I'll pay you $11.50 more.";
        GiveMoney(1150);
        ContinueText.text = "Exit Conversation";
        Reading(EndConversation);
    }

    //Conversation if player bought the professional axe
    void Part401()
    {
        NPCText.text = "What kind of axe did you get me?";
        PlayerText1.text = "I bought the professional axe. One of her best!";
        PlayerText2.text = "(Lie): I bought the luxury axe. It's her most exepensive axe.";
        Choosing(Part410, Part420);
    }

    void Part410()
    {
        NPCText.text = "Thank you so much! This is exactly the axe I wanted!";
        Reading(Part411);
    }

    void Part411()
    {
        NPCText.text = "Thanks for getting it for me! I really didn't want to travel to Beardsville.";
        Reading(Part412);
    }

    void Part412()
    {
        NPCText.text = "For an axe like this, I'll pay you $11.50 more.";
        GiveMoney(1150);
        ContinueText.text = "Exit Conversation";
        Reading(EndConversation);
    }

    void Part420()
    {
        NPCText.text = "Wow! That sounds extravagant. This axe doesn't look too special...";
        Reading(Part421);
    }

    void Part421()
    {
        NPCText.text = "But I'm sure I'll know why it's luxury when I use it.";
        Reading(Part422);
    }

    void Part422()
    {
        NPCText.text = "I didn't need an axe quite this good but I will enjoy it. I'll pay you $13.50 more.";
        GiveMoney(1350);
        ContinueText.text = "Exit Conversation";
        Reading(EndConversation);
    }

    //Conversation if player bought the luxury axe
    void Part501()
    {
        NPCText.text = "What kind of axe did you get me?";
        ContinueText.text = "I bought the luxury axe. It's their most exepensive axe.";
        Reading(Part502);
    }
    
    void Part502()
    {
        NPCText.text = "Thank you! That sounds nice. I'm excited to use it.";
        Reading(Part503);
    }
    
    void Part503()
    {
        NPCText.text = "This is going to hurt my wallet though. I can do $13.50 more.";
        GiveMoney(1350);
        ContinueText.text = "Exit Conversation";
        Reading(EndConversation);
    }

    //This is the function that the left button calls
    public override void ChooseOption1()
    {
        NotChoosing();
        if (choice == 1)
        {
            Part2a();
        }
        else if (choice == 2)
        {
            Part2b();
        }
        else if (choice == 3)
        {
            //Game ends and you have an axe but your family dies.
        }
        else if (choice == 101)
        {
            Part102a();
        }
        //Make more if statements as needed
    }

    //This is the function that the right button calls
    public override void ChooseOption2()
    {
        NotChoosing();
        if (choice == 1)
        {
            Part2c();
        }
        else if (choice == 2)
        {
            Part2c();
        }
        else if (choice == 3)
        {
            Part2c();
        }
        else if (choice == 101)
        {
            Part102c();
        }
    }

    //This is the function that the continue button calls
    public override void Continue()
    {
        NotReading();
        if (cont == 1)
        {
            if (Globals.AxeType == 1)
            {
                Part101();
            }
            else if (Globals.AxeType == 2)
            {
                Part201();
            }
            else if (Globals.AxeType == 3)
            {
                Part301();
            }
            else if (Globals.AxeType == 4)
            {
                Part401();
            }
            else if (Globals.AxeType == 5)
            {
                Part501();
            }
        }
        else if (cont == 101)
        {
            Part102b();
        }
    }
}