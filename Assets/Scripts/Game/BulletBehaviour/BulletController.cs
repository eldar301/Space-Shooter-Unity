using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BulletController : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private float lifeTime;
	[SerializeField] private float damage;

	void Start () {
		Destroy (this.gameObject, lifeTime);
	}

	void Update () {
		transform.Translate (0, speed * Time.deltaTime, 0);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Damageable target = collider.GetComponent<Damageable> ();
		if (target != null) {
			target.Hit (damage);
		}
		Destroy (this.gameObject);
	}
}
