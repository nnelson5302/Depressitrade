using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Anything with underscores on either side of it should be replaced with something specific to the conversation
public class GiveAxe : MonoBehaviour
{
    public Text DickText;
    public Text PlayerText1;
    public Text PlayerText2;
    public GameObject Choice1;
    public GameObject Choice2;
    public GameObject ContinueButton;
    public Button Button1;
    public Button Button2;
    public Button ContButton;
    int choice;
    int cont;
    string playerName = "Jackie";
    bool dickfriend = true; //should be global variable
    int AxeType = 4;

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
    public void Part1()
    {
        if (dickfriend == true )
        {
            DickText.text = "It's good to see you agian! Did you get me an axe?";
        }
        else
        {
            DickText.text = "You're back! Did you get me an axe?";
        }
        PlayerText1.text = "No. I got myself an axe.";
        PlayerText2.text = "Yes, I have it right here.";
        choice = 1;
        Choosing();
    }

    void Part2a()
    {
        DickText.text = "Is this some sort of joke?";
        PlayerText1.text = "Yeah, I'm just joking. I got you an axe.";
        PlayerText2.text = "Nope! I'm keeping the axe for myself.";
        choice = 2;
        Choosing();
    }

    void Part2b()
    {
        DickText.text = "What about your family? And what about me?";
        PlayerText1.text = "I don't care. I got a nice axe so I'm keeping it.";
        PlayerText2.text = "Sorry, that was just a joke. Here's your axe.";
        choice = 2;
        Choosing();
    }
    void Part2c()
    {
        DickText.text = "Great! Thank you so much! I really didn't want to have to travel to Beardsville myself.";
        cont = 1;
        Reading();
    }

    //Conversation if player bought the broken axe
    void Part101()
    {
        DickText.text = "What kind of axe did you get me?";
        PlayerText1.text = "I bought you the cheapest axe I could find: a broken axe!";
        PlayerText2.text = "It was on the cheaper end. He said it was a light duty axe.";
        choice = 101;
        Choosing();
    }

    void Part102a()
    {
        DickText.text = "Why would you do that? The whole reason I wanted an axe is because mine was broken!";
        cont = 101;
        Reading();
    }

    void Part102b()
    {
        if (dickfriend == true)
        {
            DickText.text = "What the hell? I thought we were friends! You're a terrible friend. I want you to know that. Leave and don't ever talk to me again.";
        }
        else
        {
            DickText.text = "What the hell? I thought I could trust you! You're going to have to find somebody else to work for. Don't ever come back here!!";
        }
        cont = 102;
        Reading();
    }

    void Part102c()
    {
        DickText.text = "Do you really think I'm that doltish? That dimwitted? This axe is broken! It's no light duty axe!";
        cont = 101;
    }

    //Conversation if player bought the light duty axe
    void Part201()
    {
        DickText.text = "What kind of axe did you get me?";

    }

    //Conversation if player bought the standard axe
    void Part301()
    {
        DickText.text = "What kind of axe did you get me?";

    }

    //Conversation if player bought the professional axe
    void Part401()
    {
        DickText.text = "What kind of axe did you get me?";

    }

    //Conversation if player bought the luxury axe
    void Part501()
    {
        DickText.text = "What kind of axe did you get me?";

    }


    //Make more parts as needed
    //I like to do parts where the conversation path is divided as a and b that way every conversation goes 1, 2, 3, etc. but you get different parts

    //This is the function that the left button calls
    public void ChooseOption1()
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
    public void ChooseOption2()
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
    public void Continue()
    {
        NotReading();
        if (cont == 1)
        {
            if(AxeType == 1)
            {
                Part101();
            }
            else if (AxeType == 2)
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

    //Call this function when the player must choose something to say
    //It makes the choice button appears
    void Choosing()
    {
        Choice1.SetActive(true);
        Choice2.SetActive(true);
    }

    //Call this function when the player is reading something and has nothing to choose
    //It makes the continue button appear
    void Reading()
    {
        ContinueButton.SetActive(true);
    }

    //Call this function when the player has chosen something
    //It makes the choice buttons inactive
    void NotChoosing()
    {
        Choice1.SetActive(false);
        Choice2.SetActive(false);
    }

    //Call this function when the player hit continue
    //It makes the continue button inactive
    void NotReading()
    {
        ContinueButton.SetActive(false);
    }
}
