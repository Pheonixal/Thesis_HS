using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[System.Serializable]
public class QuestionCreator {
	
	public string name;
	public int id;

	public QuestionCreator(string name) {
		this.name = name;
		GetID();
	}
	    void GetID() {
		string path = Application.dataPath + "/Resources/Amounts/amountQ.txt";
		string idstr = System.IO.File.ReadAllText(path);
	
		this.id = Int32.Parse(idstr);
		this.id++;
	}
}
