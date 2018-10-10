using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour {

	List<string> components = new List<string>();
	bool classic = true;

	//public float timer = 10f;
	//GameObject[] Timer;

	JsonManager jsonManager;

	[System.Serializable]
	public class Colors {
		public Color panelColor = new Color(0.79f, 0.79f, 0.79f, 1f);
		public Color rightColor = new Color(0, 1, 0, 0.32f);
		public Color wrongColor = new Color(1, 0, 0, 0.32f);
		public Color textColor = new Color(1, 1, 1, 1);
		public Color buttonNextColor = new Color(1, 1, 1, 1f);
	}

	public Colors colors;

	// Questions and answers from JSON
		string[] questions;
		string[,] questionsAnswers;
		bool[,] questionsTF;
		int[] questionPics;


	// System Values
		int ansAmount;
		public int questionAmount;
		int currentQuestion = 0;
		int currentQuestionCreation = 0;
		int result = 0;

	// Question Picture changing
		public bool[] pic;
		bool picChanged = false;

	// GameObjects
		GameObject[] Canvas;

		GameObject[] MainPanel;
		GameObject[] resultPanel;
		GameObject[] QuestionPanel;
		GameObject[] AnswerPanel;
		GameObject[] TopAnswerPanel;
		GameObject[] BotAnswerPanel;

		GameObject[] Question_img;
		GameObject[] Button_img;

		GameObject[] Question_Content;
		GameObject[] Button_Content;

		GameObject[] btn;
		GameObject[] btnNext;
		GameObject[] btnNextText;
		GameObject[] resultText;
		GameObject[] resultImage;


		GameObject[] btnBack;
		GameObject[] btnBackText;

		GameObject[] canvas;

	void Start () {
		CreateInitial();
		AddJSON();
		SetImages();
		CreateQuiz(classic);
		SetQuestions();
	}

	void Update(){
		SetQuestionSizes();
		ChangePicBool();
		//SetTimer();
	}
	void AddButtonListeners(){
		btnBack[0].GetComponent<Button>().onClick.AddListener(() => GetScene(0));
	}
	void GetScene(int scene){
		SceneManager.LoadScene(scene);
	}
	void aCreateInitial(){
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
	//*****************************************************************************************
	//Function to Create Game objects	
	void AddJSON(){
		jsonManager = gameObject.AddComponent<JsonManager>();
	}

	// void SetTimer(){
	// 	timer -= Time.deltaTime;
	// 	Timer[0].GetComponent<Text>().text = timer.ToString("00");
	// 	if (timer < 0){
	// 		timer = 0;
	// 	}
	// }

	void SetImages(){
		Sprite mpspr = Resources.Load("Images/Backgrounds/bg_mainMenu", typeof(Sprite)) as Sprite;
		MainPanel[0].GetComponent<Image>().sprite = mpspr;
		MainPanel[0].GetComponent<Image>().color = Color.white;
		string[] abcd = new string[]{"A","B","C","D"};
		for(int i = 0; i < 4; i++){
			Sprite spr = Resources.Load("Images/Buttons/" + abcd[i], typeof(Sprite)) as Sprite;
        	Button_img[i].GetComponent<Image>().sprite = spr;
        	Button_img[i].GetComponent<Image>().color = Color.white;
		}
	}

	void CreateQuiz(bool type){
		if(type){
			ansAmount = 4;
		} else {
			ansAmount = 2;
		}

		questions = new string[questionAmount];
		questionsAnswers = new string[questionAmount,ansAmount];
		questionsTF = new bool[questionAmount,ansAmount];
		questionPics = new int[questionAmount];
		pic = new bool[questionAmount];

		int[] questionsOrder = jsonManager.GetRandomQuestionIDs(questionAmount);

		for(int i = 0; i < questionAmount; i++){
			CreateQuestion(questionsOrder[i]);
		}
	}

	void CreateInitial(){
		components.Clear();
		components.AddRange(new string[]{ "Canvas"});
		Creador(ref Canvas, "Canvas", 1, components);

		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer","CanvasAsParent","Stretch", "Image"});
		Creador(ref MainPanel, "MainPanel", 1, components);

		if(classic){
			CreateClassic();	
		} else {
			CreateBlitz();
		}
	}
	
	//*****************************************************************************************
	//Function to Create Game objects for Classic	

	void CreateClassic(){
		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer","MainPanelAsParent","AlignTop","Top-Bot_Panel","Image"});
		Creador(ref QuestionPanel, "QuestionPanel", 1, components);		
		
		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Image","QuestionPanelAsParent","AlignLeft_Stretch","ImageParam"});
		Creador(ref Question_img, "Question_img", 1, components);	

		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Text","QuestionPanelAsParent","AlignRight","ContentParam"});
		Creador(ref Question_Content, "Question_Content", 1, components);

		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer","MainPanelAsParent","AlignBot","Top-Bot_Panel"});
		Creador(ref AnswerPanel, "AnswerPanel", 1, components);

		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer","AnswerPanelAsParent","AlignTop","Top-Bot_Anwer_Panel"});
		Creador(ref TopAnswerPanel, "TopAnswerPanel", 1, components);

		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer","AnswerPanelAsParent","AlignBot","Top-Bot_Anwer_Panel"});
		Creador(ref BotAnswerPanel, "BotAnswerPanel", 1, components);

		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Button","AnswerPanel_top_bot_AsParent", "AlignButton","Image"});
		Creador(ref btn, "btn", 4, components);

		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Image","ButtonAsParent","AlignLeft","ImageParam"});
		Creador(ref Button_img, "Button_img", 4, components);

		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Text","ButtonAsParent","AlignRight","ContentParam"});
		Creador(ref Button_Content, "Button_Content", 4, components);

		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Image", "Button","MainPanelAsParent", "BtnNextParam"});
		Creador(ref btnNext, "Button_Next", 1, components);

		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Text","BtnNextAsParent", "BtnNextTextParam"});
		Creador(ref btnNextText, "Text", 1, components);

		// components.Clear();
		// components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Text", "MainPanelAsParent", "AlignTop", "AlignText"});
		// Creador(ref Timer, "Timer", 1, components);

		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer","CanvasAsParent", "ResultParam" ,"Image"});
		Creador(ref resultPanel, "ResultPanel", 1, components);

		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Text", "ResultPanelAsParent","ResultTextParam", "AlignTop"});
		Creador(ref resultText, "ResultText", 1, components);
	
		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Image", "ResultPanelAsParent","ResultImageParam", "AlignBot"});
		Creador(ref resultImage, "ResultImage", 1, components);
	}

	//*****************************************************************************************
	//Function to Create Game objects for Blitz

	void CreateBlitz(){
		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer","MainPanelAsParent","AlignTop","Top-Bot_Panel_Blitz","Image"});
		Creador(ref QuestionPanel, "QuestionPanel", 1, components);		
		
		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Image","QuestionPanelAsParent","AlignLeft","ImageParam"});
		Creador(ref Question_img, "Question_img", 1, components);	

		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Text","QuestionPanelAsParent","AlignRight","ContentParam"});
		Creador(ref Question_Content, "Question_Content", 1, components);

		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer","MainPanelAsParent","AlignBot","Top-Bot_Panel_Blitz"});
		Creador(ref AnswerPanel, "AnswerPanel", 1, components);

		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Button","AnswerPanelAsParent", "AlignButton","Image"});
		Creador(ref btn, "btn", 2, components);

		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Image","ButtonAsParent","AlignLeft","ImageParam"});
		Creador(ref Button_img, "Button_img", 2, components);

		components.Clear();
		components.AddRange(new string[]{ "RectTransform", "CanvasRenderer", "Text","ButtonAsParent","AlignRight","ContentParam"});
		Creador(ref Button_Content, "Button_Content", 2, components);	
	}
	
	//***********************************************************************************************************************
	//Function to give Parameters to Game Objects

	void Creador(ref GameObject[] goc, string name, int size, List<string> parameters){
		
		//Creates Game Objects
		
		goc = new GameObject[size];
		for(int i = 0; i < goc.Length; i++){
			goc[i] = new GameObject(name + i);
		}
		
		//**************************************************
		//Adds components to objects
		
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
			
			//**************************************************
			//Set Parents

			if(parameters[i] == "CanvasAsParent"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].transform.SetParent(Canvas[0].transform);
				}
			}
			if(parameters[i] == "MainPanelAsParent"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].transform.SetParent(MainPanel[0].transform);
				}
			}

			if(parameters[i] == "QuestionPanelAsParent"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].transform.SetParent(QuestionPanel[0].transform);
				}
			}

			if(parameters[i] == "AnswerPanelAsParent"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].transform.SetParent(AnswerPanel[0].transform);
				}
			}
			if(parameters[i] == "ButtonAsParent"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].transform.SetParent(btn[j].transform);
				}
			}
			if(parameters[i] == "AnswerPanel_top_bot_AsParent"){
				for(int j = 0; j < goc.Length; j++){
					if (j < 2) {
						goc[j].transform.SetParent(TopAnswerPanel[0].transform);
					}
					if(j > 1 ) {
						goc[j].transform.SetParent(BotAnswerPanel[0].transform);
					}
				}
			}
			if(parameters[i] == "BtnNextAsParent"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].transform.SetParent(btnNext[0].transform);
				}
			}
			if(parameters[i] == "ResultPanelAsParent"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].transform.SetParent(resultPanel[0].transform);
				}
			}

			// **************************************************
			// Positioning

			if(parameters[i] == "AlignLeft_Stretch"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);                                          
					goc[j].GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
				}
			}
			if(parameters[i] == "AlignRight"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].GetComponent<RectTransform>().anchorMin = new Vector2(1, 0);                                          
					goc[j].GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
				}
			}
			if(parameters[i] == "AlignLeft"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.5f);                                          
					goc[j].GetComponent<RectTransform>().anchorMax = new Vector2(0, 0.5f);
				}
			}
			if(parameters[i] == "StretchMiddle"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.5f);                                          
					goc[j].GetComponent<RectTransform>().anchorMax = new Vector2(1, 0.5f);
					goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
					Vector2 offMin = goc[j].GetComponent<RectTransform>().offsetMin;
					Vector2 offMax = goc[j].GetComponent<RectTransform>().offsetMax;
					goc[j].GetComponent<RectTransform>().offsetMin = new Vector2(0, offMin.y);
					goc[j].GetComponent<RectTransform>().offsetMax = new Vector2(0, offMax.y);
				}
			}
			if(parameters[i] == "Stretch"){
				for(int j = 0; j < goc.Length; j++){     				  
      				goc[j].GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);                                          
      				goc[j].GetComponent<RectTransform>().anchorMax = new Vector2(1, 1); 
      				goc[j].GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        			goc[j].GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);				
				}
			}
			if(parameters[i] == "AlignTop"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1);                                          
					goc[j].GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1);
				}
			}
			if(parameters[i] == "AlignBot"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);                                          
					goc[j].GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
				}
			}
			if(parameters[i] == "AlignButton"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width/2, 0);					
					if (j == 0 || j == 2) {
						goc[j].GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);                                          
						goc[j].GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
						goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(Screen.width/4, 0);
					}
					if(j == 1 || j == 3 ) {
						goc[j].GetComponent<RectTransform>().anchorMin = new Vector2(1, 0);                                          
 						goc[j].GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
 						goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(-Screen.width/4, 0);
					}
				}
			}
			if(parameters[i] == "AlignText"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height/10, Screen.height/10);
					goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -Screen.height/20);
				}
			}
			
			//**************************************************
			//Parameters for Classic
			
			if(parameters[i] == "Top-Bot_Panel"){
				for(int j = 0; j < goc.Length; j++){
					goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height / 2);                                       
					if (name == "QuestionPanel"){
						goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -Screen.height / 4);
					}
					if (name == "AnswerPanel"){
						goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, Screen.height / 4);
					}				
				}	
			}
			if(parameters[i] == "Top-Bot_Anwer_Panel"){
				for(int j = 0; j < goc.Length; j++){					
					goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height  / 4);
			       	                                      
					if (name == "TopAnswerPanel"){
						goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -Screen.height /8);
					}
					if (name == "BotAnswerPanel"){
						goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, Screen.height / 8);
					}
				}
			}	
			
			if(parameters[i] == "ImageParam"){
				for(int j = 0; j < goc.Length; j++){	
					if (name == "Button_img"){
						goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height/5, Screen.height/5);
						goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(Screen.height/20*3, 0);
					}
					if (name == "Question_img"){
						goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width/3, 0);
						goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(Screen.width/6, 0);
					}			       	                                      
				}
			}	
			if(parameters[i] == "ContentParam"){
				for(int j = 0; j < goc.Length; j++){	
					if (name == "Button_Content"){
						goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width/2-Screen.height/3f, 0);
						goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(-Screen.width/6, 0);
					}
					if (name == "Question_Content"){
						goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width/3*2, 0);
						goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(-Screen.width/3, 0);
					}							       	                                      
				}			
			}
			if(parameters[i] == "BtnNextParam"){
				for(int j = 0; j < goc.Length; j++){	
					goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width/2.5f, Screen.height/5);
					goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
					goc[j].GetComponent<Button>().onClick.AddListener(NextQuestion);
					goc[j].GetComponent<Image>().color = colors.buttonNextColor;  
					goc[j].SetActive(false);			       	                                      
				}
			}
			if(parameters[i] == "BtnNextTextParam"){
				for(int j = 0; j < goc.Length; j++){	
					goc[j].GetComponent<Text>().text = "Келесі сұрақ";
					goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width/2.5f - 10, Screen.height/5 - 5);
					goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);                       
				}
			}

			if(parameters[i] == "ResultParam"){
				for(int j = 0; j < goc.Length; j++){	
					goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width*0.8f, Screen.height*0.7f);
					goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
					goc[j].SetActive(false);                     
				}
			}

			if(parameters[i] == "ResultTextParam"){
				for(int j = 0; j < goc.Length; j++){	
					goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width*0.8f, Screen.height*0.2f);
					goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0,-Screen.height/7);
					goc[j].GetComponent<Text>().fontSize = Screen.height/7;     
				}
			}

			if(parameters[i] == "ResultImageParam"){
				for(int j = 0; j < goc.Length; j++){	
					goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width*0.6f, Screen.height*0.4f);
					goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0,Screen.height*0.25f);    
				}
			}

			if(parameters[i] == "WhiteColor"){
				for(int j = 0; j < goc.Length; j++){	
					goc[j].GetComponent<Image>().color = Color.white;
				}
			}

			if(parameters[i] == "TransparentColor"){
				for(int j = 0; j < goc.Length; j++){	
					goc[j].GetComponent<Image>().color = colors.panelColor;
				}
			}
			//**************************************************
			//Parameters for Blitz
			
			if(parameters[i] == "Top-Bot_Panel_Blitz"){
				for(int j = 0; j < goc.Length; j++){					                                       
					if (name == "QuestionPanel"){
						goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height / 3 * 2);
						goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -Screen.height / 3);
					}
					if (name == "AnswerPanel"){
						goc[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0,Screen.height / 6 );
						goc[j].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height / 3);
					}				
				}	
			}
		}
	}

	void SetQuestionSizes(){
		if(picChanged){
			if(!pic[currentQuestion]){
				Vector2 rectSizeText = Question_Content[0].GetComponent<RectTransform>().sizeDelta;
				Question_Content[0].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width,rectSizeText.y);
				Question_Content[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-Screen.width/2,0);
				
				Question_img[0].GetComponent<RectTransform>().sizeDelta = new Vector2(0,0);
				Question_img[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
			} else {
				Vector2 rectSizeText = Question_Content[0].GetComponent<RectTransform>().sizeDelta;
				Question_Content[0].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width*2/3,rectSizeText.y);
				Question_Content[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-Screen.width/3,0);
				
				Vector2 rectSizePic = Question_img[0].GetComponent<RectTransform>().sizeDelta;
				Question_img[0].GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width/3, rectSizePic.y);
				Question_img[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(Screen.width/6, rectSizePic.y);
			}
			picChanged = false;
		}
	}

	void ChangePicBool(){
		if(Input.GetKeyDown(KeyCode.P)){
			pic[currentQuestion] = !pic[currentQuestion];
		}
	}

	void CreateQuestion(int qID){
		// questionText.GetComponent<Text>().text = jsonManager.GetQuestionByID(qID);
		questions[currentQuestionCreation] = jsonManager.GetQuestionByID(qID);
		questionPics[currentQuestionCreation] = jsonManager.GetQuestionPictureByID(qID);
		pic[currentQuestionCreation] = jsonManager.GetQuestionPicExistByID(qID);
		string[] answersListFinal = jsonManager.GetAnswersByID(qID);
		for(int i = 0; i < ansAmount; i++){
			questionsAnswers[currentQuestionCreation, i] = answersListFinal[i];
			if(jsonManager.tf[i] == true){
				questionsTF[currentQuestionCreation,i] = true;
			} else {
				questionsTF[currentQuestionCreation,i] = false;
			}
		}
		currentQuestionCreation++;
	}

	void SetQuestions(){
		picChanged = true;
		Question_Content[0].GetComponent<Text>().text = questions[currentQuestion];
		Sprite spr = Resources.Load("Pictures/" + questionPics[currentQuestion], typeof(Sprite)) as Sprite;
		Question_img[0].GetComponent<Image>().sprite = spr;
		Question_img[0].GetComponent<Image>().color = Color.white;
		for(int i = 0; i < ansAmount; i++){
			btn[i].GetComponentInChildren<Text>().text = questionsAnswers[currentQuestion,i];
		}
		SetButtonListeners();
	}

	void SetButtonListeners(){
		for(int i = 0; i < ansAmount; i++){
			int ilocal = i;
			if(questionsTF[currentQuestion,i]){
				btn[i].GetComponent<Button>().onClick.AddListener(() => NextQuestionCheck(ilocal, true));
			} else {
				btn[i].GetComponent<Button>().onClick.AddListener(() => NextQuestionCheck(ilocal, false));
			}
		}
	}

	void RemoveButtonListeners(){
		for(int i = 0; i < ansAmount; i++){
			btn[i].GetComponent<Button>().onClick.RemoveAllListeners();
		}	
	}

	void NextQuestionCheck(int check, bool right){
		RemoveButtonListeners();
		if(right) result++;
		for(int i = 0; i < 4; i++){
			if(questionsTF[currentQuestion,i]){
				if(i != check){
					btn[check].GetComponent<Image>().color = colors.wrongColor;
				}
				btn[i].GetComponent<Image>().color = colors.rightColor;
			}
		}
		btnNext[0].SetActive(true);
	}

	void NextQuestion(){
		currentQuestion++;
		if(currentQuestion >= questionAmount){
			SetResults();
		} else {
			SetQuestions();
		}
		btnNext[0].SetActive(false);
		for(int i = 0; i < 4; i++){
			btn[i].GetComponent<Image>().color = colors.panelColor;
		}
	}

	void SetResults(){
		MainPanel[0].SetActive(false);
		resultPanel[0].SetActive(true);
		ChangeRanks();
		result = 0;
	}

	void ChangeRanks() {
		float score = ((float)result / (float)questionAmount) * 180;
		score = (float) Math.Round((double)score, 0, MidpointRounding.AwayFromZero);
		Debug.Log(score);
		float percent = 10;
		for(int i = 1; i < 19; i++){
			if((score >= (i-1) * percent) && (score <= i * percent)){
				Sprite spr = Resources.Load("Images/Ranks/" + i, typeof(Sprite)) as Sprite;
				resultImage[0].GetComponent<Image>().sprite = spr;
				resultImage[0].GetComponent<Image>().color = Color.white;
				resultText[0].GetComponent<Text>().text = "" + result + " / " + questionAmount;
			}
		}
		aCreateInitial();
		AddButtonListeners();
		


	}
}