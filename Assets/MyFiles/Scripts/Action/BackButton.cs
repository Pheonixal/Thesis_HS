
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {

	List<string> components = new List<string>();

	GameObject[] canvas;

	GameObject[] btnBack;
	GameObject[] btnBackText;

	[System.Serializable]
	public class Colors {
		public Color panelColor = new Color(0.79f, 0.79f, 0.79f, 1f);
		public Color rightColor = new Color(0, 1, 0, 0.32f);
		public Color wrongColor = new Color(1, 0, 0, 0.32f);
		public Color textColor = new Color(1, 1, 1, 1);
		public Color buttonNextColor = new Color(1, 1, 1, 1f);
	}

	public Colors colors;

	void Start () {
		CreateInitial();		
		AddButtonListeners();
	}

	void AddButtonListeners(){
		btnBack[0].GetComponent<Button>().onClick.AddListener(() => GetScene(0));
	}

	void GetScene(int scene){
		SceneManager.LoadScene(scene);
	}

	

	void CreateInitial(){
		components.Clear();
		components.AddRange(new string[]{ "Canvas"});
		Creador(ref canvas, "Canvas", 1, components);

		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Image", "Button", "CanvasAsParent", "BtnBack"});
		Creador(ref btnBack, "Button Back", 1, components);

		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Text", "BtnBackAsParent", "BtnBackText"});
		Creador(ref btnBackText, "Button Back Text", 1, components);
	}

	void Creador(ref GameObject[] goc, string name, int size, List<string> parameters){
		
		goc = new GameObject[size];
		
		for(int i = 0; i < goc.Length; i++){
			if(i == 0) goc[i] = new GameObject(name);
			if(i != 0) goc[i] = new GameObject(name + " [" + i + "]");
		}

		for(int i = 0; i < parameters.Count; i++){
			
			if(parameters[i] == "Button"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].AddComponent<Button>();
				}
			}
			
			if(parameters[i] == "RectTransform"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].AddComponent<RectTransform>();
				}
			}
			
			if(parameters[i] == "Image"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].AddComponent<Image>();
					// Делаем всем Image стандартный бэкграунд фон
					Sprite sprite = Resources.Load("Images/Panels/panel", typeof(Sprite)) as Sprite;
					goc[j].GetComponent<Image>().sprite = sprite;
					goc[j].GetComponent<Image>().type = Image.Type.Sliced;
					goc[j].GetComponent<Image>().color = colors.panelColor;
				}
			}
			
			if(parameters[i] == "CanvasRenderer"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].AddComponent<CanvasRenderer>();					
				}
			}
			
			if(parameters[i] == "GraphicRaycaster"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].AddComponent<GraphicRaycaster>();
				}
			}
			
			if(parameters[i] == "Canvas"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].AddComponent<Canvas>();
					goc[j].GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
					goc[j].AddComponent<CanvasScaler>();
					goc[j].AddComponent<GraphicRaycaster>();
				}
			}
			
			if(parameters[i] == "Text"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].AddComponent<Text>();
					goc[j].GetComponent<Text>().text = "Random Text";
					goc[j].GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
					goc[j].GetComponent<Text>().font = Resources.Load("Fonts/cs_regular", typeof(Font)) as Font;
					goc[j].GetComponent<Text>().fontSize = Screen.height/15;
					goc[j].GetComponent<Text>().lineSpacing = 1.5f;
					goc[j].GetComponent<Text>().color = colors.textColor;
				}
			}	
			
			//Set Parents

			if(parameters[i] == "CanvasAsParent"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].transform.SetParent(canvas[0].transform);
				}
			}
			

			if(parameters[i] == "BtnBackAsParent"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].transform.SetParent(btnBack[0].transform);
				}
			}

			if(parameters[i] == "BtnBack"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].GetComponent<RectTransform>().anchorMin = new Vector2(0,0);
					goc[j].GetComponent<RectTransform>().anchorMax = new Vector2(0,0);
					float wh = Screen.height / 5;
					goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(wh,wh);
					goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(wh/2+10, wh/2+10);
				}
			}


			if(parameters[i] == "BtnBackText"){
				for(int j = 0; j < goc.Length; j++){
					float fs = Screen.height / 27f;
					goc[j].GetComponent<Text>().fontSize = (int)fs;
					goc[j].GetComponent<Text>().text = "<< Back";
					goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
				}
			}
		
		}
	}
}
