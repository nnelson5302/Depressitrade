//Since I was real dumb and I didn't push at school, this is just where I'm going to make the conversation
//because I swear that I made the conversations work and made a second one but now that's gone and I hope
//it's just cuz I didn't push at school. If not..... uh oh...

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempIntroLetter : MonoBehaviour
{
    public Text letterText;
    string SpouseName;

    // Start is called before the first frame update
    void Start()
    {
        letterText.text = "Dear, " + Globals.PlayerName + ",\nThank you for doing this for us. The depression hit us hard" +
            "but I'm sure you'll help us get through it. Tom is an old friend of mine and he runs a shop in Libertyville." +
            "He said he can help get you some work. Hopefully one of us can find a more stable job soon but until then, this" +
            "will have to do. It's going to be tough and I will miss you dearly, but we'll be able to get through it.\nLove," +
            SpouseName;
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
