using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour {
	
	[SerializeField] private float speed = 100;

	public void MoveAlongX(float delta) {
		Vector3 futurePos = transform.position + new Vector3(delta * speed, 0, 0);
		Vector3 boundedPos = Camera.main.WorldToViewportPoint (futurePos);
		boundedPos.x = Mathf.Clamp01 (boundedPos.x);
		transform.position = Camera.main.ViewportToWorldPoint (boundedPos);
	}
}
