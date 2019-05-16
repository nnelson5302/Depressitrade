using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState {MainMenu, Paused, World, Map};

//just for having static variables, don't instantiate this class
public static class Globals {
	public static string PlayerName = "Walter";
	public static int Money = 500; //this is in cents to avoid floating point errors
	public static float Volume = 0; //our game has no sound lol
	public static string CurrentCity = "Libertyville";
	public static GameState gameState = GameState.MainMenu;
	public static int Week = 1;
	public static string ConversationPerson = "Tom"; //set before changing to conversation scene
	public static string GameOverReason = "You died";
	
	public static bool GameStarted = false;//set to true after player goes through the main menu
	
	//Resources
	public static int wood = 0;
	//I assume there will be more resources to add once we have progressed the story more...
	
	//Story
	public static bool HadFirstTomConversation = false;
	
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

	public static string FormatMoney(int amount) {
		string str = amount.ToString();
		if (str.Length >= 3){
			str = str.Insert(str.Length-2,".");
		} else if (str.Length == 2){
			str = "0." + str;
		} else if (str.Length == 1){
			str = "0.0" + str;
		}
		return "$"+str;
	}

	public static void GameOver(string reason) {
		GameOverReason = reason;
		SceneManager.LoadScene("Game Over");
	}
}
