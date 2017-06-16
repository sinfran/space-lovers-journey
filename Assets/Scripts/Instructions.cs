using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

		if (KiteDevice.s != KiteDevice.State.INACTIVE) {
			if (GetComponent<CanvasGroup> ().alpha > 0) {
				GetComponent<CanvasGroup> ().alpha -= 0.006f;
			}
		}
	}
}
