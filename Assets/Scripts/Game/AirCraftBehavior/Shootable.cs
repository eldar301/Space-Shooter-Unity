using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour {

	[SerializeField] private GameObject firePoint;
	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private float shootingRate = 1;

	private float timeElapsedSinceLastShot = 0;

	void FixedUpdate() {
		timeElapsedSinceLastShot += Time.deltaTime;
	}

	public void PerformShot() {
		if (timeElapsedSinceLastShot >= shootingRate) {
			GameObject bullet = Instantiate (bulletPrefab) as GameObject;
			bullet.transform.position = firePoint.transform.position;
			bullet.transform.rotation = firePoint.transform.rotation;
			timeElapsedSinceLastShot = 0;
		}
	}
}
