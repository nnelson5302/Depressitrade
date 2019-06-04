using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dorothy : ConversationBase
{
    public Dorothy(
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
    ) : base(
        _NPCText,
        _PlayerText1,
        _PlayerText2,
        _Choice1,
        _Choice2,
        _ContinueButton,
        _NPC,
        _TextBox,
        _MoneyPanel,
        _MoneyText
    )
    { }

    public override void Part1()
    {
        NPCText.text = "I don't have anything for you to do. I don't really need help selling axes.";
        Reading(EndConversation);
    }
}