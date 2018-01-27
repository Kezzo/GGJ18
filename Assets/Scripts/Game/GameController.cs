using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	[SerializeField] Text StartText;

	[HideInInspector]
	public bool GameStarted;
	private LightTracker lt;

	void Awake(){
		GameStarted = false;
		lt = gameObject.GetComponent<LightTracker>();
		StartText.GetComponent<Fade>().SetVisibility(true);
	}

	void Update(){
		if(!GameStarted){
			StartInput();
		}
	}

	void StartInput(){
		if(Input.anyKey){
			GameStarted = true;
			StartText.GetComponent<Fade>().SetVisibility(false);
			lt.FirstLight();
		}
	}

}
