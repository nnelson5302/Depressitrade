using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MAP : MonoBehaviour {

    public Image Map;
    public Button Libertyville;
	
	private float scale = 1;
	private float panX = -200;
	private float panY = 0;

	void Start (){
    }
	
	void Update () 
    {
		
		//Zoom
		if(Input.GetAxis("Mouse ScrollWheel")>0){
			scale = scale * 1.11f;
		} else if(Input.GetAxis("Mouse ScrollWheel")<0){
			scale = scale * 0.9f;
		}
		if(scale > 2f){
			scale = 2f;
		} else if(scale < 0.5f){
			scale = 0.5f;
		}
		Map.GetComponent<RectTransform>().localScale = new Vector2(scale, scale);
        
		
		//Pan
		panX += -Input.GetAxis("Horizontal") * 4;
		if(panX < -400 * scale){
			panX = -400 * scale;
		} else if(panX > 100 * scale){
			panX = 100 * scale;
		}
		panY += -Input.GetAxis("Vertical") * 4;
		if(panY < -200 * scale){
			panY = -200 * scale;
		} else if(panY > 300 * scale){
			panY = 300 * scale;
		}
        Map.rectTransform.anchoredPosition = new Vector2(panX, panY);

		//I hope we never have to resurrect this beast
		/*
        if (Map.GetComponent<RectTransform>().anchorMin.x <= 1.5 && Map.GetComponent<RectTransform>().anchorMin.y <= 1.5 &&
            Map.GetComponent<RectTransform>().anchorMax.x >= 1 && Map.GetComponent<RectTransform>().anchorMax.y >= 1
            && Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Map.GetComponent<RectTransform>().anchorMin += new Vector2(-Input.GetAxis("Mouse ScrollWheel"), -Input.GetAxis("Mouse ScrollWheel"));
            Map.GetComponent<RectTransform>().anchorMax += new Vector2(Input.GetAxis("Mouse ScrollWheel"), Input.GetAxis("Mouse ScrollWheel"));
            //Libertyville.GetComponent<RectTransform>().anchorMin = Map.GetComponent<RectTransform>().anchorMin;
            //Libertyville.GetComponent<RectTransform>().anchorMax = Map.GetComponent<RectTransform>().anchorMax;
        }

        else if (Map.GetComponent<RectTransform>().anchorMin.x >= -2.7 && Map.GetComponent<RectTransform>().anchorMin.y >= -2.7 &&
                Map.GetComponent<RectTransform>().anchorMax.x <= 3.7 && Map.GetComponent<RectTransform>().anchorMax.y <= 3.7 &&
                Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Map.GetComponent<RectTransform>().anchorMin += new Vector2(-Input.GetAxis("Mouse ScrollWheel"), -Input.GetAxis("Mouse ScrollWheel"));
            Map.GetComponent<RectTransform>().anchorMax += new Vector2(Input.GetAxis("Mouse ScrollWheel"), Input.GetAxis("Mouse ScrollWheel"));
            //Libertyville.GetComponent<RectTransform>().anchorMin = Map.GetComponent<RectTransform>().anchorMin;
            //Libertyville.GetComponent<RectTransform>().anchorMax = Map.GetComponent<RectTransform>().anchorMax;
        }
		*/
        
    }
}