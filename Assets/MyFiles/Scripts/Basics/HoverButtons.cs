using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;


public class HoverButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    
    public Image img;
    public Color temp;
    public bool isOver;

    public void OnPointerEnter(PointerEventData eventData){
    	isOver = true;
    	img = gameObject.GetComponent<Image>();
    	temp = img.color;
    	temp.a = 0.6f;
    	img.color = temp;

    	// if(eventData.button == gameObject.GetComponent<Button>()){
    	// 	temp.a = 0.8f;
    	// 	img.color = temp;
    	// }
    }

    public void OnPointerExit(PointerEventData eventData){
    	isOver = false;
    	img = gameObject.GetComponent<Image>();
    	temp = img.color;
    	temp.a = 0.3f;
    	img.color = temp;

    	// if(eventData.button == gameObject.GetComponent<Button>()){
    	// 	temp.a = 0.8f;
    	// 	img.color = temp;
    	// }
    }
}
