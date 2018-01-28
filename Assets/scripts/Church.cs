using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Church : MonoBehaviour {

	public float _followers = 0;

	public float MaxFollowers = 10;

	float followers {
		get { return _followers; }
		set {
			// UpdateView ();
			_followers = value;
		}
	}

	public void AddFollower () {
		++followers;
	}

	public void RemoveFollower () {
		--followers;
	}

}