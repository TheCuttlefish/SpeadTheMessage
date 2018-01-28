using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public Transform player;
	public float speed = 1.0f;
	// Update is called once per frame
	void FixedUpdate () {

		// A: Floor under Cam
		// B: PLayer
		// C: Camera

		// var angleA = 90.0f;
		// var angleC = 180.0f - Vector3.Angle( -player.forward, transform.forward );
		// print(angleC);
		// var angleB = 180.0f - angleA - angleC;

		// var distB = transform.position.z;
		// var distA = - (distB / Mathf.Sin( angleB ) ) * Mathf.Sign( angleA );

		var distA = 10.0f;

		var newPos = player.position - distA * transform.forward;
		transform.position = Vector3.Lerp ( transform.position, newPos , speed );
	}
}
