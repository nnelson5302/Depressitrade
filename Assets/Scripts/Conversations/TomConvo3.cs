using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TomConvo3 : ConversationBase
{
    public TomConvo3(
		Text _NPCText,
		Text _PlayerText1,
		Text _PlayerText2,
		GameObject _Choice1,
		GameObject _Choice2,
		GameObject _ContinueButton,
        GameObject _MoneyPanel,
        Text _MoneyText
	) : base(
        _NPCText,
        _PlayerText1,
        _PlayerText2,
        _Choice1,
        _Choice2,
        _ContinueButton,
        _MoneyPanel,
        _MoneyText
    ) {}
	
	public override void Part1(){
        NPCText.text = "I don't have anything else for you right now. Maybe go talk to Dick?";
        Reading(EndConversation);
    }
}
