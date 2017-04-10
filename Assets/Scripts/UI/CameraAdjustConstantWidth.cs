using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjustConstantWidth : MonoBehaviour {

	[SerializeField] private float constantWidth;

	private Camera myCamera;

	void Awake () {
		myCamera = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
//		float height = 2f * myCamera.orthographicSize;
//		float width = height * myCamera.aspect;
//		Debug.Log (width + " " + height);
		myCamera.orthographicSize = constantWidth / myCamera.aspect / 2;
	}
}
