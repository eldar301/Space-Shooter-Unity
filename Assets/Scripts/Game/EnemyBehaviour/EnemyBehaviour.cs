using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	[SerializeField] private GameObject bodyGameObject;
	[SerializeField] private GameObject gunOneGameObject;
	[SerializeField] private GameObject gunTwoGameObject;
	[SerializeField] private float fireRate;

	private AirCraftController controller;

	void Start() {
		controller = GetComponent<AirCraftController> ();
		InvokeRepeating ("PerformFire", Random.Range(0.0f, 2.0f), fireRate);
	}

	private void PerformFire() {
		controller.PerformShot ();
	}

	public void InstantiateWithParameters(float bodyHealth, float gunHealth) {
		bodyGameObject.GetComponent<Damageable> ().setBaseHealth (bodyHealth);
		gunOneGameObject.GetComponent<Damageable> ().setBaseHealth (gunHealth);
		gunTwoGameObject.GetComponent<Damageable> ().setBaseHealth (gunHealth);
	}
}
