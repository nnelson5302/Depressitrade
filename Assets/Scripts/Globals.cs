﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState {MainMenu, Paused, World, Map};

//just for having static variables, don't instantiate this class
public static class Globals {
    public static bool MusicCreated = false;
	public static string PlayerName = "Walter";
    public static string parentType = "daddy";
    public static string spouseName = "generic_name_277.0.2";
    public static string spouseType = "generic_parental_unit_277.0.2";
    public static string spousePronoun = "generic_pronoun277.0.2";
    public static int Money = 750; //this is in cents to avoid floating point errors
	public static float Volume = 0; //our game has no sound lol
	public static string CurrentCity = "Libertyville";
	public static GameState gameState = GameState.MainMenu;
	public static int Week = 1;
	public static string ConversationPerson = "Tom"; //set before changing to conversation scene
	public static string GameOverReason = "You died";
	
	public static bool GameStarted = false;//set to true after player goes through the main menu
    public static bool LetterTime = true;
    public static bool FreezePlayerPosition = true;
	//Resources
	public static int wood = 0;
    public static int axe = 0;
	//I assume there will be more resources to add once we have progressed the story more...
	
	//Story
	public static bool HadFirstTomConversation = false;
	public static bool HadSecondTomConversation = false;
    public static bool HadThirdTomConversation = false;
    public static bool HadFirstDickConversation = false;
    public static bool HadSecondDickConversation = false;
    public static bool HadFirstGangConversation = false;
    public static bool HadTomBreadConversation = false;
    public static bool GotAxe = false;
	public static bool dickfriend = false;
    public static bool KnowsAboutGang = false;
    public static bool InGang = false;
    public static bool ReportsToPoliceWithTom = false;
    public static bool TomWillFindAlcoholDealer = false;
    public static bool TomCheckedForAlcoholDealer = false;
    public static bool TomToldAboutAlcoholDealer = false;
    public static bool leftConversation = false;
    public static int AxeType = 5;

    public static bool MapActive = false;
    public static bool ChangeMusic = true;
    public static int MusicType = 0;
    public static float PlayerPositionX = 0;
    public static float PlayerPositionY = 0;

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

    public static void SetVariables()
    {
        if (PlayerName == "Walter")
        {
            parentType = "daddy";
            spouseName = "Mildred";
            spouseType = "mommy";
            spousePronoun = "she";
        }
        
        else if (PlayerName == "Mildred")
        {
            parentType = "mommy";
            spouseName = "Walter";
            spouseType = "daddy";
            spousePronoun = "he";
        }
    }
}
