using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
			if (KiteDevice.s == KiteDevice.State.BOARD_KITE) {
				GetComponent<CanvasGroup> ().alpha -= 0.01f;
			}

	}
}
	