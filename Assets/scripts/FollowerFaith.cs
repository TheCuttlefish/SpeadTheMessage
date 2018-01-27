using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerFaith : MonoBehaviour {

	public float myFaithMeter = 1.0f;
	SpriteRenderer circleArt;
	SphereCollider sphereColl;
	public GameObject[] people;
	// Use this for initialization
	void Start () {
		circleArt = transform.Find ("faith_radius").GetComponent<SpriteRenderer> ();
		sphereColl = transform.GetComponent<SphereCollider> ();
	}
	void UpdateFaith () {
		sphereColl.radius = 1.25f * myFaithMeter;
		circleArt.transform.localScale = new Vector3 (1.0f * myFaithMeter, 1.0f * myFaithMeter, 1.0f);
	}
	// Update is called once per frame
	void Update () {

		people = GameObject.FindGameObjectsWithTag ("Person");
		float myFollowers = 0;
		for (int i = 0; i < people.Length; i++) {
			if (people[i].GetComponent<Follower> ().isConverted) {
				//folloers limit
				if (myFollowers < 5) {
					myFollowers++;
				}
			}

		}
		//lerp faith

		if (GetComponent<Follower> ().isConverted) {
			myFaithMeter = Mathf.Lerp (myFaithMeter, 1 + (myFollowers * 0.1f), 0.2f);

		} else {
			myFaithMeter = Mathf.Lerp (myFaithMeter, 1 , 0.2f);
		}

		UpdateFaith ();
	}
}