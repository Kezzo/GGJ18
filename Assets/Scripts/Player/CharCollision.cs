using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCollision : MonoBehaviour {
	private BlockLightUp block;

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Transmitter"){
			block = other.transform.GetComponent<BlockLightUp>();
			block.LightUp();
		}
    }
}
