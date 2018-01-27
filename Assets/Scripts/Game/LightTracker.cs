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
	}


    void Update(){
		if(isChecking){ 
			CheckLights();
		}
	}

	void CheckLights(){
		lightcount = 0;
		foreach(GameObject transmitter in transmitters){
<<<<<<< HEAD
			block = transmitter.transform.GetComponent<BlockLightUp>();
			lightCounter.text = lightcount.ToString();
			if(block.blockActive()){
				lightcount++;
			}
=======
			m_lightUpBlock = transmitter.transform.GetComponent<LightUpBlock>();
			lightvalue += m_lightUpBlock.ActivationValue;
>>>>>>> 520c8f89c90b75cf4fef8308ae08ce32e828b889
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
