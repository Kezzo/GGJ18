using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {
	[SerializeField] Animator fader;

	public void SetVisibility(bool value){
		fader.SetBool("Visible", value);
	}

}
