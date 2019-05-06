using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public GameObject FullPanel;
	public GameObject MainMenu;
	public GameObject SettingsMenu;
	public GameObject NameChooser;
	public GameObject PauseMenu;
	public GameObject GameOverScreen;
	public Text GameOverText;
	
	public GameObject HUD;
	public GameObject InfoBar;
	public Text CityNameObj;
	public Text MoneyText;
	public Text WeekText;
	
	public GameObject Map;
	public GameObject Inventory;
	public Text InventoryText;
	
	private GameObject CurrentMenu = null;//null means no menu is open
	
	public Slider VolumeSlider;
	
	public void ChooseName(string newname) {
		Globals.PlayerName = newname;
		CloseMenus();
		Globals.gameState = GameState.World;
	}
	
	// Use this for initialization
	void Start () {
		if (Globals.GameStarted){
			CloseMenus();
		} else {
			SwitchToMenu(MainMenu);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("p")){
			TogglePause();
		}
		MoneyText.text = Globals.FormatMoney();
		WeekText.text = "Week " + Globals.Week;
		UpdateInventoryText();
		CityNameObj.text = Globals.CurrentCity;
	}
	
	void UpdateInventoryText() {
		InventoryText.text = 
			"Wood: " + Globals.wood.ToString() + "\n";
	}
	
	//main menu
	
	private void SwitchToMenu(GameObject newmenu) {
		FullPanel.SetActive(true);
		HUD.SetActive(false);
		if (CurrentMenu != null) {
			CurrentMenu.SetActive(false);
		}
		newmenu.SetActive(true);
		CurrentMenu = newmenu;
	}
	
	private void CloseMenus() {
		if(CurrentMenu != null){
			CurrentMenu.SetActive(false);
		}
		FullPanel.SetActive(false);
		HUD.SetActive(true);
	}
	
	public void StartGame() {
		SwitchToMenu(NameChooser);
		Globals.GameStarted = true;
	}
	
	public void OpenSettings() {
		SwitchToMenu(SettingsMenu);
	}
	
	public void CloseSettings() {
		if(Globals.gameState == GameState.Paused){
			SwitchToMenu(PauseMenu);
		} else {
			SwitchToMenu(MainMenu);
		}
	}
	
	public void OpenMainMenu() {
		SwitchToMenu(MainMenu);
	}
	
	public void QuitGame() {
		Debug.Log("Quitting (this won't do anything in the editor)");
		Application.Quit();
	}
	
	public void UpdateVolume() {
		Globals.Volume = VolumeSlider.value;
	}
	
	public void OpenPauseMenu() {
		SwitchToMenu(PauseMenu);
	}
	
	public void Pause() {
		Globals.gameState = GameState.Paused;
		SwitchToMenu(PauseMenu);
	}
	
	public void Unpause() {
		Globals.gameState = GameState.World;
		CloseMenus();
	}
	
	public void TogglePause() {
		if(Globals.gameState == GameState.World){
			Pause();
		} else if (Globals.gameState == GameState.Paused){
			Unpause();
		}
	}
	
	public void OpenMap() {
		Map.SetActive(true);
		Globals.gameState = GameState.Map;
	}
	
	public void CloseMap() {
		Map.SetActive(false);
		Globals.gameState = GameState.World;
	}
	
	public void GameOver(string message) {
		SwitchToMenu(GameOverScreen);
		GameOverText.text = message;
	}
	
	public void RestartGame() {
		QuitGame();
	}
	
}
