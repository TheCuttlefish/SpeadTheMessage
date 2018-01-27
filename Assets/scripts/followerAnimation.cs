using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followerAnimation : MonoBehaviour {

	Follower follower;

	MeshRenderer cubeRenderer;

	public SpriteRenderer converted;
	public SpriteRenderer notConverted;

	void Start () {

		follower = GetComponent<Follower> ();
		cubeRenderer = GetComponent<MeshRenderer> ();

	}

	void Update () {

		var color = converted.color;
		color.a = 1.0f - cubeRenderer.material.color.r;
		converted.color = color;

	}
}