using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationHandler : MonoBehaviour {

	private AirCraftController controller;

	void Start () {
		controller = GetComponent<AirCraftController> ();
	}

	void Update () {
		float inputDelta = Input.acceleration.x;
		controller.MoveAlongX (inputDelta);
		if (Input.touchCount != 0) {
			controller.PerformShot ();
		}
	}
}
