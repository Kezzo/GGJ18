using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameOverButtons : MonoBehaviour, IDeselectHandler, ISelectHandler , IPointerEnterHandler, IPointerExitHandler{
	public void OnPointerEnter(PointerEventData eventData){
		Selected();
    }
     public void OnSelect(BaseEventData eventData){
		Selected();
    }

	public void OnDeselect(BaseEventData eventData){
		Deselected();
    }


	private void Selected(){
		this.transform.localScale = new Vector3(1.25f, 1.25f, 1.5f);
	}

	private void Deselected(){
		this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
	}

    public void OnPointerExit(PointerEventData eventData)
    {
        Deselected();
    }
}
