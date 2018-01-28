using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanBuilding : MonoBehaviour {

	public float conversionSpeed = 0.1f;

	void OnTriggerStay (Collider other) {

		if (other.tag == "Temple") {

			var temple = other.GetComponent<TempleFaith> ();
			temple.AddConversion (conversionSpeed * Time.fixedDeltaTime);

			//if not converted - change religion
			if (!temple.isConverted) {
				temple.religionType = GetComponent<PlayerLogic> ().playerNum + 1;
			}

		}

	}

	void OnTriggerExit (Collider other) {

		if (other.tag == "Temple") {

			var temple = other.GetComponent<TempleFaith> ();
			temple.OnTriggerExit ();

		}

	}

}