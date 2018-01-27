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
		transform.position = Vector3.Lerp (transform.position,new Vector3(player.transform.position.x, player.transform.position.y, -10.0f), speed);
	}
}
