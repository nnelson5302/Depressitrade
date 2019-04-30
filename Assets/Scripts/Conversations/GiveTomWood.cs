using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GiveTomWood : MonoBehaviour
{
    public Text TomText;
    public Text PlayerText1;
    public Text PlayerText2;
    public Text MoneyText;
    public GameObject Choice1;
    public GameObject Choice2;
    public GameObject ContinueButton;
    public GameObject MoneyPanel;
    public Button Button1;
    public Button Button2;
    public Button ContButton;

    int Option;
    int choice;
    int cont;
    string playerName = "Jackie";

    void Start()
    {
        Debug.Log("Start");
        Option = 0;
        Choice1.SetActive(false);
        Choice2.SetActive(false);
        ContinueButton.SetActive(false);
        MoneyPanel.SetActive(false);
        Button1.onClick.AddListener(ChooseOption1);
        Button2.onClick.AddListener(ChooseOption2);
        ContButton.onClick.AddListener(Continue);
        Part1(); //Change this later probably but it will work for now
    }

    //Make different parts of the story in voids

    //Part 1 is the first thing the character says to you
    //It's activated when you enter the conversation
    public void Part1()
    {
        TomText.text = "Did you get me some wood?";
        PlayerText1.text = "Yes, of course.";
        PlayerText2.text = "No.";
        choice = 1;
        Choosing();
    }

    void Part2a()
    {
        TomText.text = "Great! I owe you $3.50 then! Thank you! I'll inform you if I require your assistance in the future.";
        cont = 1;
        Reading();
    }

    void Part2b()
    {
        TomText.text = "You're useless. This is why you were put up for adoption. Get out of Libertyville and don't ever come back!";
        cont = 2;
        Reading();
    }

    void Part3()
    {
        MoneyPanel.SetActive(true);
        MoneyText.text = "Tom gave you $3.50!";
        Globals.Money += 350;
        cont = 3;
        Reading();
    }

    //Make more parts as needed

    //This is the function that the left button calls
    public void ChooseOption1()
    {
        NotChoosing();
        if (choice == 1)
        {
            Part2a();
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
    }

    //This is the function that the continue button calls
    public void Continue()
    {
        NotReading();
        Debug.Log("ContinueVoid");
        if (cont == 1)
        {
            Part3();
        }
        else if (cont == 2)
        {
            //Go to game over screen once it's created
        }
        else if (cont == 3)
        {
            SceneManager.LoadScene("2D libertyville");
        }
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
}
