using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Tutorial1 : MonoBehaviour {
	public Text goal;
	public Text complete;
	bool stageComplete = false;
	int timer = 300;
	// Use this for initialization
	void Start () {

	}
	public GameObject[] people;
	// Update is called once per frame
	void Update () {
		people = GameObject.FindGameObjectsWithTag ("Person");
		float myFollowers = 0;
		for (int i = 0; i < people.Length; i++) {
			if (people[i].GetComponent<Follower> ().isConverted) {
				//folloers limit
				myFollowers++;
			}

		}

		goal.text = myFollowers + "/10";

		if (myFollowers == 10) {
			stageComplete = true;
			complete.text = "COMPLETE!";
		}

		if (stageComplete) {
			timer--;
			if (timer < 0) {
				SceneManager.LoadScene (2);
			}
		}

	}
}