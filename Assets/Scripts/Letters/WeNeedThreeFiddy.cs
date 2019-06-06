using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeNeedThreeFiddy : MonoBehaviour 
{
    // Start is called before the first frame update
    public Text letterText;
    int letternumber = 0;
    public Font Alice;
    public Font Spouse;
    public GameObject Envelope;
    public GameObject LetterStuff;
    public GameObject UIPanel;

    public void ShowLetter()
    {
        Debug.Log("I went to the right place");
        UIPanel.SetActive(false);
        Debug.Log("I set UI panel false");
        Envelope.SetActive(false);
        Debug.Log("I made envelope inactive");
        LetterStuff.SetActive(true);
        Debug.Log(letternumber);
        if (letternumber == 0)
        {
            Debug.Log("In the if statement");
            letterText.font = Spouse;
            letterText.text = "Dear " + Globals.PlayerName + ",\nThank you for doing this for us. The depression hit us hard " +
            "but I'm sure you'll help us get through it. Tom is an old friend of mine and he runs a shop in Libertyville. " +
            "He said he can help get you some work. Hopefully one of us can find a more stable job soon but until then, this " +
            "will have to do. It's going to be tough and I will miss you dearly, but we'll be able to survive.\nLove, " +
            Globals.spouseName;
        }
        else if (letternumber == 1)
        {
            letterText.font = Alice;
            letterText.text = "Hi " + Globals.parentType + "!\n Im almost five yers old! " + Globals.spouseType +
                " is really tierd and mad. " + Globals.spousePronoun + " says you are getting monie to get us food." +
                " Im really hungrie. We only eat potatos and " + Globals.spouseType + " says were running out of those. " +
                "We need monie. " + Globals.spouseType + " told me to ask you for fiften dolers. Can you do that " +
                Globals.parentType + "? If you dont I dont no what well do. \n \n  Love, Alice";
        }
        else if (letternumber == 2)
        {
            letterText.font = Spouse;
            letterText.text = "Dear " + Globals.PlayerName + ",\nThank you for all the work you've been doing and I hope you're doing well.\n" +
            "I miss you and I truly wish that you were home with us. The kids are okay and it's hard to take care " +
            "of them by myself but I'm managing. Despite the money you sent us, we're running out of food. I know it's " +
            "tough to get good work but we need you to do whatever you possibly can to make money for us or I fear " +
            "we won't survive. I love you and if anybody can do this, it's you. When you lost your job, that was the "  +
            "biggest mistake the bank could've made, but your banking skills must be very useful in trading or whatever " +
            "it is you're doing. If you could win the lottery or something and come home, that's all I " +
            "could ever ask for but I know that's not possible. Anyhow, looking at our expenses, we're going to need 20 " +
            "dollars soon. I hope it's not too much to ask. Bill's store closed so I've been having to go out of town " +
            "to get food, meaning I have to pay somebody to watch the kids. School can't start soon enough. I love you " +
            "dearly and I hope this is all over soon and one of us can find a stable job.\n\nLove, " +
            Globals.spouseName;
        }
    }

    void Update() {
        if (Globals.LetterTime)
        {
            Debug.Log("Time for a letter");
            Envelope.SetActive(true);
            LetterStuff.SetActive(false);
            Globals.FreezePlayerPosition = true;
            Globals.LetterTime = false;
        }
    }

    public void DoneButton()
    {
        Debug.Log("I'm done");
        Globals.MusicType = 1;
        Debug.Log(Globals.MusicType);
        Globals.ChangeMusic = true;
        Debug.Log(Globals.ChangeMusic);
        LetterStuff.SetActive(false);
        UIPanel.SetActive(true);
        Globals.FreezePlayerPosition = false;
        letternumber++;
    }

}
