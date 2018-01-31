using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempleHub : MonoBehaviour {

	public Text text;
	public Camera cam;
	public Canvas canvas;

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

	Vector2 WorldToCanvas (Canvas canvas, Vector3 worldPos, Camera camera) {

		var viewport_position = camera.WorldToViewportPoint (worldPos);
		var canvas_rect = canvas.GetComponent<RectTransform> ();

		return new Vector2 ((viewport_position.x * canvas_rect.sizeDelta.x) - (canvas_rect.sizeDelta.x * 0.5f),
			(viewport_position.y * canvas_rect.sizeDelta.y) - (canvas_rect.sizeDelta.y * 0.5f));
	}

}