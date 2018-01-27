using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCollision : MonoBehaviour {
<<<<<<< HEAD
	private BlockLightUp block;
	public GameController gc;

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Transmitter"){
			block = other.transform.GetComponent<BlockLightUp>();
			if(block.blockActivatable()){
				gc.AddScore();
				block.Activate();
			}
=======
	private LightUpBlock m_lightUpBlock;

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Transmitter"){
			m_lightUpBlock = other.transform.GetComponent<LightUpBlock>();
			m_lightUpBlock.Activate();
>>>>>>> 520c8f89c90b75cf4fef8308ae08ce32e828b889
		}
    }
}
