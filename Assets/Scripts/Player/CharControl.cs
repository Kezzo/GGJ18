﻿using System.Collections;
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

	private float StartAcc;
	private float StartMaxSpeed;

	void Awake(){
		if(rb == null){
			rb = GetComponent<Rigidbody>();
		}

		StartAcc = characceleration;
		StartMaxSpeed = maxSpeed;

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
			rb.AddForce(charmovement * characceleration * 2, ForceMode.Acceleration);
		}

		rb.drag = characceleration / maxSpeed;

		if(rb.velocity.magnitude > maxSpeed){
			rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
         }

		 if(Input.GetKeyDown(KeyCode.F1)){
			 Impulse();
		 }
		 if(Input.GetKeyDown(KeyCode.F2)){
			 Acceleration();
		 }

	}

	private void Impulse(){
		if(_impulse){
			return;
		} else {
			_impulse = true;
			_acceleration = false;
			characceleration = StartAcc;
			maxSpeed = StartMaxSpeed;
		}
	}

	private void Acceleration(){
		if(_acceleration){
			return;
		} else {
			_acceleration = true;
			_impulse = false;
			characceleration = characceleration + 50;
			maxSpeed = maxSpeed + 2;
		}
	}

}
