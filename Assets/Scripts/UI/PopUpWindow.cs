using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpWindow : MonoBehaviour {
	
	public void Open() {
		gameObject.SetActive (true);
	}

	public void Close() {
		gameObject.SetActive (false);
	}

	public bool isOpen() {
		return gameObject.activeSelf;
	}

}
