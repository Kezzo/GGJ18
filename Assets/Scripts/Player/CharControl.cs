using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour {

	[Header("Character movement")]
	[SerializeField] float characceleration;
	[SerializeField] float maxSpeed;

	[Header("Rigidbody movement type")]
	[SerializeField] bool _impulse;
	[SerializeField] bool _acceleration;
	private Rigidbody rb;

	void Awake(){
		if(rb == null){
			rb = GetComponent<Rigidbody>();
		}

		if(_impulse){
			_acceleration = false;
		} else if (_acceleration){
			_impulse = false;
		} else {
			_impulse = true;
		}
	}
	
	void Update () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 charmovement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		if(_impulse){
			rb.AddForce(charmovement * maxSpeed, ForceMode.Impulse);
		} else if (_acceleration){
			rb.AddForce(charmovement * characceleration, ForceMode.Acceleration);
		}

		rb.drag = characceleration / maxSpeed;

		if(rb.velocity.magnitude > maxSpeed){
			rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
         }

		Debug.Log(rb.velocity.magnitude);

	}

}
