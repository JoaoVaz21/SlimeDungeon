using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float damage = 30;
	public Vector3 velocity = new Vector3 (0, 0, 0);

	void FixedUpdate () {

		transform.Translate(velocity);
	}
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Wall" || col.gameObject.tag == "weapon" ) {
			Destroy (gameObject);
		}
	}


}
