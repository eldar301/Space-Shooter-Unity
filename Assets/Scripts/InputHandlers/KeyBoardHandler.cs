using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardHandler : MonoBehaviour {

	private AirCraftController controller;

	void Start () {
		controller = GetComponent<AirCraftController> ();
	}

	void Update () {
		float inputDelta = Input.GetAxis ("Horizontal");
		controller.MoveAlongX (inputDelta);
		if (Input.GetKey (KeyCode.Space)) {
			controller.PerformShot ();
		}
	}
}
