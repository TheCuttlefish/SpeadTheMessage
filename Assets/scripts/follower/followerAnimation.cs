using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followerAnimation : MonoBehaviour {

	MeshRenderer cubeRenderer;

	public SpriteRenderer shirt;


	void Start () {
		
		cubeRenderer = GetComponent<MeshRenderer> ();

	}

	void Update () {

		shirt.color = cubeRenderer.material.color;

	}
}