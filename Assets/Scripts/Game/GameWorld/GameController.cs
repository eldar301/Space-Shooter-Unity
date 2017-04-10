using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	[SerializeField] private GameObject player;
	[SerializeField] private int startGameWithLevel = 1;

	void Start() {
		EventManager.onAirCraftCrashed.AddListener (this.OnAirCraftCrashed);
		EventManager.onGamePaused.AddListener (this.OnGamePaused);
		EventManager.onGameResumed.AddListener (this.OnGameResumed);
		GetComponent<LevelGenerator> ().LoadLevel (startGameWithLevel);
	}

	void OnDisable() {
		EventManager.onAirCraftCrashed.RemoveListener (this.OnAirCraftCrashed);
		EventManager.onGamePaused.RemoveListener (this.OnGamePaused);
		EventManager.onGameResumed.RemoveListener (this.OnGameResumed);
	}

	public void OnNewLevelLoading() {
		player.GetComponent<AirCraftController> ().RefillHealth ();
	}

	private void OnGamePaused() {
		Time.timeScale = 0;
	}

	private void OnGameResumed() {
		Time.timeScale = 1;
	}

	private void OnAirCraftCrashed(GameObject airCraft) {
		if (player == airCraft) {
			player.SetActive (true);
			player.transform.position = Vector3.zero;
			player.GetComponent<AirCraftController> ().RefillHealth ();
			Debug.Log ("Restart game!");
			GetComponent<LevelGenerator> ().RestartLevel ();
		}
	}

}