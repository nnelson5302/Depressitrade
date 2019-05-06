using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationBase
{
    public Text NPCText;
    public Text PlayerText1;
    public Text PlayerText2;
    public GameObject Choice1;
    public GameObject Choice2;
    public GameObject ContinueButton;
    Button Button1;
    Button Button2;
    Button ContButton;
    int choice;
    int cont;
    string playerName = Globals.PlayerName;
	
	//plz forgive me for this function signature
    public ConversationBase(
		Text _NPCText,
		Text _PlayerText1,
		Text _PlayerText2,
		GameObject _Choice1,
		GameObject _Choice2,
		GameObject _ContinueButton
	)
    {
		NPCText = _NPCText;
		PlayerText1 = _PlayerText1;
		PlayerText2 = _PlayerText2;
		Choice1 = _Choice1;
		Choice2 = _Choice2;
		ContinueButton = _ContinueButton;
		Button1 = Choice1.GetComponent<Button>();
		Button2 = Choice2.GetComponent<Button>();
		ContButton = ContinueButton.GetComponent<Button>();
		
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
        _CharacterName_Text.text = "_Whatever you want the character to say first_";
        PlayerText1.text = "_This text appears on the left button_";
        PlayerText2.text = "_This text appears on the right button_";
        choice = 1;
        Choosing();
    }

    void Part2a()
    {
        _CharacterName_Text.text = "_This is what I say if you click the left button_";
        cont = 1;
        Reading();
    }

    void Part2b()
    {
        _CharacterName_Text.text = "_This is what I say if you click the right button_";
        cont = 1;
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
            //Send it to whatever void you want it to go to if you choose option 1 on the first choice
            //ex:  Part2a();
        }
        else if (choice == 2)
        {
            //Send it to whatever void you want it to go to if you choose option 1 on the second choice
        }
        //Make more if statements as needed
    }

    //This is the function that the right button calls
    public void ChooseOption2()
    {
        NotChoosing();
        if (choice == 1)
        {
            //Send it to whatever void you want it to go to if you choose option 2 on the first choice
            //ex:  Part2b();
        }
        if (choice == 2)
        {
            //Send it to whatever void you want it to go to if you choose option 2 on the second choice
        }
        //Make more if statements as needed
    }

    //This is the function that the continue button calls
    public void Continue()
    {
        NotReading();
        Debug.Log("ContinueVoid");
        if (cont == 1)
        {
            //Send it to whatever void you want it to go to when they hit continue on the first reading part
            //ex:  Part3();
        }
        else if (cont == 2)
        {
           //Send it to whatever void you want it to go to when they hit continue on the first reading part
        }
        //Make more if statements as needed
    }

    //Call this function when the player must choose something to say
    //It makes the choice button appears
    void Choosing()
    {
        Debug.Log("ChoosingVoid");
        Choice1.SetActive(true);
        Choice2.SetActive(true);
    }

    //Call this function when the player is reading something and has nothing to choose
    //It makes the continue button appear
    void Reading()
    {
        Debug.Log("ReadingVoid");
        ContinueButton.SetActive(true);
    }

    //Call this function when the player has chosen something
    //It makes the choice buttons inactive
    void NotChoosing()
    {
        Debug.Log("NotChoosingVoid");
        Choice1.SetActive(false);
        Choice2.SetActive(false);
    }

    //Call this function when the player hit continue
    //It makes the continue button inactive
    void NotReading()
    {
        Debug.Log("NotReadingVoid");
        ContinueButton.SetActive(false);
    }
	
	//Call to return to the world after the conversation
	void EndConversation()
	{
		SceneManager.LoadScene(Globals.CurrentCity);
	}
}
