using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class AnswerCreator {
	
	public string name;
	public int id;
	public int qId;
	public bool right;

	public AnswerCreator(string name,  int qId, bool right) {
		this.name = name;
		this.qId = qId;
		this.right = right;
		GetID();
	}
	void GetID() {
		string path = Application.dataPath + "/Resources/Amounts/amountA.txt";
		string idstr = System.IO.File.ReadAllText(path);
		this.id = Int32.Parse(idstr);
		this.id++;
	}
}