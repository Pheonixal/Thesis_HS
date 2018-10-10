using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AdminMenu : MonoBehaviour {

	public int window;
	JsonManager jsonManager;
	Popup popup;
	bool toog;
	public string txt,qID,aID;
	GameObject go;
	string strstart = "0";
	int start = 0;
	int width = 150;
	int height = 25;
	string pIDstr = "0";

	void Start () { 
        window = 1; 
		go = GameObject.FindGameObjectWithTag ("MainCamera");
		jsonManager = go.AddComponent<JsonManager> ();
		popup = go.AddComponent<Popup>();
	}

	void back(int a, int pos) {
		if (GUI.Button (new Rect (Screen.width/2, height * pos, Screen.width/2, height), "Артқа")) { 
			window = a; 
		}
	}

	void OnGUI (){

		GUI.BeginGroup (new Rect (0, 0, Screen.width, Screen.height)); 
		
		if (window == 1) {
			if (GUI.Button (new Rect (0, 0, Screen.width, height), "Сұрақтар қосу")) { 
				window = 2; 
			} 
			// if (GUI.Button (new Rect (0, height, Screen.width, height), "Привязать картинки")) { 
			// 	window = 3; 
			// } 
			
		}

		if (window == 2) { 
			//GUI.Label (new Rect (0, 0, width, height), "Выбери крч 3-еун біреун");

			if (GUI.Button (new Rect (0, height, Screen.width, height), "Сұрақтар")) { 
				window = 4;
			} 
			if (GUI.Button (new Rect (0, height * 2, Screen.width, height), "Жауаптар")) { 
				window = 5;
			} 
			if (GUI.Button (new Rect (0, height * 3, Screen.width, height), "Суреттер")) { 
				window = 6;
			}
			if (GUI.Button (new Rect (0, height * 5, Screen.width, height), "Артқа")) { 
				window = 1; 
			} 
		}

		// QUESTIONS
		if (window == 4) {
			GUI.Label (new Rect(0, 0, Screen.width, height),"Сұрақтың аты");
			txt = GUI.TextField (new Rect(0, height, Screen.width, height),txt, 1024);
			if (GUI.Button (new Rect (0, height * 2, Screen.width, height), "қосу")) {
				jsonManager.AddQuestion (txt);
				txt = "";
			}
			if (GUI.Button (new Rect (0, height * 3, Screen.width, height), "Барлық сұрақтарды жою")) {
				jsonManager.Clear ("Q");
			}
			back(2,5);
		}

		// ANSWEEEEEEEEEEEEEEEEEEEEEEEEEEEEERRRSSS
		if(window == 5) {
			GUI.Label (new Rect(0,0,Screen.width/2,height),"Сурақ ID");
			GUI.Label (new Rect(Screen.width/2,0,Screen.width/2,height),"Жауап аты");
			string[] qlist = jsonManager.GetQuestions(start);
			GUIContent[] strgui = new GUIContent[qlist.Length];
			for(int i = 0; i < qlist.Length; i++){
				strgui[i] = new GUIContent(qlist[i]);
			}
			int picked = popup.List(new Rect (0, height, Screen.width/2, height), strgui, GUIStyle.none, GUIStyle.none);
			txt = GUI.TextField (new Rect(Screen.width/2, height, Screen.width/2, height), txt, 1024);
			toog = GUI.Toggle (new Rect(Screen.width/2,height * 2,Screen.width/2,height),toog,"Дұрыс жауап?");
			
			if (GUI.Button (new Rect (Screen.width/2,height * 3, Screen.width/2, height), "қосу")) {
				jsonManager.AddAnswer (txt, picked, toog);
				txt = "";
				qID = "";
				toog = false;
			}
			if (GUI.Button (new Rect (Screen.width/2, height * 4, Screen.width/2, height), "Барлық жауаптарды жою")) {
				jsonManager.Clear ("A");
			}

			GUI.Label (new Rect(Screen.width/2,height * 6,Screen.width/2,height),"Бастау");
			
			strstart = GUI.TextField (new Rect(Screen.width/2, height * 7, Screen.width/2, height), strstart, 50);
			start = Int32.Parse(strstart);

			back(2,9);
		}

		// PICTUREEEEEEEEEEEEEEEEEEEESSSSSSSSSSSSSS
		if(window == 6) {
			int picked;
			if(!toog){
				GUI.Label (new Rect(0,0,Screen.width/2,height),"Сұрақ ID");
				string[] qlist = jsonManager.GetQuestions(start);
				GUIContent[] strgui = new GUIContent[qlist.Length];
				for(int i = 0; i < qlist.Length; i++){
					strgui[i] = new GUIContent(qlist[i]);
				}
				picked = popup.List(new Rect (0, height, Screen.width/2, height), strgui, GUIStyle.none, GUIStyle.none);	
			} else {
				GUI.Label (new Rect(0,0,Screen.width/2,height),"жауап ID");
				string[] alist = jsonManager.GetAnswers(start);
				GUIContent[] strgui = new GUIContent[alist.Length];
				for(int i = 0; i < alist.Length; i++){
					strgui[i] = new GUIContent(alist[i]);
				}
				picked = popup.List(new Rect (0, height, Screen.width/2, height), strgui, GUIStyle.none, GUIStyle.none);	
			}

			GUI.Label (new Rect(Screen.width/2,0,Screen.width/2,height),"Сурет ID");
			
			pIDstr = GUI.TextField (new Rect(Screen.width/2, height, Screen.width/2, height), pIDstr, 50);

			Texture tex = Resources.Load("Суреттер/" + Int32.Parse(pIDstr), typeof(Texture)) as Texture;

			toog = GUI.Toggle (new Rect(Screen.width/2,height * 2,Screen.width/2,height),toog, "Жауап?");
			GUI.DrawTexture (new Rect(Screen.width/2,height * 3,height * 3,height * 3),tex);

			if (GUI.Button (new Rect (Screen.width/2, height * 6, Screen.width/2, height), "Қосу")) {
				jsonManager.AddPicture(Int32.Parse(pIDstr),toog,picked, picked);
				txt = "";
				qID = "";
				aID = "";
				toog = false;
			}
			if (GUI.Button (new Rect (Screen.width/2, height * 7, Screen.width/2, height), "Барлық суреттерді жою")) {
				jsonManager.Clear ("P");
			}

			GUI.Label (new Rect(Screen.width/2,height * 9,Screen.width/2,height),"Бастау");
			strstart = GUI.TextField (new Rect(Screen.width/2, height * 10, Screen.width/2, height), strstart, 50);
			start = Int32.Parse(strstart);

			back(2,12);
		}

		GUI.EndGroup (); 
	}
}
