using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This highly complex script can only be comprehended by those with an IQ of at least 300

public class GameOver : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Text>().text = Globals.GameOverReason;
    }
}
