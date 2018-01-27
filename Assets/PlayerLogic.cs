using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer> ().material.color = Color.blue;
	}

	public bool follow;

	
	// Update is called once per frame
	void FixedUpdate () {

		Movement ();

	}


	void Movement(){
		
		float InputH = Input.GetAxis ( "Horizontal" );
		float InputV = Input.GetAxis ( "Vertical" );
		float t = Time.deltaTime;
		float walkingSpeed = 5.0f;
		float runningSpeed = 11.0f;

		if(Input.GetKey( KeyCode.LeftShift )){
			//walking
			transform.Translate ( InputH * walkingSpeed * t, InputV * walkingSpeed * t , 0);
			follow = true;
		}else {
			//running
			transform.Translate ( InputH * runningSpeed * t, InputV * runningSpeed * t,0);
			follow = false;
		}
	}






}
