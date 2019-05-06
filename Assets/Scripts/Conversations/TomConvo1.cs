using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TomConvo1 : MonoBehaviour {
    public Text TomText;
    public Text PlayerText1;
    public Text PlayerText2;
	public Text ContinueText;
    public GameObject Choice1;
    public GameObject Choice2;
    public GameObject ContinueButton;
    public Button Button1;
    public Button Button2;
    public Button ContButton;
    int Option;
    int choice;
    int cont;
    bool rememberedName;
    string playerName = Globals.PlayerName;

    void Start() {
        Option = 0;
        Choice1.SetActive(false);
        Choice2.SetActive(false);
        ContinueButton.SetActive(false);
        Button1.onClick.AddListener(ChooseOption1);
        Button2.onClick.AddListener(ChooseOption2);
        ContButton.onClick.AddListener(Continue);
		Part1();
    }

    public void Part1()
    {
        TomText.fontSize = 35;
        TomText.text = "Hey! It's nice to see you again!";
        PlayerText1.text = "It's been a while, Tom!";
        PlayerText2.text = "Who are you?";
        choice = 1;
        Choosing();
    }
    
    void Part2a()
    {
        TomText.text = "Well some of us have succesful jobs.";
        cont = 1;
        Reading();
    }
    
    void Part2b()
    {
        TomText.text = "I'm your friend Tom! It figures you'd forget me already.";
        cont = 1;
        Reading();
    }
    
    void Part3()
    {
        TomText.fontSize = 25;
        TomText.text = "I heard that your family is going through some tough times. I could pay you to do a few jobs for me.";
        PlayerText1.text = "What do you want me to do?";
        PlayerText2.text = "I don't need your help.";
        choice = 2;
        Choosing();
    }

    void Part3c()
    {
        if (rememberedName==true)
        {
            TomText.text = "You're not in a place to be picky with the state of your farm.";
        }
        if (rememberedName == false)
        {
            TomText.text = "Come on! Help a friend out! I mean so much to you that you forgot my name, remember?";
        }
        cont = 2;
        Reading();
    }

    void Part4()
    {
        TomText.fontSize = 26;
        TomText.text = "I'm running low on wood. If you can get me 20 planks of wood. I'll pay you $5.00.";
        PlayerText1.text = "Only $5.00!?!";
        PlayerText2.text = "Thanks, Tim!";
        choice = 3;
        Choosing();
    }

    void Part5a()
    {
        TomText.text = "Times are hard. Take what you can get, Ninnyhammer!";
        cont = 3;
		ContinueText.text = "Where can i get wood?";
        Reading();

    }

    void Part5b()
    {
        if (rememberedName == true)
        {
            TomText.text = "My name's Tom! Wow! I thought we were friends!!";
        }
        if (rememberedName == false)
        {
            if (playerName == "Mildred")
            {
                TomText.text = "Ugh! Whatever. It's fine. Have fun, Mildew.";
            }
            else if (playerName == "Walter")
            {
                TomText.text = "Ugh! Whatever. It's fine. Have fun, Waldo.";
            }
        }
        cont = 3;
		//ContinueText.text = "Where can I get wood?";
        Reading();
    }
	
	void Part6()
	{	
		TomText.text = "You can buy some from my friend Dick, in Potato Hill.";
		ContinueText.text = "Continue";
		cont = 4;
		Reading();
	}
    
    public void ChooseOption1()
    {
        NotChoosing();
        if (choice==1)
        {
            Part2a();
            rememberedName = true;
        }
        else if (choice == 2)
        {
            Part4();
        }
        else if (choice == 3)
        {
            Part5a();
        }
    }
    
    public void ChooseOption2() {
        NotChoosing();
        if (choice == 1)
        {
            Part2b();
            rememberedName = false;
        }
        else if (choice == 2)
        {
           Part3c();
        }
        else if (choice == 3)
        {
            Part5b();
        }
    }

    public void Continue()
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
            //Part6();
			EndConversation();
        }
		else if(cont == 4)
		{	
			EndConversation();
		}
    }
    
    void Choosing ()
    {
        Choice1.SetActive(true);
        Choice2.SetActive(true);
    }
    
    void Reading ()
    {
        ContinueButton.SetActive(true);
    }
    
    void NotChoosing ()
    {
        Choice1.SetActive(false);
        Choice2.SetActive(false);
    }
    
    void NotReading ()
    {
        ContinueButton.SetActive(false);
    }
	
	void EndConversation()
	{
		SceneManager.LoadScene(Globals.CurrentCity);
	}
}