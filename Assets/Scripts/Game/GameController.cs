using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	[Header("UI Elements")]
	[SerializeField] Text UIText;
	[SerializeField] Image Blackscreen;
	[SerializeField] GameObject gameover;

	[HideInInspector]
	public bool GameStarted = false;

	[HideInInspector]
	public bool GameOver = false;
	private LightTracker lt;
	private SceneControl scene;

	void Start(){
		gameover.SetActive(false);
		GetComponents();
		UIText.GetComponent<Fade>().SetVisibility(true);
	}

	void Update(){
		if(!GameStarted){
			StartInput();
		}
		if(GameOver){
			Blackscreen.GetComponent<Fade>().SetVisibility(true);
			StartCoroutine(GameoverText());
			EndInput();
		}
	}

	void StartInput(){
		if(Input.anyKey){
			GameStarted = true;
			UIText.GetComponent<Fade>().SetVisibility(false);
			lt.FirstLight();
			StartCoroutine(lt.StartChecking());
		}
	}

	void EndInput(){
		if(Input.anyKey){
			StartCoroutine(scene.ReloadScene(2.0f));
		}
	}

	void GetComponents(){
		lt = gameObject.GetComponent<LightTracker>();
		scene = gameObject.GetComponent<SceneControl>();
	}

	IEnumerator GameoverText(){
		yield return new WaitForSeconds (0.75f);
		gameover.SetActive(true);
	}

}
