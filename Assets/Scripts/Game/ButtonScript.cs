using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour, IDeselectHandler, ISelectHandler , IPointerEnterHandler, IPointerExitHandler{

	[SerializeField] GameObject deactivated;
	[SerializeField] GameObject activated;

	public void OnPointerEnter(PointerEventData eventData){
		Selected();
    }
     public void OnSelect(BaseEventData eventData){
		Selected();
    }

	public void OnDeselect(BaseEventData eventData){
		Deselected();
    }

	public void OnPointerExit(BaseEventData eventData){
		Deselected();
	}

	private void Selected(){
		activated.SetActive(true);
		deactivated.SetActive(false);
	}

	private void Deselected(){
		activated.SetActive(false);
		deactivated.SetActive(true);
	}

    public void OnPointerExit(PointerEventData eventData)
    {
        Deselected();
    }
}
