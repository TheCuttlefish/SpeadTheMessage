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
			circleArt.color = new Color (0.0f, 0.5f, 1, 0.7f);
		} else {
			circleArt.color =  new Color (1, 0.1f, 0.4f, 0.7f);

		}
	}

	void UpdateFaith () {
		sphereColl.radius = 2.5f * faithMeter;
		circleArt.transform.localScale = new Vector3 (0.6f * faithMeter, 0.6f * faithMeter, 1.0f);
	}

	// Update is called once per frame

	void Update () {

		people = GameObject.FindGameObjectsWithTag ("Person");
		float myFollowers = 0;
		for (int i = 0; i < people.Length; i++) {
			if (people[i].GetComponent<Follower> ().isConverted &&
				people[i].GetComponent<Follower>().religionType == GetComponent<PlayerLogic>().playerNum + 1) {
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