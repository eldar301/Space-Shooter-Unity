using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	[SerializeField] private GameObject backGroundHealthBar;
	[SerializeField] private GameObject foreGroundHealthBar;
	[SerializeField] private bool hideIfFull = true;
	[SerializeField] private bool hideIfZero = true;

	void Start () {
		if (hideIfFull) {
			backGroundHealthBar.SetActive (false);
			foreGroundHealthBar.SetActive (false);
		}
	}

	private void HideHealthBar() {
		backGroundHealthBar.SetActive (false);
		foreGroundHealthBar.SetActive (false);
	}

	private void ShowHealthBar() {
		backGroundHealthBar.SetActive (true);
		foreGroundHealthBar.SetActive (true);
	}

	public void SetHealth(float delta) {
		ShowHealthBar ();
		foreGroundHealthBar.transform.localScale = new Vector3 (delta,
																foreGroundHealthBar.transform.localScale.y,
																foreGroundHealthBar.transform.localScale.z);
		if (hideIfFull && (delta == 1)) {
			HideHealthBar ();
		}
		if (hideIfZero && (delta == 0)) {
			HideHealthBar ();
		}
	}
}
