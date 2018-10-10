using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickButton : MonoBehaviour {

	public float timer = 5f;
	[SerializeField] private Text randomText;


	public void Button_Onclick(GameObject Go){		
		randomText.enabled = true;
		Debug.Log("Button Clicked");
		ChangeText(Go.name);
		SceneManager.LoadScene(4);
	}

	public void Text_enable(){

		if(randomText.enabled){
	
			if(timer > 0 ){
				timer -= Time.deltaTime;
			}
			else{
				randomText.enabled = false;
				Reset();
			}
		}
	
	}
	void Update ()	{
		Text_enable();
	}

	void Reset(){
    	timer = 5f;
 	}


	public void ChangeText(string name){
		if (name == "Button"){
			randomText.text = "asdasdadas";
		}
		if (name == "Button2"){
			randomText.text = "sdasd";
		}
	}
}
