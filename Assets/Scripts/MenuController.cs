using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public GameObject FullPanel;
	public GameObject MainMenu;
	public GameObject SettingsMenu;
	public GameObject NameChooser;
	public GameObject PauseButton;
	public GameObject PauseMenu;
	
	private GameObject CurrentMenu = null;//null means no menu is open
	
	public Slider VolumeSlider;
	
	public void ChooseName(string newname) {
		Globals.playerName = newname;
		CloseMenus();
		Globals.gameState = GameState.World;
	}
	
	// Use this for initialization
	void Start () {
		SwitchToMenu(MainMenu);
		Debug.Log(Globals.FormatMoney());
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("p")){
			TogglePause();
		}
	}
	
	//main menu
	
	private void SwitchToMenu(GameObject newmenu) {
		FullPanel.SetActive(true);
		PauseButton.SetActive(false);
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
		PauseButton.SetActive(true);
	}
	
	public void StartGame() {
		SwitchToMenu(NameChooser);
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
		Globals.volume = VolumeSlider.value;
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
}
