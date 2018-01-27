using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverScreen : MonoBehaviour {

	[SerializeField] GameController gc;
	[SerializeField] Text bestScore;
	[SerializeField] Text endScore;



	void Update(){
		bestScore.text = ""+gc.bestScore.ToString("000");
		endScore.text = ""+gc.endScore.ToString("000");
	}

	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Exit(){
		Application.Quit();
	}

}
