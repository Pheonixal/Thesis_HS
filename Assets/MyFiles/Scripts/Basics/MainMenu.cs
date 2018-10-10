using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	GameObject canvas;

	GameObject mainPanel;
	GameObject leftPanel;
	GameObject centerPanel;
	GameObject rightPanel;

	GameObject leftPanelMask;
	GameObject centerPanelMask;
	GameObject rightPanelMask;

	GameObject btnPlay;
	GameObject btnDev;
	GameObject btnQuit;
	GameObject btnSwitch;

	GameObject btnPlay1;
	GameObject btnTest;
	GameObject btnExit;

	GameObject txtPlay;
	GameObject txtDev;
	GameObject txtQuit;
	
	[System.Serializable]
	public class stringTypes {
		public string canvas = "canvas";
		public string panel = "panel";
		public string button = "button";
		public string text = "text";
		public string play = "play";
		public string dev = "dev";
		public string quit = "quit";
		public string main = "main";
		public string left = "left";
		public string right = "right";
		public string center = "center";
		public string leftMask = "leftMask";
		public string centerMask = "centerMask";
		public string rightMask = "rightMask";
		public string mask = "mask";		
	}

	public stringTypes Types;

	public float offsetDevQuit;
	public float offsetSwitch;
	
	public float offsetMask;
	public float maskWidth;
	public float maskHeight;

	public float offsetText;
	public float textWidth;
	public float textHeight;
	
	bool CT = true;
	bool CTs = false;

	public Color maskColor = new Color(1,1,1,0.5f);
	
	string tcolorButtons = "9F8A5C";
	string ctcolorButtons = "3D70A8";

	void Start () {
		canvas = GameObject.Find("Canvas");
		btnPlay1 = GameObject.Find("btnPlay");
		btnTest = GameObject.Find("btnTest");
		btnExit = GameObject.Find("btnExit");


		CreateGameObjects();
		Components();
		Settings();
		AddButtonListeners();		

		leftPanelMask.SetActive(false);		
		btnPlay.SetActive(false);
		btnDev.SetActive(false);
		txtPlay.SetActive(false);
		txtDev.SetActive(false);
		centerPanelMask.SetActive(false);
		rightPanelMask.SetActive(false);
		btnQuit.SetActive(false);
		txtQuit.SetActive(false);


		btnPlay1.transform.SetParent(leftPanel.transform);
		btnTest.transform.SetParent(centerPanel.transform);
		btnExit.transform.SetParent(rightPanel.transform);

		btnPlay1.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f,0.5f); 								// anchor Min X and Y
		btnPlay1.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f,0.5f); 								// anchor Max X and Y
		btnPlay1.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);

		Sprite sprDev = Resources.Load("Images/Buttons/btn_dev", typeof(Sprite)) as Sprite;
        btnPlay1.GetComponent<Image>().sprite = sprDev;
        btnPlay1.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height / 4.56f, Screen.height / 4.56f);
        btnPlay1.GetComponent<Image>().type = Image.Type.Sliced;
        btnPlay1.transform.GetChild(0).GetComponent<Text>().text = "Сабақтар";
        btnPlay1.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector2(0, -Screen.height / 6);
		btnPlay1.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height / 3, Screen.height / 3);
		btnPlay1.transform.GetChild(0).GetComponent<Text>().fontSize = Screen.width/30;
       

		btnTest.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f,0.5f); 								// anchor Min X and Y
		btnTest.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f,0.5f); 								// anchor Max X and Y
		btnTest.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
		btnTest.transform.GetChild(0).GetComponent<Text>().text = "Тест";

		btnTest.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height / 4.56f, Screen.height / 4.56f);
		Sprite sprPlay = Resources.Load("Images/Buttons/btn_play", typeof(Sprite)) as Sprite;
		btnTest.GetComponent<Image>().sprite = sprPlay;
		btnTest.GetComponent<Image>().type = Image.Type.Sliced;
		btnTest.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector2(0, -Screen.height / 6);
		btnTest.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height / 3, Screen.height / 3);
		btnTest.transform.GetChild(0).GetComponent<Text>().fontSize = Screen.width/30;
		//btnTest.GetComponent<Image>().color = maskColor;
		

		btnExit.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f,0.5f); 								// anchor Min X and Y
		btnExit.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f,0.5f); 								// anchor Max X and Y
		btnExit.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);

		Sprite sprQuit = Resources.Load("Images/Buttons/btn_quit", typeof(Sprite)) as Sprite;
        btnExit.GetComponent<Image>().sprite = sprQuit;
        btnExit.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height / 4.56f, Screen.height / 4.56f);
        btnExit.GetComponent<Image>().type = Image.Type.Sliced;
        btnExit.transform.GetChild(0).GetComponent<Text>().text = "Шығу";
        btnExit.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector2(0, -Screen.height / 6);
		btnExit.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height / 4.56f, Screen.height / 4.56f);
		btnExit.transform.GetChild(0).GetComponent<Text>().fontSize = Screen.width/30;


	}
	
	void Update () {
		SetTheme();
		UpdateValues();
		Sizes();
	}

	void CreateGameObjects(){
		//canvas = new GameObject("Canvas");
		
		mainPanel = new GameObject("Main Panel");
		leftPanel = new GameObject("Left Panel");
		centerPanel = new GameObject("Center Panel");
		rightPanel = new GameObject("Right Panel");

		leftPanelMask = new GameObject("Left Panel Mask");
		centerPanelMask = new GameObject("Center Panel Mask");
		rightPanelMask = new GameObject("Right Panel Mask");
		
		btnPlay = new GameObject("Play");
		btnDev = new GameObject("Developers");
		btnQuit = new GameObject("Quit");
		btnSwitch = new GameObject("Switch");
				
		txtPlay = new GameObject("Play");
		txtDev = new GameObject("Developers");
		txtQuit = new GameObject("Quit");		
	}

	void AddButtonListeners(){
		btnPlay1.GetComponent<Button>().onClick.AddListener(() => GetScene(7));
		btnTest.GetComponent<Button>().onClick.AddListener(() => GetScene(5));
		btnExit.GetComponent<Button>().onClick.AddListener(() => Application.Quit());
	}

	void GetScene(int scene){
		SceneManager.LoadScene(scene);
	}

	void Components(){
		//AddComponents(canvas, Types.canvas, Types.canvas);

		AddComponents(mainPanel, Types.panel, Types.main);
		AddComponents(leftPanel, Types.panel, Types.left);
		AddComponents(centerPanel, Types.panel, Types.right);
		AddComponents(rightPanel, Types.panel, Types.center);

		AddComponents(leftPanelMask, Types.panel, Types.mask);
		AddComponents(centerPanelMask, Types.panel, Types.mask);
		AddComponents(rightPanelMask, Types.panel, Types.mask);

		AddComponents(btnPlay, Types.button, Types.play);
		AddComponents(btnDev, Types.button, Types.dev);
		AddComponents(btnQuit, Types.button, Types.quit);
		AddComponents(btnSwitch, Types.button, "switch");
		
		AddComponents(txtPlay, Types.text, Types.play);
		AddComponents(txtDev, Types.text, Types.dev);
		AddComponents(txtQuit, Types.text, Types.quit);
	}

	void AddComponents(GameObject go, string type, string it){
		// if(type == Types.canvas){
		// 	go.AddComponent<Canvas>();
		// 	go.AddComponent<CanvasScaler>();
  //    		go.AddComponent<GraphicRaycaster>();
		// }
		
		if(type == Types.panel){	
			go.AddComponent<RectTransform>();
        	go.AddComponent<CanvasRenderer>();
        	
        	if(it == Types.main){
        		go.AddComponent<Image>();
        		go.AddComponent<HorizontalLayoutGroup>();
        	}
        	if(it == Types.mask){
        		//go.AddComponent<BoxCollider2D>();
        		go.AddComponent<Image>();
        		go.AddComponent<Button>();
        		go.AddComponent<EventTrigger>();
        		go.AddComponent<HoverButtons>();
        	}
		}
		
		if(type == Types.button){
			go.AddComponent<RectTransform>();
			go.AddComponent<CanvasRenderer>();
			go.AddComponent<Image>();
			go.AddComponent<Button>();
		}
		
		if(type == Types.text){
			go.AddComponent<RectTransform>();
			go.AddComponent<CanvasRenderer>();
			go.AddComponent<Text>();
		}
	}

	void Settings(){
		//AddSettings(canvas, Types.canvas, Types.canvas);

		AddSettings(mainPanel, Types.panel, Types.main);
		AddSettings(leftPanel, Types.panel, Types.left);
		AddSettings(centerPanel, Types.panel, Types.right);
		AddSettings(rightPanel, Types.panel, Types.center);

		AddSettings(leftPanelMask, Types.panel, Types.leftMask);
		AddSettings(centerPanelMask, Types.panel, Types.centerMask);
		AddSettings(rightPanelMask, Types.panel, Types.rightMask);

		AddSettings(btnPlay, Types.button, Types.play);
		AddSettings(btnDev, Types.button, Types.dev);
		AddSettings(btnQuit, Types.button, Types.quit);
		AddSettings(btnSwitch, Types.button, "switch");
		
		AddSettings(txtPlay, Types.text, Types.play);
		AddSettings(txtDev, Types.text, Types.dev);
		AddSettings(txtQuit, Types.text, Types.quit);
	}

	void AddSettings(GameObject go, string type, string it){
		
		// if(type == Types.canvas){
		// 	go.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
		// }
		
		if(type == Types.panel){
			
			if(it == Types.main){
				go.transform.SetParent(canvas.transform);
				go.GetComponent<RectTransform>().anchorMin = new Vector2(0,0); 								// anchor Min X and Y
				go.GetComponent<RectTransform>().anchorMax = new Vector2(1,1); 								// anchor Max X and Y
				go.GetComponent<RectTransform>().offsetMin = new Vector2(0,0);								// left, bottom
				go.GetComponent<RectTransform>().offsetMax = new Vector2(0,0);
			}
			
			if(it == Types.left){
				go.transform.SetParent(mainPanel.transform);
			}
			
			if(it == Types.center){
				go.transform.SetParent(mainPanel.transform);
			}
			
			if(it == Types.right){
				go.transform.SetParent(mainPanel.transform);
			}

			if(it == Types.leftMask){
				go.transform.SetParent(leftPanel.transform);
				//go.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
				go.GetComponent<RectTransform>().sizeDelta = new Vector2(maskWidth, maskHeight);
				Sprite sprite = Resources.Load("Images/Panels/panel", typeof(Sprite)) as Sprite;
				go.GetComponent<Image>().sprite = sprite;
				go.GetComponent<Image>().type = Image.Type.Sliced;
				go.GetComponent<Image>().color = maskColor;
				go.GetComponent<RectTransform>().anchorMin = new Vector2(0,0.5f); 								// anchor Min X and Y
				go.GetComponent<RectTransform>().anchorMax = new Vector2(0,0.5f); 								// anchor Max X and Y
				//go.GetComponent<Image>().raycastTarget = false;
				//go.GetComponent<BoxCollider2D>().size = new Vector2(maskWidth, maskHeight);
			}

			if(it == Types.rightMask){
				go.transform.SetParent(rightPanel.transform);
				go.GetComponent<RectTransform>().localPosition = new Vector2(0, -offsetMask-offsetDevQuit);
				go.GetComponent<RectTransform>().sizeDelta = new Vector2(maskWidth/2, maskHeight/2);
				// Sprite sprite = Resources.Load("Images/Panels/panel", typeof(Sprite)) as Sprite;
				// go.GetComponent<Image>().sprite = sprite;
				// go.GetComponent<Image>().type = Image.Type.Sliced;
				// go.GetComponent<Image>().color = maskColor;
				//go.GetComponent<Image>().raycastTarget = false;
				//go.GetComponent<BoxCollider2D>().size = new Vector2(maskWidth, maskHeight);
			}

			if(it == Types.centerMask){
				go.transform.SetParent(centerPanel.transform);
				go.GetComponent<RectTransform>().localPosition = new Vector2(0, -offsetMask);
				go.GetComponent<RectTransform>().sizeDelta = new Vector2(maskWidth, maskHeight);
				Sprite sprite = Resources.Load("Images/Panels/panel", typeof(Sprite)) as Sprite;
				go.GetComponent<Image>().sprite = sprite;
				go.GetComponent<Image>().type = Image.Type.Sliced;
				go.GetComponent<Image>().color = maskColor;
				//go.GetComponent<Image>().raycastTarget = false;
				//go.GetComponent<BoxCollider2D>().size = new Vector2(maskWidth, maskHeight);
			}
		}

		if(type == Types.button){

			if(it == Types.play){
				go.transform.SetParent(centerPanel.transform);
				go.GetComponent<RectTransform>().sizeDelta = new Vector2(offsetDevQuit, offsetDevQuit);
				Sprite sprPlay = Resources.Load("Images/Buttons/btn_play", typeof(Sprite)) as Sprite;
        		go.GetComponent<Image>().sprite = sprPlay;
        		go.GetComponent<Image>().raycastTarget = false;
			}
			
			if(it == Types.dev){
				go.transform.SetParent(leftPanel.transform);
				//go.GetComponent<RectTransform>().localPosition = new Vector2(0, -offsetDevQuit);
				go.GetComponent<RectTransform>().sizeDelta = new Vector2(offsetDevQuit, offsetDevQuit);
				Sprite sprDev = Resources.Load("Images/Buttons/btn_dev", typeof(Sprite)) as Sprite;
        		go.GetComponent<Image>().sprite = sprDev;
        		go.GetComponent<Image>().raycastTarget = false;
			}
			
			if(it == Types.quit){
				go.transform.SetParent(rightPanel.transform);
				go.GetComponent<RectTransform>().localPosition = new Vector2(0, -offsetDevQuit);
				go.GetComponent<RectTransform>().sizeDelta = new Vector2(offsetDevQuit, offsetDevQuit);
				Sprite sprQuit = Resources.Load("Images/Buttons/btn_quit", typeof(Sprite)) as Sprite;
        		go.GetComponent<Image>().sprite = sprQuit;
        		go.GetComponent<Image>().raycastTarget = false;
			}
			
			if(it == "switch"){
				go.transform.SetParent(centerPanel.transform);
				go.GetComponent<RectTransform>().localPosition = new Vector2(0, offsetSwitch);
				go.GetComponent<RectTransform>().sizeDelta = new Vector2(offsetDevQuit, offsetDevQuit);
				Sprite sprCoin = new Sprite();
				if(CT) { sprCoin = Resources.Load("Images/Buttons/ct_coin", typeof(Sprite)) as Sprite; }
        		if(!CT) { sprCoin = Resources.Load("Images/Buttons/t_coin", typeof(Sprite)) as Sprite; }
        		go.GetComponent<Image>().sprite = sprCoin;
        		go.GetComponent<Button>().onClick.AddListener(SwitchCT);
			}
		}
		if(type == Types.text){
			
			if(it == Types.play){
				go.GetComponent<Text>().text = "Тест";
				go.transform.SetParent(btnPlay.transform);
 			}
 		
 			if(it == Types.dev){
				go.GetComponent<Text>().text = "Білім";
 				go.transform.SetParent(btnDev.transform);
			}
 		
 			if(it == Types.quit){
				go.GetComponent<Text>().text = "Exit";
 				go.transform.SetParent(btnQuit.transform);
 			}

 			go.GetComponent<RectTransform>().localPosition = new Vector2(0, -offsetText);
 			go.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
			go.GetComponent<Text>().font = Resources.Load("Fonts/cs_regular", typeof(Font)) as Font;
			go.GetComponent<Text>().fontSize = Screen.width/30;
			go.GetComponent<RectTransform>().sizeDelta = new Vector2(textWidth, textHeight);
		}
	}

	void Sizes(){
		UpdateSizes(leftPanelMask, Types.panel, Types.leftMask);
		UpdateSizes(centerPanelMask, Types.panel, Types.centerMask);
		UpdateSizes(rightPanelMask, Types.panel, Types.rightMask);

		UpdateSizes(btnPlay, Types.button, Types.play);
		UpdateSizes(btnDev, Types.button, Types.dev);
		UpdateSizes(btnQuit, Types.button, Types.quit);
		UpdateSizes(btnSwitch, Types.button, "switch");
		
		UpdateSizes(txtPlay, Types.text, Types.play);
		UpdateSizes(txtDev, Types.text, Types.dev);
		UpdateSizes(txtQuit, Types.text, Types.quit);
	}

	void UpdateValues(){
		offsetDevQuit = Screen.height / 4.56f;
		offsetSwitch = Screen.height / 2.8f;
	
		offsetMask = Screen.height / 22.8f;
		maskWidth = Screen.width / 3.3f;
		maskHeight = Screen.height / 2.38f;

		offsetText = Screen.height / 5;
		textWidth = Screen.width / 3;
		textHeight = Screen.height / 14;
	}

	void UpdateSizes(GameObject go, string type, string it){
		
		if(type == Types.panel){
			
			if(it == Types.leftMask){
				go.GetComponent<RectTransform>().localPosition = new Vector2(0, -offsetMask-offsetDevQuit);
				go.GetComponent<RectTransform>().sizeDelta = new Vector2(maskWidth, maskHeight);
			}

			if(it == Types.rightMask){
				go.GetComponent<RectTransform>().localPosition = new Vector2(0, -offsetMask-offsetDevQuit);
				go.GetComponent<RectTransform>().sizeDelta = new Vector2(maskWidth, maskHeight);
			}

			if(it == Types.centerMask){
				go.GetComponent<RectTransform>().localPosition = new Vector2(0, -offsetMask);
				go.GetComponent<RectTransform>().sizeDelta = new Vector2(maskWidth, maskHeight);
			}
		}

		if(type == Types.button){

			if(it == Types.play){
				go.GetComponent<RectTransform>().sizeDelta = new Vector2(offsetDevQuit, offsetDevQuit);
			}
			
			if(it == Types.dev){
				go.GetComponent<RectTransform>().localPosition = new Vector2(0, -offsetDevQuit);
				go.GetComponent<RectTransform>().sizeDelta = new Vector2(offsetDevQuit, offsetDevQuit);
			}
			
			if(it == Types.quit){
				go.GetComponent<RectTransform>().localPosition = new Vector2(0, -offsetDevQuit);
				go.GetComponent<RectTransform>().sizeDelta = new Vector2(offsetDevQuit, offsetDevQuit);
			}
			
			if(it == "switch"){
				go.GetComponent<RectTransform>().localPosition = new Vector2(0, offsetSwitch);
				go.GetComponent<RectTransform>().sizeDelta = new Vector2(offsetDevQuit, offsetDevQuit);
			}
		}

		if(type == Types.text){
 			go.GetComponent<RectTransform>().localPosition = new Vector2(0, -offsetText);
			go.GetComponent<RectTransform>().sizeDelta = new Vector2(textWidth, textHeight);
		}
	}


 	void SwitchCT(){
 		CT = !CT;
 	}

 	void SetTheme(){
 		if(CT != CTs){
 			if(CT){
				
				Sprite spr = Resources.Load("Images/Backgrounds/bg_ct", typeof(Sprite)) as Sprite;
        		mainPanel.GetComponent<Image>().sprite = spr;
	
        		Sprite coin = Resources.Load("Images/Buttons/ct_coin", typeof(Sprite)) as Sprite;
        		btnSwitch.GetComponent<Image>().sprite = coin;
	
			
			} else {
	
				Sprite spr = Resources.Load("Images/Backgrounds/bg_t", typeof(Sprite)) as Sprite;
    		   	mainPanel.GetComponent<Image>().sprite = spr;
	
    		   	Sprite coin = Resources.Load("Images/Buttons/t_coin", typeof(Sprite)) as Sprite;
        		btnSwitch.GetComponent<Image>().sprite = coin;
	
			}
			CTs = CT;
 		}
 	}

}