using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Anything with underscores on either side of it should be replaced with something specific to the conversation
public class DickWantsAxe : MonoBehaviour {

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
    string playerName = "Mildred";
    bool dickfriend = false;

    void Start()
    {
        Debug.Log("Start");
        Choice1.SetActive(false);
        Choice2.SetActive(false);
        ContinueButton.SetActive(false);
        Button1.onClick.AddListener(ChooseOption1);
        Button2.onClick.AddListener(ChooseOption2);
        ContButton.onClick.AddListener(Continue);
    }

    //Make different parts of the story in voids

    //Part 1 is the first thing the character says to you
    //It's activated when you enter the conversation
    public void Part1()
    {
        DickText.text = "Hey, " + playerName + ". What do you want?";
        PlayerText1.text = "I was wondering if you had any work for me.";
        PlayerText2.text = "I just came to talk to you. I need some friends around here.";
        choice = 1;
        Choosing();
    }

    void Part2a()
    {
        DickText.text = "In fact I do. My axe is starting to break. I need a new one.";
        cont = 1;
        Reading();
    }

    void Part2b()
    {
        dickfriend = true;
        DickText.text = "That's nice. I don't have many friends either. I've always been a little bit of a loner.";
        cont = 2;
        Reading();
    }

    void Part2c()
    {
        DickText.text = "Kids in school would make fun of me for my name. Do you want to know my full name?";
        PlayerText1.text = "Sure.";
        PlayerText2.text = "What is it?";
        choice = 2;
        Choosing();
    }

    void Part2d()
    {
        DickText.text = "Dick Woodcock! Do you know how hard it is to go through school with a name like that?";
        cont = 3;
        Reading();
    }

    void Part2e()
    {
        DickText.text = "Kids are so cruel! At least they elected me the leader of the Pen15 club though. That was nice.";
        PlayerText1.text = "I don't know think you know what the Pen15 club really was...";
        PlayerText2.text = "Yeah... sure. Nice...";
        choice = 3;
        Choosing();
    }

    void Part2f()
    {
        DickText.text = "Of course I do. I was the leader!";
        PlayerText1.text = "No, it spells penis. That's why they elected you.";
        PlayerText2.text = "Oh, right. Nevermind";
        choice = 4;
        Choosing();
    }

    void Part2g()
    {
        DickText.text = "Oh no! Even that was to make fun of me! That makes my back tattoo really embarassing.";
        cont = 4;
        Reading();
    }

    void Part2h()
    {
        DickText.text = "Well anyway, since we're friends, I need you to do me a favor.";
        PlayerText1.text = "Of course! I'll do whatever you need.";
        PlayerText2.text = "I don't know...";
        choice = 5;
        Choosing();
    }

    void Part2i()
    {
        DickText.text = "Thanks! I knew you were a good friend!";
        cont = 5;
        Reading();
    }

    void Part2j()
    {
        DickText.text = "Don't worry. It doesn't have anything to do with my childhood bullies.";
        cont = 5;
        Reading();
    }

    void Part2k()
    {
        DickText.text = "My axe is starting to break and I need a new one.";
        cont = 1;
        Reading();
    }

    void Part3()
    {
        DickText.text = "I know there's a good blacksmith over in Beardsville.";
        PlayerText1.text = "What kind of axe do you want?";
        PlayerText2.text = "Where's that?";
        choice = 6;
        Choosing();
    }

    void Part4a()
    {
        DickText.text = "I want a good axe. One that isn't going to break on me.";
        cont = 6;
        Reading();
    }

    void Part4b()
    {
        DickText.text = "It's pretty close. Shouldn't be too long of a trip.";
        cont = 7;
        Reading();
    }

    void Part4c()
    {
        DickText.text = "And make sure you bring me a good axe. One that isn't going to break on me.";
        cont = 6;
        Reading();
    }

    void Part5()
    {
        if (dickfriend == true)
        {
            DickText.text = "I trust you not to scam me but if you do I will find out eventually.";
        }
        else
        {
            DickText.text = "Don't try to scam me either. If you lie about what axe you bought I will find out eventually.";
        }
        PlayerText1.text = "I would never do that!";
        PlayerText2.text = "Alright, but you better pay me well. My family needs the money.";
        choice = 7;
        Choosing();
    }

    void Part6a()
    {
        if (dickfriend == true)
        {
            DickText.text = "Good. I don't like dishonest friends.";
        }
        else
        {
            DickText.text = "Good. There are lots of dishonest people out there.";
        }
        PlayerText1.text = "I am not one of them.";
        PlayerText2.text = "What specific kind of axe do you want?";
        choice = 8;
        Choosing();
    }

    void Part6b()
    {
        DickText.text = "I'll pay you well if you do what I ask.";
        PlayerText1.text = "And I will.";
        PlayerText2.text = "What specific kind of axe do you want?";
        choice = 8;
        Choosing();
    }

    void Part7a()
    {
        DickText.text = "So then we have a deal.";
        cont = 8;
        Reading();
    }

    void Part7b()
    {
        DickText.text = "I want one of the best axes he has. Something that can get the job done.";
        cont = 8;
        Reading();
    }

    void Part8()
    {
        if (dickfriend == true)
        {
            DickText.text = "I have to get back to work but good luck. I'll see you when you return.";
        }
        else
        {
            DickText.text = "I have to get back to work now and I suggest you do too. It's best to leave in the morning.";
        }
        cont = 9;
        Reading();
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
            Part2d();
        }
        else if (choice == 3)
        {
            Part2f();
        }
        else if (choice == 4)
        {
            Part2g();
        }
        else if (choice == 5)
        {
            Part2i();
        }
        else if (choice == 6)
        {
            Part4a();
        }
        else if (choice == 7)
        {
            Part6a();
        }
        else if (choice == 8)
        {
            Part7a();
        }
    }

    //This is the function that the right button calls
    public void ChooseOption2()
    {
        NotChoosing();
        if (choice == 1)
        {
            Part2b();
        }
        else if (choice == 2)
        {
            Part2d();
        }
        else if (choice == 3)
        {
            Part2h();
        }
        else if (choice == 4)
        {
            Part2h();
        }
        else if (choice == 5)
        {
            Part2j();
        }
        else if (choice == 6)
        {
            Part4b();
        }
        else if (choice == 7)
        {
            Part6b();
        }
        else if (choice == 8)
        {
            Part7b();
        }
    }

    //This is the function that the continue button calls
    public void Continue()
    {
        NotReading();
        if (cont == 1)
        {
            Part3();
        }
        else if (cont == 2)
        {
            Part2c();
        }
        else if (cont == 3)
        {
            Part2e();
        }
        else if (cont == 4)
        {
            Part2h();
        }
        else if (cont == 5)
        {
            Part2k();
        }
        else if (cont == 6)
        {
            Part5();
        }
        else if (cont == 7)
        {
            Part4c();
        }
        else if (cont == 8)
        {
            Part8();
        }
        else if (cont == 9)
        {
            //Return to scene
        }
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
