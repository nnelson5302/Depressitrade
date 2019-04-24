using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CityPopup : MonoBehaviour {
	
	public Text citynameobj;
	private string SceneName = "SampleScene";
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void UpdatePosition() {
		gameObject.GetComponent<RectTransform>().position = new Vector2(Input.mousePosition.x + 10, Input.mousePosition.y + 10);
	}
	
	public void Open(string CityName) { //scene name must be the same as city name
		gameObject.SetActive(true);
		citynameobj.text = CityName;
		SceneName = CityName;
		UpdatePosition();
	}
	
	public void Close() {
		gameObject.SetActive(false);
	}
	
	public void Travel() {
		SceneManager.LoadScene(SceneName);
		Globals.CurrentCity = SceneName;
	}
	
}
