using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	[SerializeField] private int enemyCountMultiplier;
	[SerializeField] private float bodyHealthEnemyMultiplier;
	[SerializeField] private float gunHealthEnemyMultiplier;

	[SerializeField] private int createBoosEachLevel;
	[SerializeField] private float bodyHealthBossMultiplier;
	[SerializeField] private float gunHealthBossMultiplier;

	private int currentLevel;
	private EnemiesHandler enemiesHandler;

	void Awake() {
		enemiesHandler = GetComponent<EnemiesHandler> ();
	}
		
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			++currentLevel;
			LoadLevel ();
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			--currentLevel;
			LoadLevel ();
		}
	}

	private void LoadLevel() {
		GetComponent<GameController> ().OnNewLevelLoading ();
		enemiesHandler.ClearEnemies ();
		if (currentLevel % createBoosEachLevel == 0) {
			enemiesHandler.CreateNewEnemies (EnemyType.Boss, 1, currentLevel * bodyHealthBossMultiplier, currentLevel * gunHealthBossMultiplier);
		} else {
			enemiesHandler.CreateNewEnemies (EnemyType.Simple, currentLevel % createBoosEachLevel, currentLevel * bodyHealthEnemyMultiplier, currentLevel * gunHealthEnemyMultiplier);
		}
	}

	public void LoadLevel(int level) {
		currentLevel = level;
		LoadLevel ();
	}

	public void RestartLevel() {
		LoadLevel ();
	}

	public void LoadNextLevel() {
		Debug.Log ("LoadNextLevel");
		++currentLevel;
		LoadLevel ();
	}
}
