using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {MainMenu, Paused, World, Map};

//just for having static variables, don't instantiate this class
public class Globals : MonoBehaviour {
	
	public static string PlayerName = "Walter";
	public static int Money = 500; //this is in cents to avoid floating point errors
	public static float Volume = 0; //our game has no sound lol
	public static string CurrentCity = "Aidan test";
	public static GameState gameState = GameState.MainMenu;
	
	//Resources
	public static int wood = 5;
	//I assume there will be more resources to add once we have progressed the story more...
	
	public static string FormatMoney() {
		string str = Money.ToString();
		if (str.Length >= 3){
			str = str.Insert(str.Length-2,".");
		} else if (str.Length == 2){
			str = "0." + str;
		} else if (str.Length == 1){
			str = "0.0" + str;
		}
		return "$"+str;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
