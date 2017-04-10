using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBoundsController : MonoBehaviour {

	[SerializeField] private float width;
	[SerializeField] private float height;

	public float GetHeight() {
		return height;
	}

	public float GetWidth() {
		return width;
	}
}
