using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other){
		float dist = Vector3.Distance (transform.position, other.transform.position);

		if (other.name == "Player") {
			if (dist > 2.0f) {
				transform.position = Vector3.Lerp (transform.position, other.transform.position, 0.05f);
			} else {
				transform.position = Vector3.Lerp (transform.position, other.transform.position, 0.001f);
			}
		}

	}
}
