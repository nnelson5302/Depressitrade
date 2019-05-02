using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeNeedThreeFiddy : MonoBehaviour 
{
    // Start is called before the first frame update
    public Text letterText;
    string parentType = "generic_parental_unit_277.0.1";
    string spouseType = "generic_parental_unit_277.0.2";
    string spousePronoun = "generic_pronoun277.0.2";

    void Start()
    {
        if (Globals.PlayerName == "Walter")
        {
            parentType = "daddy";
            spouseType = "mommy";
            spousePronoun = "she";
        }
        else
        {
            parentType = "mommy";
            spouseType = "daddy";
            spousePronoun = "he";
        }

        letterText.text = "Hi " + parentType + "!\n Im almost five yers old! " + spouseType + " is really tierd and mad. " + spousePronoun +
            " says you are getting monie to get us food. Im really hungrie. We only eat potatos and " + spouseType +
            " says were running out of those. We need monie. " + spouseType + " told me to ask you for ten dolers. Can you do that " +
            parentType + "? If you dont I dont no what well do. \n \n  Love, Alice";
    }

}
