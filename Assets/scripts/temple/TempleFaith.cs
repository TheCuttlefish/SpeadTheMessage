using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TempleFaith : MonoBehaviour {

	public SpriteRenderer temple;
	public SpriteRenderer building;
	public SpriteRenderer converting;
	public SpriteRenderer symbol;
	public SpriteRenderer symbolGlow;

	[Range (0.0f, 1.0f)]
	public float conversionAmount = 0;

	bool isConversionDone = false;

	public bool isConverted {
		get { return 1.0 == conversionAmount; }
	}

	PlayableDirector playableDirector;

	void Start () {

		playableDirector = GetComponent<PlayableDirector>();

		if (conversionAmount == 1.0f) {
			isConversionDone = true;
			symbol.enabled = true;
			symbolGlow.enabled = false;
		}
		UpdateView ();
	}

	void UpdateView () {

		if (conversionAmount == 1.0f) {

			if (!isConversionDone) {

				isConversionDone = true;
				symbol.enabled = true;
				symbolGlow.enabled = true;

				SpriteAlpha (symbol, 1.0f);
				SpriteAlpha (converting, 1.0f);

				playableDirector.Play ();

				//symbol.GetComponent<Animator

			}

		} else {

			isConversionDone = false;
			symbol.enabled = false;
			symbolGlow.enabled = false;

			SpriteAlpha (symbol, 0.0f);
			SpriteAlpha (converting, conversionAmount);

		}

	}

	public void AddConversion (float amount) {

		conversionAmount = Mathf.Min (1.0f, conversionAmount + amount);
		UpdateView ();

	}

	void SpriteAlpha (SpriteRenderer sprite, float amount) {
		var color = sprite.material.color;
		color.a = amount;
		sprite.material.color = color;
	}

}