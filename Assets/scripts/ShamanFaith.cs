using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanFaith : MonoBehaviour {
	// Use this for initialization
	public float faithMeter = 1.0f;
	SpriteRenderer circleArt;
	SphereCollider sphereColl;
	public GameObject[] people;
	void Start () {

		circleArt = transform.Find ("faith_radius").GetComponent<SpriteRenderer> ();
		sphereColl = transform.GetComponent<SphereCollider> ();
		UpdateFaith ();

		if (GetComponent<PlayerLogic> ().playerNum == 0) {
			circleArt.color = new Color (0.2f, 0.2f, 1, 0.3f);
		} else {
			circleArt.color = new Color (1, 0, 0, 0.3f);

		}
	}

	void UpdateFaith () {
		sphereColl.radius = 2.5f * faithMeter;
		circleArt.transform.localScale = new Vector3 (1.9f * faithMeter, 1.9f * faithMeter, 1.0f);
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
		faithMeter = Mathf.Lerp (faithMeter, 1 + (myFollowers * 0.1f), 0.2f);
		UpdateFaith ();
	}
}