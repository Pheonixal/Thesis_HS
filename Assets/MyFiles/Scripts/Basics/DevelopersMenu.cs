using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DevelopersMenu : MonoBehaviour {

	List<string> components = new List<string>();

	GameObject[] canvas;
	
	// GameObject[] mainPanel;
	// GameObject[] centerPanel;
	// //GameObject[] centerLeftPanel;
	// GameObject[] centerCenterPanel;
	// //GameObject[] centerRightPanel;

	// //GameObject[] imageLeft;
	// GameObject[] imageCenter;
	// //GameObject[] imageRight;

	// //GameObject[] textLeft;
	// GameObject[] textCenter;
	// //GameObject[] textRight;

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
		//SetImagesAndTexts();
		AddButtonListeners();
	}

	void AddButtonListeners(){
		btnBack[0].GetComponent<Button>().onClick.AddListener(() => GetScene(0));
	}

	void GetScene(int scene){
		SceneManager.LoadScene(scene);
	}

	// void SetImagesAndTexts(){
	// 	string path = "Avatars/";
	// 	//Sprite adi = Resources.Load(path + "adi", typeof(Sprite)) as Sprite;
	// 	Sprite almaz = Resources.Load(path + "almaz", typeof(Sprite)) as Sprite;
	// 	//Sprite wymbo = Resources.Load(path + "wymbo", typeof(Sprite)) as Sprite;
	// 	Sprite background = Resources.Load(path + "background", typeof(Sprite)) as Sprite;

	// 	//imageLeft[0].GetComponent<Image>().sprite = adi;
	// 	imageCenter[0].GetComponent<Image>().sprite = almaz;
	// 	//imageRight[0].GetComponent<Image>().sprite = wymbo;

	// 	mainPanel[0].GetComponent<Image>().sprite = background;

	// 	//textLeft[0].GetComponent<Text>().text = "ADI : MANAGER";
	// 	textCenter[0].GetComponent<Text>().text = "ALMAS";
	// 	//textRight[0].GetComponent<Text>().text = "WYMBO : DEVELOPER";
	// }

	void CreateInitial(){
		components.Clear();
		components.AddRange(new string[]{ "Canvas"});
		Creador(ref canvas, "Canvas", 1, components);

	// 	components.Clear();
	// 	components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Image", "CenterMiddle", "CanvasAsParent", "MainPanel"});
	// 	Creador(ref mainPanel, "Main Panel", 1, components);

	// 	components.Clear();
	// 	components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Image", "CenterMiddle", "MainPanelAsParent", "CenterPanel"});
	// 	Creador(ref centerPanel, "Center Panel", 1, components);

	// //		components.Clear();
	// //		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Image", "CenterMiddle", "CenterPanelAsParent", "ThreeCenterPanels", "CenterPanelLeft"});
	// //		Creador(ref centerLeftPanel, "Center Left Panel", 1, components);

	// 	components.Clear();
	// 	components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Image", "CenterMiddle", "CenterPanelAsParent", "ThreeCenterPanels", "CenterPanelCenter"});
	// 	Creador(ref centerCenterPanel, "Center Center Panel", 1, components);

	// //	components.Clear();
	// //	components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Image", "CenterMiddle", "CenterPanelAsParent", "ThreeCenterPanels", "CenterPanelRight"});
	// //	Creador(ref centerRightPanel, "Center Right Panel", 1, components);

	// //	components.Clear();
	// //	components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Image", "CenterTop", "CenterLeftPanelAsParent", "ThreeCenterImages"});
	// //	Creador(ref imageLeft, "Image Left", 1, components);

	// 	components.Clear();
	// 	components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Image", "CenterTop", "CenterCenterPanelAsParent", "ThreeCenterImages"});
	// 	Creador(ref imageCenter, "Image Center", 1, components);

	// //		components.Clear();
	// //		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Image", "CenterTop", "CenterRightPanelAsParent", "ThreeCenterImages"});
	// //		Creador(ref imageRight, "Image Right", 1, components);

	// //		components.Clear();
	// //		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Text", "CenterBottom", "CenterLeftPanelAsParent", "ThreeCenterTexts"});
	// //		Creador(ref textLeft, "Text Left", 1, components);

	// 	components.Clear();
	// 	components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Text", "CenterBottom", "CenterCenterPanelAsParent", "ThreeCenterTexts"});
	// 	Creador(ref textCenter, "Text Center", 1, components);

	//		components.Clear();
		//	components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Text", "CenterBottom", "CenterRightPanelAsParent", "ThreeCenterTexts"});
	//		Creador(ref textRight, "Text Right", 1, components);

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

			// if(parameters[i] == "MainPanelAsParent"){
			// 	for(int j = 0; j < goc.Length; j++){
			// 		goc[j].transform.SetParent(mainPanel[0].transform);
			// 	}
			// }

			// if(parameters[i] == "CenterPanelAsParent"){
			// 	for(int j = 0; j < goc.Length; j++){
			// 		goc[j].transform.SetParent(centerPanel[0].transform);
			// 	}
			// }

		//	if(parameters[i] == "CenterLeftPanelAsParent"){
		//		for(int j = 0; j < goc.Length; j++){
		//			goc[j].transform.SetParent(centerLeftPanel[0].transform);
		//		}
		//	}

		//	if(parameters[i] == "CenterRightPanelAsParent"){
		//		for(int j = 0; j < goc.Length; j++){
		//			goc[j].transform.SetParent(centerRightPanel[0].transform);
		//		}
		//	}

			// if(parameters[i] == "CenterCenterPanelAsParent"){
			// 	for(int j = 0; j < goc.Length; j++){
			// 		goc[j].transform.SetParent(centerCenterPanel[0].transform);
			// 	}
			// }

			if(parameters[i] == "BtnBackAsParent"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].transform.SetParent(btnBack[0].transform);
				}
			}

		// 	// Positioning

		// 	if(parameters[i] == "CenterMiddle"){
		// 		for(int j = 0; j < goc.Length; j++){
		// 			goc[j].GetComponent<RectTransform>().anchorMin = new Vector2(0.5f,0.5f);
		// 			goc[j].GetComponent<RectTransform>().anchorMax = new Vector2(0.5f,0.5f);
		// 		}
		// 	}

		// 	if(parameters[i] == "CenterTop"){
		// 		for(int j = 0; j < goc.Length; j++){
		// 			goc[j].GetComponent<RectTransform>().anchorMin = new Vector2(0.5f,1);
		// 			goc[j].GetComponent<RectTransform>().anchorMax = new Vector2(0.5f,1);
		// 		}
		// 	}

		// 	if(parameters[i] == "CenterBottom"){
		// 		for(int j = 0; j < goc.Length; j++){
		// 			goc[j].GetComponent<RectTransform>().anchorMin = new Vector2(0.5f,0);
		// 			goc[j].GetComponent<RectTransform>().anchorMax = new Vector2(0.5f,0);
		// 		}
		// 	}
			
		// 	//Parameters for Classic
			
		// 	if(parameters[i] == "MainPanel"){
		// 		for(int j = 0; j < goc.Length; j++){
		// 			goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
		// 			goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
		// 		}
		// 	}

		// 	if(parameters[i] == "CenterPanel"){
		// 		for(int j = 0; j < goc.Length; j++){
		// 			goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
		// 			goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height/2.25f);
		// 		}
		// 	}

		// 	if(parameters[i] == "ThreeCenterPanels"){
		// 		for(int j = 0; j < goc.Length; j++){
		// 			float wh = Screen.height / 2.53f;
		// 			goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
		// 			goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(wh,wh);
		// 		}
		// 	}

		// 	if(parameters[i] == "CenterPanelLeft"){
		// 		for(int j = 0; j < goc.Length; j++){
		// 			float wh = Screen.height / 2.53f;
		// 			goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(-wh-15,0);
		// 		}
		// 	}

		// 	if(parameters[i] == "CenterPanelCenter"){
		// 		for(int j = 0; j < goc.Length; j++){
		// 			goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
		// 		}
		// 	}

		// 	if(parameters[i] == "CenterPanelRight"){
		// 		float wh = Screen.height / 2.53f;
		// 		for(int j = 0; j < goc.Length; j++){
		// 			goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(wh+15,0);
		// 		}
		// 	}

		// 	if(parameters[i] == "ThreeCenterImages"){
		// 		for(int j = 0; j < goc.Length; j++){
		// 			float wh = Screen.height / 3.37f;
		// 			goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(wh,wh);
		// 			goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, - wh/2 - 10);
		// 		}
		// 	}

		// 	if(parameters[i] == "ThreeCenterTexts"){
		// 		for(int j = 0; j < goc.Length; j++){
		// 			float wh = Screen.height / 2.53f;
		// 			float ts = Screen.height / 11.54f;
		// 			float fs = Screen.height / 35f;
		// 			goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(wh,ts);
		// 			goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, ts/2);
		// 			goc[j].GetComponent<Text>().fontSize = (int)fs; 
		// 		}
		// 	}

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
