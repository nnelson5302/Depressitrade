using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TomConvo4 : ConversationBase
{
    public TomConvo4(
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

    void Start()
    {
        Globals.HadTomBreadConversation = true;
        Choice1.SetActive(false);
        Choice2.SetActive(false);
        ContinueButton.SetActive(false);
        Button1.onClick.AddListener(ChooseOption1);
        Button2.onClick.AddListener(ChooseOption2);
        ContButton.onClick.AddListener(Continue);
    }

    public override void Part1()
    {
        NPCText.text = "Do you need more work?";
        PlayerText2.text = "Yes, whatever you can have me do!";
        if (Globals.KnowsAboutGang == true)
        {
            PlayerText1.text = "Yeah, unless I want to help the guy in your basement smuggle alcohol.";
            Choosing(Part2a, Part4);
        }
        else
        {
            PlayerText1.text = "Yes, unless I want to get involved in some operation that sounds illegal.";
            Choosing(Part3a, Part4);
        }
    }

    void Part2a()
    {
        Globals.TomToldAboutAlcoholDealer = true;
        NPCText.text = "There's somebody in my basement selling alchol?";
        PlayerText1.text = "No! I was just joking.";
        PlayerText2.text = "Yeah! You didn't know about him??";
        Choosing(Part2b, Part2e);
    }

    void Part2b()
    {
        Globals.TomCheckedForAlcoholDealer = true;
        NPCText.text = "I'm going to go check, just to be sure.";
        Reading(Part2c);
    }

    void Part2c()
    {
        NPC.SetActive(false);
        ContinueText.text = "Wait for Tom to come back";
        Reading(Part2d);
    }

    void Part2d()
    {
        NPC.SetActive(true);
        NPCText.text = "I didn't see anybody down there, I guess you were joking after all.";
        Reading(Part4);
    }

    void Part2e()
    {
        NPCText.text = "No, I didn't know about him! You should go alert the police!";
        PlayerText1.text = "You probably should do that.";
        PlayerText2.text = "No! Don't do that! He's dangerous!";
        Choosing(Part2f, Part2g);
    }

    void Part2f()
    {
        Globals.ReportsToPoliceWithTom = true;
        NPCText.text = "Okay, go to the sherrif's office. I'll join you soon.";
        Reading(EndConversation);
    }

    void Part2g()
    {
        NPCText.text = "How dangerous could he be?";
        PlayerText1.text = "Very dangerous! He knows where my family lives.";
        PlayerText2.text = "I guess you're right. I'll report him.";
        Choosing(Part2h, Part2f);
    }

    void Part2h()
    {
        NPCText.text = "Okay, well I want him out of my shop. What if I pretend to just find him there by myself?";
        PlayerText1.text = "That sounds like it would work.";
        PlayerText2.text = "No! He would know that I told you!";
        Choosing(Part2i, Part2j);
    }

    void Part2i()
    {
        Globals.TomWillFindAlcoholDealer = true;
        NPCText.text = "Alright then. You were saying you need work?";
        Reading(Part4);
    }

    void Part2j()
    {
        NPCText.text = "I can't say I'm happy with it, but for the safety of your family, I guess I'll let it be for now.";
        PlayerText1.text = "Thank you so much!";
        PlayerText2.text = "Actually, go ahead and alert the police.";
        Choosing(Part4, Part2i);
    }

    void Part3a()
    {
        Globals.TomToldAboutAlcoholDealer = true;
        NPCText.text = "What illegal operations?";
        PlayerText1.text = "There was a guy in your basement who seemed weird.";
        PlayerText2.text = "It's nothing. People are just desperate for money, you know?";
        Choosing(Part3b, Part3j);
    }

    void Part3b()
    {
        NPCText.text = "There was now? I'm going to go down there right now and get him out!";
        PlayerText1.text = "No! Don't do that. He seemed dangerous.";
        PlayerText2.text = "You should do that.";
        Choosing(Part3c, Part3d);
    }

    void Part3c()
    {
        NPCText.text = "But if there's somebody doing something illegal in my shop, I need to stop them.";
        PlayerText1.text = "Yeah, I guess.";
        PlayerText2.text = "But I think he might kill you or something.";
        Choosing(Part3d, Part3k);
    }

    void Part3d()
    {
        NPCText.text = "I'm going to get that criminal out of my shop.";
        Reading(Part3e);
    }

    void Part3e()
    {
        Globals.TomCheckedForAlcoholDealer = true;
        NPC.SetActive(false);
        ContinueText.text = "Wait for Tom to come back";
        Reading(Part3f);
    }

    void Part3f()
    {
        NPC.SetActive(true);
        NPCText.text = "I didn't see anybody there.";
        PlayerText1.text = "He probably left. I doubt he'll be back.";
        PlayerText2.text = "He'll be back. You can check again later.";
        Choosing(Part3g, Part3h);
    }

    void Part3g()
    {
        NPCText.text = "Yeah, lots of people come into my store. I won't worry too much about it.";
        Reading(Part3i);
    }

    void Part3h()
    {
        Globals.TomWillFindAlcoholDealer = true;
        NPCText.text = "Okay, I'll do that. I can't have criminals hanging around in my shop.";
        Reading(Part3i);
    }

    void Part3i()
    {
        NPCText.text = "Anyhow, you needed some work?";
        Reading(Part4);
    }

    void Part3j()
    {
        NPCText.text = "That's true. I shouldn't concern myself with it too much.";
        Reading(Part3i);
    }

    void Part3k()
    {
        NPCText.text = "He's not going to kill me. That's crazy talk.";
        PlayerText1.text = "You're right.";
        PlayerText2.text = "I'm sure he could";
        Choosing(Part3d, Part3l);
    }

    void Part3l()
    {
        NPCText.text = "I'm stronger than I look. I'm going to go check it out.";
        PlayerText1.text = "Just wait!";
        PlayerText2.text = "Okay, I guess.";
        Choosing(Part3m, Part3e);
    }

    void Part3m()
    {
        NPCText.text = "Okay, if you really don't think I should go then I won't.";
        Reading(Part3n);
    }

    void Part3n()
    {
        NPCText.text = "You said that you needed work?";
        Reading(Part4);
    }

    void Part4()
    {
        NPCText.text = "I don't have much for you but I do need some bread. There's a baker in Beardsville.";
        Reading(Part5);
    }

    void Part5()
    {
        NPCText.text = "If you could get me 30 loaves of bread, I would appreciate that. But I can't pay you too much.";
        Reading(Part6);
    }

    void Part6()
    {
        NPCText.text = "I'm sorry. I wish I could but times are tough as is.";
        PlayerText1.text = "That's okay. I appreciate you paying me anything.";
        PlayerText2.text = "I want as much as I can get. My family is relying on me.";
        Choosing(Part7a, Part7b);
    }

    void Part7a()
    {
        NPCText.text = "I'm glad you're so understanding.";
        Reading(Part8a);
    }

    void Part7b()
    {
        NPCText.text = "I have a family too. I give you what I can but my family comes first.";
        PlayerText1.text = "No, my family is more important.";
        PlayerText2.text = "I would do the same.";
        Choosing(Part8b, Part8e);
    }

    void Part8a()
    {
        NPCText.text = "Now you should head to Beardsville because I'm running low on bread and it's all lots of people can afford.";
        PlayerText1.text = "Beardsville? More like Breadsville!";
        PlayerText2.text = "I'll leave right away.";
        Choosing(Part9a, Part9b);
    }

    void Part8b()
    {
        NPCText.text = "What's that, crumb? Do you not want to work?";
        PlayerText1.text = "Not if you don't think my family is more important than yours.";
        PlayerText2.text = "Sorry, I was just joking.";
        Choosing(Part8c, Part8d);
    }

    void Part8c()
    {
        NPCText.text = "What is it with you? Alright, I'll get bread myself. Goodbye.";
        Reading(EndConversation);
    }

    void Part8d()
    {
        NPCText.text = "Of course. I should have figured.";
        Reading(Part8a);
    }

    void Part8e()
    {
        NPCText.text = "Everbody needs to take care of themselves and their families first in times like these.";
        Reading(Part8a);
    }

    void Part9a()
    {
        NPCText.text = "I'm not sure what you mean by that but okay. Go get me bread.";
        Reading(EndConversation);
    }

    void Part9b()
    {
        NPCText.text = "Great!";
        Reading(EndConversation);
    }
}