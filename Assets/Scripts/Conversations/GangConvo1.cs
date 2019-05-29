using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GangConvo1 : ConversationBase
{
    public GangConvo1(
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
    bool trustPart = false;

    void Start()
    {
        Globals.HadFirstGangConversation = true;
        Choice1.SetActive(false);
        Choice2.SetActive(false);
        ContinueButton.SetActive(false);
        Button1.onClick.AddListener(ChooseOption1);
        Button2.onClick.AddListener(ChooseOption2);
        ContButton.onClick.AddListener(Continue);
    }

    public override void Part1()
    {
        NPCText.text = "Hello. Are you looking for work?";
        PlayerText1.text = "It depends on what it is.";
        PlayerText2.text = "Yes! I need whatever I can get!";
        Choosing(Part2a, Part2b);
    }

    void Part2a()
    {
        NPCText.text = "You may not be into it then.";
        PlayerText1.text = "No! I want to know what it is.";
        PlayerText2.text = "Probably not.";
        Choosing(Part2b, Part3a);
    }

    void Part2b()
    {
        NPCText.text = "Okay. I have a great moneymaking opportunity for you but you can't tell anybody about it.";
        PlayerText1.text = "I'm not sure I want to do it then.";
        PlayerText2.text = "I really need the money so I'll keep it quiet.";
        Choosing(Part3d, Part3c);
    }

    void Part3a()
    {
        NPCText.text = "Well I should be going then. If you change your mind I'll be around.";
        Reading(EndConversation);
    }

    void Part3b()
    {
        NPCText.text = "I have to know that I can trust you before I tell you anything.";
        PlayerText1.text = "I want to know.";
        PlayerText2.text = "Then I'm out.";
        Choosing(Part4a, Part3a);
    }

    void Part3c()
    {
        NPCText.text = "Are you sure? I need to know that I can trust you.";
        PlayerText1.text = "You can trust me.";
        PlayerText2.text = "What do you want me to do?";
        Choosing(Part4b, Part4c);
    }

    void Part3d()
    {
        NPCText.text = "I promise you'll get good money. As long as you don't get caught.";
        PlayerText1.text = "I'm not going to be part of any illegal operation.";
        PlayerText2.text = "I could use the money...";
        Choosing(Part3a, Part4a);
    }

    void Part4a()
    {
        NPCText.text = "That doesn't mean you're trustworthy though. You need some skin in the game.";
        PlayerText1.text = "What do you want?";
        PlayerText2.text = "I'm not so sure about this.";
        Choosing(Part4c, Part4d);
    }

    void Part4b()
    {
        NPCText.text = "I hope so. Just to be sure... do you have any family?";
        PlayerText1.text = "Why do you need to know that?!";
        PlayerText2.text = "Yes. I'm married with 2 kids, why?";
        Choosing(Part5a, Part5b);
    }
    
    void Part4c()
    {
        NPCText.text = "Let's see... do you have any family?";
        PlayerText1.text = "Why do you need to know that?!";
        PlayerText2.text = "Yes. I'm married with 2 kids, why?";
        Choosing(Part5a, Part5b);
    }

    void Part4d()
    {
        NPCText.text = "Just remember that it's for good money. Do you have a family?";
        PlayerText1.text = "Why do you need to know that?!";
        PlayerText2.text = "Yes. I'm married with 2 kids, why?";
        Choosing(Part5a, Part5b);
    }

    void Part5a()
    {
        trustPart = true;
        NPCText.text = "If I'm going to trust you, you need to trust me. So do you have a family?";
        PlayerText1.text = "I don't know what this is but I don't want any part in it. Goodbye.";
        PlayerText2.text = "Yes, I have a " + Globals.spouseType + " and 2 kids.";
        Choosing(Part3a, Part5b);
    }

    void Part5b()
    {
        NPCText.text = "Okay. Where do they live?";
        PlayerText1.text = "Excuse me?";
        PlayerText2.text = "1508 West Pine Street in Holiday Hills.";
        Choosing(Part6a, Part6e);
    }

    void Part6a()
    {
        NPCText.text = "I asked where your family lives.";
        PlayerText1.text = "And what makes you think I would tell you that?";
        PlayerText2.text = "What do you need that for?";
        Choosing(Part6b, Part6c);
    }

    void Part6b()
    {
        if (trustPart == true)
        {
            NPCText.text = "Trust! Like we talked about. You have to trust me!";
        }
        else
        {
            NPCText.text = "If I'm going to trust you, you need to trust me.";
        }
        PlayerText1.text = "Fine. 1508 West Pine Street in Holiday Hills.";
        PlayerText2.text = "I don't really want to trust you.";
        Choosing(Part6e, Part6d);
    }

    void Part6c()
    {
        if (trustPart == true)
        {
            NPCText.text = "Like we talked about, you have to trust me!";
        }
        else
        {
            NPCText.text = "I have to make sure that I can trust you.";
        }
        PlayerText1.text = "Alright. They live at 1508 West Pine Street in Holiday Hills.";
        PlayerText2.text = "I don't want to tell you where my family lives.";
        Choosing(Part6e, Part6d);
    }

    void Part6d()
    {
        NPCText.text = "You have to trust me if you want the money. So what is it? Do you want it or not?";
        PlayerText1.text = "Not if it means telling you where my family lives! I'll be fine on my own.";
        PlayerText2.text = "Yes. 1508 West Pine Street in Holiday Hills.";
        Choosing(Part3a, Part6e);
    }

    void Part6e()
    {
        NPCText.text = "That wasn't so hard, was it? Now we can get into it.";
        Reading(Part7);
    }

    void Part7()
    {
        Globals.KnowsAboutGang = true;
        NPCText.text = "Ever since prohibition started, alcohol has been a great market to be in.";
        Reading(Part8);
    }

    void Part8()
    {
        NPCText.text = "The fact that it's illegal is a bit of a downside but the profits are astounding.";
        Reading(Part9);
    }

    void Part9()
    {
        NPCText.text = "And the best part is that you barely even have to do anything. I can get you the alochol, I just need you to sell it.";
        Reading(Part10);
    }

    void Part10()
    {
        NPCText.text = "I want you to go town to town selling it, and you'll have enough money, I guarantee it.";
        PlayerText1.text = "I don't think I want to be involved in this.";
        PlayerText2.text = "I'm in. I can't say I support it but I need the money.";
        Choosing(Part11a, Part11h);
    }

    void Part11a()
    {
        NPCText.text = "That's okay but don't go to the cops or else you won't like what happens to your family.";
        PlayerText1.text = "I won't tell anybody.";
        PlayerText2.text = "Bull! You couldn't do anything.";
        Choosing(Part11b, Part11d);
    }

    void Part11b()
    {
        NPCText.text = "You'd better not.";
        Reading(Part11c);
    }

    void Part11c()
    {
        NPCText.text = "Goodbye. If you change your mind, I'm sure I'll be around. And don't say anything. I will find out";
        Reading(EndConversation);
    }

    void Part11d()
    {
        NPCText.text = "You have no idea what I can do. And what if I can't? Is it really worth risking your families lives?";
        PlayerText1.text = "No, it isn't.";
        PlayerText2.text = "So you admit it then? You have no power.";
        Choosing(Part11e, Part11f);
    }

    void Part11e()
    {
        NPCText.text = "That's what I thought. I'll be going now, but I'll be around. Keep your mouth shut or you'll regret it.";
        Reading(EndConversation);
    }

    void Part11f()
    {
        NPCText.text = "Go. Tell the cops. Your family won't wake up tomorrow morning. It's up to you.";
        Reading(Part11g);
    }

    void Part11g()
    {
        NPCText.text = "I'll be going now. I would reccomend keeping your mouth shut if I were you.";
        Reading(EndConversation);
    }

    void Part11h()
    {
        Globals.InGang = true;
        NPCText.text = "Great! Here's something to get you started. Just these 2 gallons of moonshine will sell for about $40.";
        Reading(Part12);
    }

    void Part12()
    {
        NPCText.text = "That is expensive but our moonshine is the best in the midwest.";
        Reading(Part13);
    }

    void Part13()
    {
        NPCText.text = "I'd be willing to pay you $5 for every gallon you sell.";
        PlayerText1.text = "Only $5?";
        PlayerText2.text = "That's pretty good!";
        Choosing(Part14a, Part14c);
    }

    void Part14a()
    {
        NPCText.text = "Don't complain. Once you get good, you can sell several gallons a day.";
        Reading(Part14b);
    }

    void Part14b()
    {
        NPCText.text = "Plus, what else would you be doing instead?";
        PlayerText1.text = "Nothing, really.";
        PlayerText2.text = "I guess you're right.";
        Choosing(Part14c, Part14c); 
    }

    void Part14c()
    {
        NPCText.text = "So here's some to get started. There are some people around town who will buy it.";
        Reading(Part15);
    }

    void Part15()
    {
        NPCText.text = "But there are also people who will arrest you so be careful.";
        PlayerText1.text = "What's your name?";
        PlayerText2.text = "How can I be careful?";
        Choosing(Part16a, Part16b);
    }

    void Part16a()
    {
        NPCText.text = "That's not important. Call me El Pacone. I'll be here in Tom's shop when you need me.";
        Reading(Part17a);
    }

    void Part16b()
    {
        NPCText.text = "Don't tell people your real name. And I have a list of people who I've sold to.";
        Reading(Part17b);
    }

    void Part17a()
    {
        NPCText.text = "And never tell people your real name. Speaking of names, here's a list of people who I've sold to";
        Reading(Part17b);
    }

    void Part17b()
    {
        NPCText.text = "These people are real buyers. Other than that, you'll just have to use your best judgment.";
        Reading(Part17c);
    }

    void Part17c()
    {
        NPCText.text = "You can call me El Pacone, by the way. I'm well known around these parts";
        Reading(Part18);
    }

    void Part18()
    {
        NPCText.text = "Now get going, we can't talk for too long or else people will start to get suspicious. The best of luck to you.";
        Reading(EndConversation);
    }
}
