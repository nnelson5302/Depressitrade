using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// To make something have a tooltip, add an event trigger componenent to it and set it to call open on this object with the desired text
// on pointer enter, and call close on pointer exit.

public class Tooltip : MonoBehaviour {

	public GameObject textobj;

	public void Update() {
		UpdatePosition();
	}
	
	private void UpdatePosition() {
		gameObject.GetComponent<RectTransform>().position = new Vector2(Input.mousePosition.x + 10, Input.mousePosition.y + 10);
	}
	
	public void Open(string text) {
		gameObject.SetActive(true);
		textobj.GetComponent<Text>().text = text;
		UpdatePosition();
	}
	
	public void Close() {
		gameObject.SetActive(false);
	}
}
