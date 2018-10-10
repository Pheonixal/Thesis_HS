using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Lesson : MonoBehaviour {

	GameObject btn1;
	GameObject btn2;
	GameObject btn3;
	GameObject btn4;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		btn1 = GameObject.Find("btn1");

		btn1.GetComponent<RectTransform>().anchorMin = new Vector2(0,1); 								// anchor Min X and Y
		btn1.GetComponent<RectTransform>().anchorMax = new Vector2(0,1); 								// anchor Max X and Y
		btn1.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
		
        btn1.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height / 4.56f, Screen.height / 4.56f);
        btn1.GetComponent<Image>().type = Image.Type.Sliced;
        btn1.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector2(0, -Screen.height / 6);
		btn1.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height / 3, Screen.height / 3);
		btn1.transform.GetChild(0).GetComponent<Text>().fontSize = Screen.width/30;

		btn2 = GameObject.Find("btn2");

		btn2.GetComponent<RectTransform>().anchorMin = new Vector2(1,1); 								// anchor Min X and Y
		btn2.GetComponent<RectTransform>().anchorMax = new Vector2(1,1); 								// anchor Max X and Y
		btn2.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
		
        btn2.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height / 4.56f, Screen.height / 4.56f);
        btn2.GetComponent<Image>().type = Image.Type.Sliced;
        btn2.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector2(0, -Screen.height / 6);
		btn2.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height / 3, Screen.height / 3);
		btn2.transform.GetChild(0).GetComponent<Text>().fontSize = Screen.width/30;

		btn3 = GameObject.Find("btn3");

		btn3.GetComponent<RectTransform>().anchorMin = new Vector2(0,0); 								// anchor Min X and Y
		btn3.GetComponent<RectTransform>().anchorMax = new Vector2(0,0); 								// anchor Max X and Y
		btn3.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
		
        btn3.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height / 4.56f, Screen.height / 4.56f);
        btn3.GetComponent<Image>().type = Image.Type.Sliced;
        btn3.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector2(0, -Screen.height / 6);
		btn3.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height / 3, Screen.height / 3);
		btn3.transform.GetChild(0).GetComponent<Text>().fontSize = Screen.width/30;

		btn4 = GameObject.Find("btn4");

		btn4.GetComponent<RectTransform>().anchorMin = new Vector2(1,0); 								// anchor Min X and Y
		btn4.GetComponent<RectTransform>().anchorMax = new Vector2(1,0); 								// anchor Max X and Y
		btn4.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
		
        btn4.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height / 4.56f, Screen.height / 4.56f);
        btn4.GetComponent<Image>().type = Image.Type.Sliced;
        btn4.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector2(0, -Screen.height / 6);
		btn4.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height / 3, Screen.height / 3);
		btn4.transform.GetChild(0).GetComponent<Text>().fontSize = Screen.width/30;
	}
}
