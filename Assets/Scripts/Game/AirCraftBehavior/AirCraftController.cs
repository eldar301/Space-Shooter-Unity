using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCraftController : MonoBehaviour {

	[SerializeField] private GameObject bodyGameObject;
	[SerializeField] private GameObject gunOneGameObject;
	[SerializeField] private GameObject gunTwoGameObject;

	private Movable moveController;
	private Shootable gunOne;
	private Shootable gunTwo;

	void Start () {
		moveController = this.GetComponent<Movable> ();
		gunOne = gunOneGameObject.GetComponent<Shootable> ();
		gunTwo = gunTwoGameObject.GetComponent<Shootable> ();
	}

	void Update() {
		if (!IsAlive ()) {
			this.gameObject.SetActive (false);
			EventManager.onAirCraftCrashed.Invoke (this.gameObject);
		}
	}

	public void PerformShot() {
		if (gunOneGameObject.activeSelf) {
			gunOne.PerformShot ();
		}
		if (gunTwoGameObject.activeSelf) {
			gunTwo.PerformShot ();
		}
	}

	public void MoveAlongX(float delta) {
		moveController.MoveAlongX (Time.deltaTime * delta);
	}

	public void RefillHealth() {
		bodyGameObject.SetActive (true);
		bodyGameObject.GetComponent<Damageable> ().RefillHealth ();
		gunOneGameObject.SetActive (true);
		gunOneGameObject.GetComponent<Damageable> ().RefillHealth ();
		gunTwoGameObject.SetActive (true);
		gunTwoGameObject.GetComponent<Damageable> ().RefillHealth ();
	}

	public bool IsAlive() {
		return bodyGameObject.activeSelf && (gunOneGameObject.activeSelf || gunTwoGameObject.activeSelf);
	}
}
