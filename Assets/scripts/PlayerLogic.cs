using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour {
	public int playerNum = 0;
	void Start () {
		GetComponent<MeshRenderer> ().material.color = Color.blue;
	}

	public bool follow;

	void FixedUpdate () {

		Movement ();

	}

	void Movement () {

		float InputH = Input.GetAxis ("Horizontal" + playerNum);
		float InputV = Input.GetAxis ("Vertical" + playerNum);
		float t = Time.deltaTime;
		float walkingSpeed = 5.0f;
		float runningSpeed = 11.0f;



		if (Input.GetButton("Fire1_" +  playerNum)) {
			//if (Input.GetKey (KeyCode.LeftShift)) {
			//walking
			transform.Translate (InputH * walkingSpeed * t, InputV * walkingSpeed * t, 0);
			follow = true;
		} else {
			//running
			transform.Translate (InputH * runningSpeed * t, InputV * runningSpeed * t, 0);
			follow = false;
		}
	}

}