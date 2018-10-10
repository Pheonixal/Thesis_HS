using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizOpen : MonoBehaviour {

	public void Button_Onclick(GameObject Go){		
		Debug.Log("Button Clicked");
		SceneManager.LoadScene(3);
	}
	
}
