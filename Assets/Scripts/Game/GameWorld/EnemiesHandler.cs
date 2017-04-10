using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType {Simple, Boss};

public class EnemiesHandler : MonoBehaviour {

	[SerializeField] GameObject airCraftPrefab;
	[SerializeField] float simpleEnemySizeMultiplier;
	[SerializeField] float bossEnemySizeMultiplier;

	private List<GameObject> enemies;

	void Awake() {
		EventManager.onAirCraftCrashed.AddListener (this.OnAirCraftCrashed);
		enemies = new List<GameObject> ();
	}

	void OnDisable() {
		EventManager.onAirCraftCrashed.RemoveListener (this.OnAirCraftCrashed);
	}

	public void CreateNewEnemies(EnemyType type, int enemiesCount, float bodyHealth, float gunHealth) {
		float dispositionRate = 1.0f / enemiesCount;
		float sizeMultiplier = (type == EnemyType.Simple) ? simpleEnemySizeMultiplier : bossEnemySizeMultiplier;
		for (int idx = 0; idx < enemiesCount; ++idx) {
			GameObject enemy = Instantiate (airCraftPrefab) as GameObject;
			enemy.GetComponent<EnemyBehaviour> ().InstantiateWithParameters (bodyHealth, gunHealth);
			enemy.transform.localScale = Vector3.one * sizeMultiplier;
			Vector3 onScreenPos = Camera.main.WorldToViewportPoint (transform.position);
			enemy.transform.position = Camera.main.ViewportToWorldPoint (new Vector3(dispositionRate * (idx + 0.5f), onScreenPos.y, onScreenPos.z));
			enemies.Add (enemy);
		}
	}

	public void ClearEnemies() {
		foreach (GameObject enemy in enemies) {
			Destroy (enemy);
		}
		enemies.Clear ();
	}

	private void OnAirCraftCrashed(GameObject airCraft) {
		if (airCraft.tag == "Enemy") {
			enemies.Remove (airCraft);
			Destroy (airCraft);
			if (enemies.Count == 0) {
				GetComponent<LevelGenerator> ().LoadNextLevel ();
			}
		}
	}
}