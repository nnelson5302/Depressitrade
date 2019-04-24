using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {MainMenu, Paused, World};

//just for having static variables, don't instatiate this class
public class Globals : MonoBehaviour {
	
	public static string playerName = "Mysterious Person";
	public static int money = 0; //this is in cents to avoid floating point errors
	public static float volume = 0;
	public static GameState gameState = GameState.MainMenu;
	
	public static string FormatMoney() {
		string str = money.ToString();
		if (str.Length >= 3){
			str = str.Insert(str.Length-2,".");
		} else if (str.Length == 2){
			str = "0." + str;
		} else if (str.Length == 1){
			str = "0.0" + str;
		}
		return str;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
