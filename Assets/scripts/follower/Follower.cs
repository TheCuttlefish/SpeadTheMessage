using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

	Church church = null;

	void Start () {

	}

	Transform player;
	public int religionType = 0;// none, blue, red
	public int freeWill = 0;
	public int faithTime = 150;

	public bool isConverted = false;
	void Update () {

		//turn to white!
		GetComponent<MeshRenderer> ().material.color = Color.Lerp (GetComponent<MeshRenderer> ().material.color, Color.white, 0.01f);

		faithTime--;

		if (faithTime == 0) {
			religionType = 0;
				GetComponent<FollowerFaith> ().myFaithMeter = 1.0f;
				freeWill = 1;
			isConverted = false;

		}

	}

	int timer = 0;
	float xSpeed = 0;
	float ySpeed = 0;

	void FixedUpdate () {

		float t = Time.deltaTime;

		timer++;
		if (timer > 25) {
			xSpeed = Random.Range (-1.0f, 1.0f);
			ySpeed = Random.Range (-1.0f, 1.0f);
			timer = 0;
		}

		if (freeWill == 0) {
			transform.Translate (0.5f * xSpeed * t, 0.5f * ySpeed * t, 0);
		}
		if (freeWill == 1) {
			transform.Translate (3 * xSpeed * t, 3 * ySpeed * t, 0);
		}

		if (player != null) {

			float dist = Vector3.Distance (transform.position, player.transform.position);
			if (dist > 2.5f) {

				if (player.GetComponent<PlayerLogic> ().follow) {
					transform.position = Vector3.Lerp (transform.position, player.transform.position, 3.0f * t);
				} else {
					transform.position = Vector3.Lerp (transform.position, player.transform.position, 0.5f * t);
				}

			} else {
				transform.position = Vector3.Lerp (transform.position, player.transform.position, 0.0001f * t);
			}
		}
	}

	void OnTriggerStay (Collider other) {

		if (other.tag == "Player") {

			//if I'm not reliious and I talk to Shaman
			if(religionType == 0){
				player = other.transform;
				GetConverted ();
				religionType = (other.GetComponent<PlayerLogic> ().playerNum) + 1;//player num + 1
			}

			//if Shaman is of my religion
			if(religionType == (other.GetComponent<PlayerLogic> ().playerNum) + 1 ){
				player = other.transform;
				GetConverted ();
			}

			// my religion is not same as Shamans, attack!
			//add logic here
		}

		if (other.tag == "Temple") {

			if (freeWill == 1) {
				religionType = other.GetComponent<TempleFaith> ().religionType;
				GetConverted ();
			}


			if (freeWill == 0 && religionType == other.GetComponent<TempleFaith> ().religionType) {
				GetConverted ();
			}
		}

		if (other.tag == "Person") {
			
			//if other is non-religions
			if (other.GetComponent<Follower> ().freeWill == 0) {
				GetConverted ();
			}

			//if other is religios
			if (other.GetComponent<Follower> ().freeWill == 1) {
				freeWill = 1;
				GetComponent<MeshRenderer> ().material.color = Color.white;
			}
		}

	}

	void OnTriggerEnter (Collider other) {

		if (church == null && other.tag == "Temple") {
			//1.0 if religious and is same religion ????? then do that?
				church = other.GetComponent<Church> ();
				church.AddFollower ();

		}

	}

	void OnTriggerExit (Collider other) {

		if (other.tag == "Player") {
			
			player = null;
		} else if (other.tag == "Temple") {
			//1.1 same as in Enter??
			if (church == other.GetComponent<Church> ()) {
				church.RemoveFollower ();
				church = null;
			}
		}

	}

	void GetConverted () {

		

		isConverted = true;
		freeWill = 0;
		faithTime = 200;

		if (religionType == 1) {
			GetComponent<MeshRenderer> ().material.color = new Color (0.2f, 0.7f, 1, 1.0f);
		}
		if (religionType == 2) {
			GetComponent<MeshRenderer> ().material.color = new Color (1, 0.6f, 0.0f, 1.0f);
		}
	}
}