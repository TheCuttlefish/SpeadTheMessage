using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Church : MonoBehaviour {

	MeshRenderer meshRenderer;

	public SpriteRenderer church;
	public SpriteRenderer building;

	public bool isConverted {
		get { return 1.0 == conversionAmount; }
	}

	public float _followers = 0;

	public float MaxFollowers = 10;

	public float conversionAmount = 0;

	float followers {
		get { return _followers; }
		set {
			UpdateView ();
			_followers = value;
		}
	}

	void Start () {

		meshRenderer = GetComponent<MeshRenderer> ();
		UpdateView();
	}


	public void AddFollower () {
		++followers;
	}

	public void RemoveFollower () {
		--followers;
	}

	void UpdateView () {
		var amount = Mathf.Min (1.0f, _followers / MaxFollowers);
		var color = church.material.color;

		color.a = 1.0f - amount;

		church.material.color = color;
	}

}