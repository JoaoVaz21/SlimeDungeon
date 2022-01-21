using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour , IEnemy{
	private GameObject Player;
	public float speed = 3f;
	float angle;
	public float life = 100;
	public bool hit = false;
	private int cont = 0;
	public float damage = 30;
	// Use this for initialization
	void Start () {
		

			Player = GameObject.FindGameObjectWithTag ("Player");
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Player!=null){
			float Range = Vector2.Distance (transform.position, Player.transform.position);
			if (hit) {
				angle = Mathf.Atan2 (Player.transform.position.y-transform.position.y, Player.transform.position.x - transform.position.x );
				Vector2 velocity = new Vector2 (Mathf.Cos (angle), Mathf.Sin (angle));
				transform.Translate (-velocity * speed * Time.deltaTime*10);
				cont++;
				if (cont >= 3) {
					hit = false;
					cont = 0;
				}
			}else if (Range <= 15f) {
				angle = Mathf.Atan2 (Player.transform.position.y-transform.position.y, Player.transform.position.x - transform.position.x );
				Vector2 velocity = new Vector2 (Mathf.Cos (angle), Mathf.Sin (angle));
				transform.Translate(velocity * speed * Time.deltaTime);
				}
		}else{
			Player = GameObject.FindGameObjectWithTag ("Player");
		}
	}
	public void onHit(float dmg){


		hit = true;
		life -= dmg;
		if (life <= 0) {
			Destroy(gameObject);
		}
	}

	public float DamageDone(){
		return damage;
	}


	public void Hit(){
		hit = true;
	}

}