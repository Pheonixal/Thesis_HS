using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class PictureCreator {
	public int id;
	public bool Q;
	public int qId;
	public int aId;
	
	public PictureCreator(int id,bool Q,int qId, int aId){
		this.id = id;
		this.Q = Q;
		this.qId = qId;
		this.aId = aId;
	}
}

