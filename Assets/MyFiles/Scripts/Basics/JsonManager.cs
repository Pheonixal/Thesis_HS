using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JsonManager : MonoBehaviour {
	bool android = false;
	public QuestionCreator[] questions;
	public AnswerCreator[] answers;
	public PictureCreator[] pictures;
	string jsonA, jsonQ, jsonP;
	int amountA,amountQ,amountP;

	public string pathQ, pathA, pathP;
	public string ApathQ, ApathA, ApathP;
	public string pathInit;
	string jsonQI = "[{\"name\":\"Test\",\"id\":0}]";
	string jsonAI = "[{\"name\":\"Test\",\"qid\":0,\"id\":0,\"right\":false}]";
	string jsonPI = "[{\"id\":0,\"qId\":0,\"aId\":0,\"Q\":false}]";

	public bool[] tf = new bool[]{false,false,false,false};

	void Start () {
		GetPath();
		if (android) {
			AddJsonAndAmount();
		}
		ReadJson();
		TrimNormalize();
		ObjectsFromJson();
	}

	void AddJsonAndAmount(){
		TextAsset textasset;
		string json = "";
		string txt = "";
		
		if(!System.IO.Directory.Exists(Application.persistentDataPath + "/Json")){
			System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/Json");
		}

		if(!System.IO.Directory.Exists(Application.persistentDataPath + "/Amounts")){
			System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/Amounts");
		}

		if(!System.IO.File.Exists(pathA)){
			textasset = Resources.Load("Json/Answers", typeof(TextAsset)) as TextAsset;
			json = textasset.text; 
  			System.IO.File.WriteAllText(pathA, json);
		}

		if(!System.IO.File.Exists(pathQ)){
  			textasset = Resources.Load("Json/Questions", typeof(TextAsset)) as TextAsset;
			json = textasset.text; 
  			System.IO.File.WriteAllText(pathQ, json);
  		}

  		if(!System.IO.File.Exists(pathP)){
  			textasset = Resources.Load("Json/Pictures", typeof(TextAsset)) as TextAsset;
			json = textasset.text; 
  			System.IO.File.WriteAllText(pathP, json);
  		}

  		if(!System.IO.File.Exists(ApathA)){
  			textasset = Resources.Load("Amounts/amountA", typeof(TextAsset)) as TextAsset;
			txt = textasset.text;
			Debug.Log(txt); 
  			System.IO.File.WriteAllText(ApathA,	txt);
  		}

  		if(!System.IO.File.Exists(ApathQ)){
  			textasset = Resources.Load("Amounts/amountQ", typeof(TextAsset)) as TextAsset;
			txt = textasset.text;
			Debug.Log(txt); 
  			System.IO.File.WriteAllText(ApathQ,	txt);
  		}

  		if(!System.IO.File.Exists(ApathP)){
  			textasset = Resources.Load("Amounts/amountP", typeof(TextAsset)) as TextAsset;
			txt = textasset.text;
			Debug.Log(txt); 
  			System.IO.File.WriteAllText(ApathP,	txt);
  		}
	}

	public void GetPath(){
		if (android) {
			pathInit = Application.persistentDataPath + "/";
		} else {
			pathInit = Application.dataPath + "/Resources/";
		}

		pathQ = pathInit + "Json/Questions.json";
		pathA = pathInit + "Json/Answers.json";		
		pathP = pathInit + "Json/Pictures.json";
		ApathQ = pathInit + "Amounts/amountQ.txt";
		ApathA = pathInit + "Amounts/amountA.txt";		
		ApathP = pathInit + "Amounts/amountP.txt";
	}
		
	void ReadJson(){
		jsonQ = System.IO.File.ReadAllText(pathQ);
		jsonA = System.IO.File.ReadAllText(pathA);	
		jsonP = System.IO.File.ReadAllText(pathP);
	}
	
	void WriteJson(string path, string objpath, string QAP){
		if(QAP == "Q") {
			System.IO.File.WriteAllText(path, jsonQ);
			System.IO.File.WriteAllText(objpath, "" + amountQ);
		}
		if(QAP == "A") {
			System.IO.File.WriteAllText(path, jsonA);
			System.IO.File.WriteAllText(objpath, "" + amountA);
		}
		if(QAP == "P") {
			System.IO.File.WriteAllText(path, jsonP);
			System.IO.File.WriteAllText(objpath, "" + amountP);
		}
	}

	public void Clear(string type){
		ClearAmounts(type);
		ClearJson(type);
	}
	
	public string[] GetQuestions(int start){
		Start();
		string[] qS = new string[questions.Length - start];
		for(int i = start; i < questions.Length; i++){
			qS[i-start] = i + " " + questions[i].name;
		}
		return qS;
	}

	public string[] GetAnswers(int start){
		Start();
		string[] aS = new string[answers.Length - start];
		for(int i = start; i < answers.Length; i++){
			aS[i-start] = i + " " + answers[i].name;
		}
		return aS;
	}

	public int[] GetRandomQuestionIDs(int amount){
		Start();
		int size = questions.Length;
		int[] randomQIDs = RandomUnique(amount, 1, size);
		return randomQIDs;
	}

	public string GetQuestionByID(int qid){
		Start();
		string q = "";
		for(int i = 0; i < questions.Length; i++){
			if(questions[i].id == qid){
				q = questions[i].name;		
			}
		}
		return q;
	}

	public int GetQuestionPictureByID(int qid){
		Start();
		int q = 0;
		for(int i = 0; i < pictures.Length; i++){
			if(pictures[i].qId == qid){
				q = pictures[i].id;
				break;
			}
		}
		return q;
	}

	public bool GetQuestionPicExistByID(int qid){
		Start();
		bool q = false;
		for(int i = 0; i < pictures.Length; i++){
			if(pictures[i].qId == qid){
				q = true;
				break;
			}
		}
		return q;
	}

	public string[] GetAnswersByID(int qid){
		Start();
		int count = 0;
		for(int i = 0; i < answers.Length; i++){
			if(answers[i].qId == qid){
				count++;
			}
		}
		
		if(count < 2 || count > 4){
			Debug.Log("Error, <2 or >4 answers");
		}

		string[] answersList = new string[count];
		count = 0;

		for(int i = 0; i < answers.Length; i++){
			if(answers[i].qId == qid){
				answersList[count] = answers[i].name;
				count++;
			}
		}

		Shuffle(answersList);

		ResetTF();
		
		for(int i = 0; i < answers.Length; i++){
			for(int j = 0; j < 4; j++){
				if(answers[i].qId == qid && answers[i].name == answersList[j] && answers[i].right){
					tf[j] = true;
				}	
			}
		}
		
		return answersList;
	}

	void ClearAmounts(string type){
		if(type == "Q") System.IO.File.WriteAllText(ApathQ, "0");
		if(type == "A") System.IO.File.WriteAllText(ApathA, "0");
		if(type == "P") System.IO.File.WriteAllText(ApathP, "0");
	}
	
	void ClearJson(string type){
		if(type == "Q") System.IO.File.WriteAllText(pathQ, jsonQI);
		if(type == "A") System.IO.File.WriteAllText(pathA, jsonAI);
		if(type == "P") System.IO.File.WriteAllText(pathP, jsonPI);
	}

	void ObjectsFromJson(){
		questions = JsonHelper.getJsonArray<QuestionCreator> (jsonQ);
		amountQ = questions[questions.Length-1].id;

		answers = JsonHelper.getJsonArray<AnswerCreator> (jsonA);
		amountA = answers[answers.Length-1].id;

		pictures = JsonHelper.getJsonArray<PictureCreator> (jsonP);
		amountP = pictures[pictures.Length-1].id;
	}
	
	public void AddQuestion(string name){
		QuestionCreator newObject = new QuestionCreator(name);
		string objjson = JsonUtility.ToJson(newObject);
		AddObjectToJson(jsonQ, objjson, "Q");
		ObjectsFromJson();
		WriteJson(pathQ,ApathQ,"Q");
	}

	public void AddAnswer(string name, int qId, bool Q){
		AnswerCreator newObject = new AnswerCreator(name, qId, Q);
		string objjson = JsonUtility.ToJson(newObject);
		AddObjectToJson(jsonA, objjson, "A");
		ObjectsFromJson();
		WriteJson(pathA,ApathA,"A");
	}

	public void AddPicture(int id, bool Q, int qId, int aId){
		PictureCreator newObject = new PictureCreator(id, Q, qId, aId);
		string objjson = JsonUtility.ToJson(newObject);
		AddObjectToJson(jsonP, objjson, "P");
		ObjectsFromJson();
		WriteJson(pathP,ApathP,"P");
	}

	void TrimNormalize() {
		jsonQ = jsonQ.Replace("\n", "");
		jsonQ = jsonQ.Replace("\t", "");
		jsonQ = jsonQ.Replace("\r", "");
		jsonA = jsonA.Replace("\n", "");
		jsonA = jsonA.Replace("\t", "");
		jsonA = jsonA.Replace("\r", "");
		jsonP = jsonP.Replace("\n", "");
		jsonP = jsonP.Replace("\t", "");
		jsonP = jsonP.Replace("\r", "");
		//
	}
	
	void AddObjectToJson(string oldjson, string newjson, string QAP){
		if(QAP == "Q") {
			oldjson = oldjson.Substring(0,oldjson.Length-1);
			jsonQ = oldjson + "," + newjson + "]";
		}
		if(QAP == "A") {
			oldjson = oldjson.Substring(0,oldjson.Length-1);
			jsonA = oldjson + "," + newjson + "]";
		}
		if(QAP == "P") {
			oldjson = oldjson.Substring(0,oldjson.Length-1);
			jsonP = oldjson + "," + newjson + "]";
		}
	}

	public static void Shuffle<T> (T[] array)
    {
        int n = array.Length;
        while (n > 1) 
        {
            int k = Random.Range(0,n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }

    public void ResetTF(){
    	for(int i = 0; i < 4; i++){
    		tf[i] = false;
    	}
    }

    public int[] RandomUnique(int amount, int start, int end){
    	List<int> randomList = new List<int>();
		int MyNumber = 0;
		int i = 0;
		while(i < amount){
			MyNumber = Random.Range(start, end);		
			if (!randomList.Contains(MyNumber)){
        		randomList.Add(MyNumber);
        		i++;
			}
		}	
		return randomList.ToArray();
    }
}
