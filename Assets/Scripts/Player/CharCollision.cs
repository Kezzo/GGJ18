using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCollision : MonoBehaviour {
	private BlockLightUp block;
	public GameController gc;

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Transmitter"){
			block = other.transform.GetComponent<BlockLightUp>();
			if(block.blockActivatable()){
				gc.AddScore();
				block.Activate();
			}
		}
    }
}
