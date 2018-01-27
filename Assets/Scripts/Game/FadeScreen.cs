using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour {
	[SerializeField] Animator fader;
	void Start () {
		BlackScreen(false);
	}

	public void BlackScreen(bool value){
		fader.SetBool("Black", value);
	}

}
