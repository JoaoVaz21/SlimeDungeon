using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {
	public float speed=5000;
	public float power = 50;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float angle;
	

		 if (Input.GetAxis ("weaponhor") > 0) {
			angle = Mathf.Atan2 (transform.position.y -1, transform.position.x - 0);
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			Vector3 rotation = new Vector3 (0,0,-Mathf.Sin (angle));
			transform.RotateAround (player.transform.position, rotation, speed*Time.deltaTime);


		} else if (Input.GetAxis ("weaponhor") < 0) {
			angle = Mathf.Atan2 (transform.position.y -1, transform.position.x - 0);
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			Vector3 rotation = new Vector3 (0,0,Mathf.Sin (angle));
			transform.RotateAround (player.transform.position, rotation, speed*Time.deltaTime);


		}
	}
	void OnCollisionEnter2D (Collision2D col) {
		if(col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<IEnemy> ().onHit (power);
		}


	}
}
