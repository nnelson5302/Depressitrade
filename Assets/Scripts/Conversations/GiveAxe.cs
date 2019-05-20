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
        choice = 2;
        Choosing();
    }

    void Part2b()
    {
        NPCText.text = "What about your family? And what about me?";
        PlayerText1.text = "I don't care. I got a nice axe so I'm keeping it.";
        PlayerText2.text = "Sorry, that was just a joke. Here's your axe.";
        choice = 2;
        Choosing();
    }
    void Part2c()
    {
        NPCText.text = "Great! Thank you so much! I really didn't want to have to travel to Beardsville myself.";
        cont = 1;
        Reading();
    }

    //Conversation if player bought the broken axe
    void Part101()
    {
        NPCText.text = "What kind of axe did you get me?";
        PlayerText1.text = "I bought you the cheapest axe I could find: a broken axe!";
        PlayerText2.text = "(Lie): It was on the cheaper end. He said it was a light duty axe.";
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
        cont = 102;
        Reading();
    }

    void Part102c()
    {
        NPCText.text = "Do you really think I'm that doltish? That dimwitted? This axe is broken! It's no light duty axe!";
        Reading(Part102b);
    }

    //Conversation if player bought the light duty axe
    void Part201()
    {
        NPCText.text = "What kind of axe did you get me?";
        PlayerText1.text = "It was on the cheaper end. He said it was a light duty axe.";
        PlayerText1.text = "(Lie): I bought the standard axe.";
        Choosing(Part202a, Part202d);
    }

    void Part202a()
    {
        if (Globals.dickfriend == true)
        {
            NPCText.text = "Really? I would've liked a better axe.";
        }
        else
        {
            NPCText.text = "Really? I asked for a good axe. I don't want a light duty axe!";
        }
        Globals.GameOver("You bought a broken axe for Dick and he didn't pay you anything for it.\nYou go back to the farm poor and your "  die of malnourishment\n" +
            "You");
    }

    void Part202b()
    {
        NPCText.text = "This is my job! I need a better axe than this!";
        Reading(Part202c);
    }
    
    void Part202c()
    {
        if (Globals.dickfriend == true)
        {
            NPCText.text = "Still, we're friends. And I'm feeling generous. I'll pay you 9 dollars.";
            GiveMoney(900);
        }
        else
        {
            NPCText.text = "I guess I'll give you something though. Here, take 8 dollars. I'm feeling generous.";
            GiveMoney(800);
        }
    }

    void Part202d()
    {
        NPCText.text = "Hmm, I guess they look a little different now. Styles change I suppose.";
    }


    //Conversation if player bought the standard axe
    void Part301()
    {
        NPCText.text = "What kind of axe did you get me?";

    }

    //Conversation if player bought the professional axe
    void Part401()
    {
        NPCText.text = "What kind of axe did you get me?";

    }

    //Conversation if player bought the luxury axe
    void Part501()
    {
        NPCText.text = "What kind of axe did you get me?";

    }


    //Make more parts as needed
    //I like to do parts where the conversation path is divided as a and b that way every conversation goes 1, 2, 3, etc. but you get different parts

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
        }
        else if (cont == 101)
        {
            Part102b();
        }
        else if (cont == 102)
        {
            //Game ends. You don't get enough money for your family and you go back to them and you all die together
        }
        //Make more if statements as needed
    }

}