using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCollision : MonoBehaviour {
	private LightUpBlock block;
	public GameController gc;

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Transmitter"){
			block = other.transform.GetComponent<LightUpBlock>();
			if(block.blockActivatable()){
				gc.AddScore();
			}
			block.Activate();
		}
    }
}
