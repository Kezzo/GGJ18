using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour {
	[SerializeField] GameObject menu;
	public VideoPlayer vid;
	private SceneControl scene;
	void Start(){
		menu.SetActive(false);
		vid.GetComponent<VideoPlayer>().Play();
		scene = gameObject.GetComponent<SceneControl>();
		InvokeRepeating("checkOver", .1f,.1f);
	}

	private void checkOver(){
		long playerCurrentFrame = vid.GetComponent<VideoPlayer>().frame;
		long playerFrameCount = System.Convert.ToInt64(vid.GetComponent<VideoPlayer>().frameCount);
		
		if(playerCurrentFrame < playerFrameCount)
		{
			print ("VIDEO IS PLAYING");
		}
		else
		{
			print ("VIDEO IS OVER");
			CancelInvoke("checkOver");
			menu.SetActive(true);
		}
	}

	public void PlayGame(){
		scene.LoadScene(0.0f, "playerTest");
	}

	public void AboutMenu(){

	}

	public void ExitGame(){

	}

}
