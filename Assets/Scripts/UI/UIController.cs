using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	[SerializeField] private PopUpWindow settingsWindow;
	[SerializeField] private PopUpWindow upgradesWindow;

	void Start () {
		settingsWindow.Close ();	
		upgradesWindow.Close ();
	}

	public void OnSettingsButtonClicked () {
		upgradesWindow.Close ();
		if (settingsWindow.isOpen()) {
			settingsWindow.Close ();
			EventManager.onGameResumed.Invoke ();
		} else {
			EventManager.onGamePaused.Invoke ();
			settingsWindow.Open ();
		}
	}

	public void OnUpgradesButtonClicked () {
		settingsWindow.Close ();
		if (upgradesWindow.isOpen()) {
			upgradesWindow.Close ();
			EventManager.onGameResumed.Invoke ();
		} else {
			EventManager.onGamePaused.Invoke ();
			upgradesWindow.Open ();
		}
	}
}
