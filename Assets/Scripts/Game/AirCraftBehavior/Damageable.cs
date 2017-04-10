using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour {

	[SerializeField] private GameObject healthBarGameObject;
	[SerializeField] private float baseHealth = 100;
	[SerializeField] private float damageResistant = 0.99f;

	private float health;

	public void Start() {
		health = baseHealth;
	}

	public void setBaseHealth(float health) {
		this.baseHealth = health;
	}

	public void RefillHealth() {
		health = baseHealth;
		SetHealthBar (1);
	}

	public void Hit(float damage) {
		Debug.Log ("Hp before hit = " + health);
		health -= damage * damageResistant;
		if (health <= 0) {
			SetHealthBar (0);
			this.gameObject.SetActive (false);
			return;
		}
		SetHealthBar (health / baseHealth);
	}
		
	private void SetHealthBar(float delta) {
		healthBarGameObject.GetComponent<HealthBar> ().SetHealth (delta);
	}
}
