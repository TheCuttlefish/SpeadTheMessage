using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	public void PlayGame () {
		print ("play");
		SceneManager.LoadScene (1);
	}

	public void QuitGame () {
		print ("quit!!");
		Application.Quit ();
	}
	// Update is called once per frame
	void Update () {

	}
}