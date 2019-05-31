using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public delegate void ConversationPart();

public abstract class ConversationBase
{
    public Text NPCText;
    public Text PlayerText1;
    public Text PlayerText2;
    public GameObject Choice1;
    public GameObject Choice2;
    public GameObject ContinueButton;
    public GameObject NPC;
    public Button Button1;
    public Button Button2;
    public Button ContButton;
	public Text ContinueText;
    public GameObject MoneyPanel;
    public Text MoneyText;

    public int choice;
    public int cont;
    public ConversationPart ContinueFunc;
    public ConversationPart Choice1Func;
    public ConversationPart Choice2Func;

    protected string playerName = Globals.PlayerName;
    public string NPCName = Globals.ConversationPerson;
	
	//plz forgive me for this function signature
    public ConversationBase(
		Text _NPCText,
		Text _PlayerText1,
		Text _PlayerText2,
		GameObject _Choice1,
		GameObject _Choice2,
		GameObject _ContinueButton,
        GameObject _NPC,
        GameObject _TextBox,
        GameObject _MoneyPanel,
        Text _MoneyText
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
        NPC = _NPC;
        MoneyPanel = _MoneyPanel;
        MoneyText = _MoneyText;
		ContinueText = ContinueButton.GetComponent<Transform>().GetChild(0).GetComponent<Text>();
		
        Choice1.SetActive(false);
        Choice2.SetActive(false);
        ContinueButton.SetActive(false);
        Button1.onClick.AddListener(OnClickOption1);
        Button2.onClick.AddListener(OnClickOption2);
        ContButton.onClick.AddListener(OnClickContinue);
    }

    //Called at start of conversation, must be implemented
    public abstract void Part1();

    public void OnClickOption1()
    {
        if (Choice1Func != null){
			//Debug.Log("not null");
            ConversationPart tempFunc = Choice1Func;
            Choice1Func = null;
			Choice2Func = null;
            tempFunc();
        } else {
            //for old system
            ChooseOption1();
        }
    }

    public void OnClickOption2()
    {
        if (Choice2Func != null){
            ConversationPart tempFunc = Choice2Func;
			Choice1Func = null;
            Choice2Func = null;
            tempFunc();
        } else {
            //for old system
            ChooseOption2();
        }
    }

    public void OnClickContinue()
    {
		ContinueButton.SetActive(false);
		ContinueText.text = "Continue";
		ContinueText.fontSize = 90;
        if (ContinueFunc != null){
            ConversationPart tempFunc = ContinueFunc;
            ContinueFunc = null;
            tempFunc();
        } else {
            //for old system
            Continue();
        }
    }

    //Implement these in the conversation if using the old cont/choice number style
    public virtual void ChooseOption1() {}
    public virtual void ChooseOption2() {}
    public virtual void Continue() {}

    //Call this function when the player must choose something to say
    //It makes the choice button appears
    public void Choosing()
    {
        Choice1.SetActive(true);
        Choice2.SetActive(true);
        ContinueButton.SetActive(false);
    }

    //Call this to use the new style for conversations
    //Use the 2 parts this could lead to as parameters
    public void Choosing(ConversationPart Choice1Part, ConversationPart Choice2Part)
    {
        Choice1.SetActive(true);
        Choice2.SetActive(true);
        ContinueButton.SetActive(false);
        Choice1Func = Choice1Part;
        Choice2Func = Choice2Part;
    }

    //Call this function when the player is reading something and has nothing to choose
    //It makes the continue button appear
    public void Reading()
    {
        ContinueButton.SetActive(true);
        Choice1.SetActive(false);
        Choice2.SetActive(false);
    }

    //Supply part this leads to as parameter
    public void Reading(ConversationPart NextPart)
    {
        ContinueButton.SetActive(true);
        Choice1.SetActive(false);
        Choice2.SetActive(false);
        ContinueFunc = NextPart;
    }

    public void NotChoosing()
    {
        //obsolete, sticking around as a dummy
    }

    public void NotReading()
    {
        //obsolete, sticking around as a dummy
    }
	
	//Call to return to the world after the conversation
	public void EndConversation()
	{
		SceneManager.LoadScene(Globals.CurrentCity);
	}

    public void GiveMoney(int amount) {
        if(NPCName != null){
            MoneyText.text = NPCName + " gave you " + Globals.FormatMoney(amount);
        } else {
            MoneyText.text = "You got " + Globals.FormatMoney(amount);
        }
        MoneyPanel.SetActive(true);
		MoneyPanel.GetComponent<Image>().color = Color.green;
        Globals.Money += amount;
    }
	
	public void SpendMoney(int amount) {
		MoneyText.text = "You gave " + Globals.FormatMoney(amount) + " to " + NPCName;
		MoneyPanel.SetActive(true);
		MoneyPanel.GetComponent<Image>().color = new Color(1f, 0.2f, 0.2f, 1f);
		Globals.Money -= amount;
	}
}
