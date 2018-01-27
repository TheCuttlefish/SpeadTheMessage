using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	Transform Player;
	int freeWill = 0;
	int faithTime = 150;
	void Update(){
		
		//turn to white!
		GetComponent<MeshRenderer> ().material.color = Color.Lerp (GetComponent<MeshRenderer> ().material.color, Color.white, 0.01f);


		faithTime--;

		if (faithTime == 0) {
			freeWill = 1;
		}




	}

	

	int timer = 0;
	float xSpeed = 0;
	float ySpeed = 0;

	void FixedUpdate () {

		float t = Time.deltaTime;


		timer++;
		if (timer > 25 ) {
			xSpeed = Random.Range (-1.0f, 1.0f);
			ySpeed = Random.Range (-1.0f, 1.0f);
			timer = 0;
		}


		if (freeWill == 0) {
			transform.Translate (0.5f*xSpeed*t, 0.5f*ySpeed*t, 0);
		}
		if (freeWill == 1) {
			transform.Translate (3*xSpeed*t, 3*ySpeed*t, 0);
		}







		if (Player != null) {
			
			float dist = Vector3.Distance (transform.position, Player.transform.position);
			if (dist > 2.5f) {

				if (Player.GetComponent<PlayerLogic> ().follow) {
					transform.position = Vector3.Lerp (transform.position, Player.transform.position,3.0f*t );
				} else {
					transform.position = Vector3.Lerp (transform.position, Player.transform.position, 1.0f*t);
				}

			} else {
				transform.position = Vector3.Lerp (transform.position, Player.transform.position, 0.0001f*t);
			}
		}
	}



	void OnTriggerStay(Collider other){
		

		if (other.name == "Player") {
			GetConverted ();
			Player = other.transform;
		}

		if (other.tag == "Temple") {
			GetConverted ();
		}

		if (other.tag == "Person") {
			//if other person if religios
			if (other.GetComponent<Follower> ().freeWill == 0) {
				GetConverted();
			}
			//if other is non
			if (other.GetComponent<Follower> ().freeWill == 1) {
				freeWill = 1;
				GetComponent<MeshRenderer> ().material.color = Color.white;
			}
		}

	}


	void OnTriggerExit(Collider other){


		if (other.name == "Player") {
			//GetComponent<MeshRenderer>().material.color = Color.white;
			Player = null;
		}

	}



	void GetConverted(){
		freeWill = 0;
		faithTime = 200;
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}
}
