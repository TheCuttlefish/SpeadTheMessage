using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Tutorial2 : MonoBehaviour {
	public Text goal;
	public Text complete;
	bool stageComplete = false;
	int timer = 100;
	// Use this for initialization
	void Start () {

	}
	public GameObject[] temples;
	// Update is called once per frame
	void Update () {
		temples = GameObject.FindGameObjectsWithTag ("Temple");
		float myTemps = 0;
		for (int i = 0; i < temples.Length; i++) {
			if (temples[i].GetComponent<TempleFaith> ().isConverted) {
				//folloers limit
				myTemps++;
			}

		}

		goal.text = myTemps + "/3";

		if (myTemps == 3) {
			stageComplete = true;
			complete.text = "COMPLETE!";
		}

		if (stageComplete) {
			timer--;
			if (timer < 0) {
				SceneManager.LoadScene (3);
			}
		}

	}
}