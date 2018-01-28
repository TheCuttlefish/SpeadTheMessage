using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Church : MonoBehaviour {

	public float timer = 0;

	public float timerDuration = 5.0f;

	TempleFaith faith;

	List<Follower> followersList = new List<Follower> ();

	List<Follower> peopleIn = new List<Follower> ();

	void Start () {
		faith = GetComponent<TempleFaith> ();

		faith.onReligionChange.AddListener (() => {

			followersList.Clear ();
			timer = 1.0f;

		});

	}

	void CheckPeopleAlreadyIn () {
		foreach (var person in peopleIn) {

			if (isBeliever (person)) {
				followersList.Add (person);
			}

		}
	}

	bool isBeliever (Follower person) {
		return (person.religionType == faith.religionType && faith.religionType != 0);
	}

	public void OnFollowerEnter (Follower person) {

		peopleIn.Add (person);

		if (isBeliever (person)) {
			followersList.Add (person);
		}
	}

	public void OnFollowerLeave (Follower person) {

		peopleIn.Remove (person);

		if (followersList.Contains (person)) {

			followersList.Remove (person);

			if (followersList.Count == 0) {
				timer = 1.0f;
			}

		}

	}

	void Update () {

		if (followersList.Count == 0 && timer > 0.0f) {

			var timerStep = (1 / timerDuration) * Time.deltaTime;

			if (timer - timerStep <= 0.0f) {

				timer = 0.0f;

				faith.BecomeNeutral ();
				print ("BecomeNeutral");

			}

		}

	}
}