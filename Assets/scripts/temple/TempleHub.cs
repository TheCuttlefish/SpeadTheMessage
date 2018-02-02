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
		var pos = transform.position + transform.right;
		textRect.anchoredPosition = WorldToCanvas (canvas, pos, cam);
		//screenPos - canvas.sizeDelta * 0.5f + Vector2.left * 100.0f;

	}

	void UpdateTextValue () {

	}

	Vector2 WorldToCanvas (RectTransform canvas, Vector3 worldPos, Camera camera) {

		var viewport = camera.WorldToViewportPoint (worldPos);

		float x;

		if (viewport.x < 0.1f || viewport.x >.9f) {
			x = -9.0f * canvas.sizeDelta.x;
		} else if (transform.name == "temple") {
			x = canvas.sizeDelta.x * viewport.x * 0.5f;
		} else {
			x = canvas.sizeDelta.x * viewport.x * 0.5f - canvas.sizeDelta.x * 0.5f;
		}

		return new Vector2 (
			x,
			(viewport.y * canvas.sizeDelta.y) - (canvas.sizeDelta.y * 0.5f));
	}

}