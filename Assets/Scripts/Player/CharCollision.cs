using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCollision : MonoBehaviour {
	private LightUpBlock m_lightUpBlock;

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Transmitter"){
			m_lightUpBlock = other.transform.GetComponent<LightUpBlock>();
			m_lightUpBlock.Activate();
		}
    }
}
