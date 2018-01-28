using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	[Header("UI Elements")]
	[SerializeField] Text UIText;
	[SerializeField] Text ScoreText;
	[SerializeField] Image Blackscreen;
	[SerializeField] GameObject gameover;
	[SerializeField] GameObject gameUI;
	public float score;

	[HideInInspector]
	public bool GameStarted = false;

	[HideInInspector]
	public bool GameOver = false;
	private LightTracker lt;
	private SceneControl scene;
	public bool gamePaused = false;

	public float endScore;
	public float bestScore = 0;

	void Start(){
		score = 0;
		gameover.SetActive(false);
		gameUI.SetActive(false);
		GetComponents();
		UIText.GetComponent<Fade>().SetVisibility(true);
		ScoreText.text = ""+score.ToString("000");
	}

	void Update(){
		if(!GameStarted)
        {
			StartInput();
		}
		if(GameOver)
        {
			Blackscreen.GetComponent<Fade>().SetVisibility(true);
			endScore = score;
			if(endScore > bestScore){
				bestScore = endScore;
				PlayerPrefs.SetFloat ("highscore", bestScore);
			}
			StartCoroutine(GameoverText());
		}
		if(Input.GetKeyDown(KeyCode.Escape)){
			PauseGame();
		}
	}

	void StartInput(){
		if(Input.anyKey){
			GameStarted = true;
			UIText.GetComponent<Fade>().SetVisibility(false);
			gameUI.SetActive(true);
			lt.FirstLight();
			StartCoroutine(lt.StartChecking());

		    if (CharControl.Instance != null)
		    {
		        CharControl.Instance.AllowInput = true;
		    }
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

	public void AddScore(){
		score++;
		ScoreText.text = ""+score.ToString("000");
	}

	public void PauseGame(){
		if(!gamePaused){
			gamePaused = true;
			Time.timeScale = 0.0f;
		} else {
			gamePaused = false;
			Time.timeScale = 1.0f;
		}
	}

}
