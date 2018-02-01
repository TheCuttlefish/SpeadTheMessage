using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempleHub : MonoBehaviour {

	public Text text;
	public Camera cam;
	public RectTransform canvas;

	Church church;
	RectTransform textRect;

	void Start () {

		church = GetComponent<Church> ();
		textRect = text.GetComponent<RectTransform> ();

	}

	void Update () {

		UpdateTextPos ();
		UpdateTextValue ();

	}

	void UpdateTextPos () {

		// Vector2 screenPos = cam.WorldToScreenPoint (transform.position);
		textRect.anchoredPosition = WorldToCanvas( canvas, transform.position, cam );
		//screenPos - canvas.sizeDelta * 0.5f + Vector2.left * 100.0f;

	}

	void UpdateTextValue () {

	}

	Vector2 WorldToCanvas (RectTransform canvas, Vector3 worldPos, Camera camera) {

		var viewportStartX = 0.0f;
		var viewportEndX = 1.0f;
		var canvasStartX = 0.5f;
		var canvasEndX = 1.0f;

		var viewportRange = viewportEndX - viewportStartX;
		var canvasRange = canvasEndX - canvasStartX;

		// TODO: Implement this https://developer.leapmotion.com/documentation/csharp/devguide/Leap_Coordinate_Mapping.html

		// var canvasX = ( )

		var viewport = camera.WorldToViewportPoint (worldPos);

		return new Vector2 ((viewport.x * canvas.sizeDelta.x) - (canvas.sizeDelta.x * .5f),
			(viewport.y * canvas.sizeDelta.y) - (canvas.sizeDelta.y * 0.5f));
	}

}