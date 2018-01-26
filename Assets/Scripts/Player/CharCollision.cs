using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCollision : MonoBehaviour {

	[HideInInspector]
	[SerializeField] bool canUse;

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Box"){
			canUse = true;
		}
    }

	void OnTriggerExit(Collider other){
		if(other.tag == "Box"){
			canUse = false;
		}
	}
}
