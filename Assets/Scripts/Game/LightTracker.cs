using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTracker : MonoBehaviour {
	public List<GameObject> transmitters = new List<GameObject>();

	[Header("Starting transmitter")]
	[SerializeField] GameObject startTransmitter;

	[Header("Start delay")]
	[SerializeField] float waitTime;
	private LightUpBlock m_lightUpBlock;
	private float lightvalue;
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
		lightvalue = 0;
		foreach(GameObject transmitter in transmitters){
			m_lightUpBlock = transmitter.transform.GetComponent<LightUpBlock>();
			lightvalue += m_lightUpBlock.ActivationValue;
		}
		Debug.Log(lightvalue);
		if(lightvalue == 0){
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
