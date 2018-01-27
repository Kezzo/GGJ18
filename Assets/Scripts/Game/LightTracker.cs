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
	private BlockLightUp block;
	private float lightvalue;
	private bool gameStart;

	void Awake(){
		if(transmitters.Count.Equals(0)){
			foreach(GameObject transmitter in GameObject.FindGameObjectsWithTag("Transmitter")) {
				transmitters.Add(transmitter);
			}
		}
		StartCoroutine(startLight(waitTime));
	}


    void Update(){
		if(gameStart){ CheckLights() ; }
	}

	void CheckLights(){
		lightvalue = 0;
		foreach(GameObject transmitter in transmitters){
			block = transmitter.transform.GetComponent<BlockLightUp>();
			lightvalue += block.m_normalizedBrightness;
		}
		Debug.Log(lightvalue);

		if(lightvalue == 0){
			Debug.Log("Game over");
		}
	}

	private IEnumerator startLight(float waitTime)
    {
		yield return new WaitForSeconds(waitTime);
		startTransmitter.GetComponent<BlockLightUp>().LightUp();
		Debug.Log("Game starting");
		gameStart = true;
    }
}
