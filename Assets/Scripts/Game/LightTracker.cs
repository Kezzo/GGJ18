using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightTracker : MonoBehaviour {
	public List<GameObject> transmitters = new List<GameObject>();

	[Header("Starting transmitter")]
	[SerializeField] GameObject startTransmitter;
	[SerializeField] Text scoreCounter;
	[SerializeField] Text lightCounter;

	[Header("Start delay")]
	[SerializeField] float waitTime;
	private LightUpBlock m_lightUpBlock;
	private float lightvalue;
	private float lightcount;
	public bool isChecking;

	private GameController gc;

	void Awake(){
		if(transmitters.Count.Equals(0)){
			foreach(GameObject transmitter in GameObject.FindGameObjectsWithTag("Transmitter")) {
				transmitters.Add(transmitter);
			}
		}
		gc = gameObject.GetComponent<GameController>();
		lightCounter.text = ""+lightcount.ToString("000");
	}


    void Update(){
		if(isChecking){ 
			CheckLights();
		}
	}

	void CheckLights(){
		lightcount = 0;
		foreach(GameObject transmitter in transmitters){
			m_lightUpBlock = transmitter.transform.GetComponent<LightUpBlock>();
			lightCounter.text = ""+lightcount.ToString("000");
			if(m_lightUpBlock.blockActive()){
				lightcount++;
			}
		}
		if(lightcount == 0){
			gc.GameOver = true;
		}
	}

	public void FirstLight()
    {
		startTransmitter.GetComponent<LightUpBlock>().Activate();
    }

	public IEnumerator StartChecking(){
		yield return new WaitForSeconds(0.5f);
		isChecking = true;
	}
}
