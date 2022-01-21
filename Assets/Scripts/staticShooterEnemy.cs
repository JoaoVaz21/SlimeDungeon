using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticShooterEnemy : MonoBehaviour , IEnemy {
private GameObject Player;
	public float speed = 0.005f;
	float angle;
	public float alert=50;
	public float life = 100;
	public bool hit = false;
	private int cont = 0;
	public float timer = 0;

	public float damage = 30;


	public GameObject bullet;
	// Use this for initialization
	void Start () {
		

			Player = GameObject.FindGameObjectWithTag ("Player");
		
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(Player!=null){
			
		timer += Time.deltaTime;
			float range = Vector2.Distance (transform.position, Player.transform.position);
			if (range < alert) {
				//Debug.LogError ("range para disparar");
				if (timer > 3.0f) {
					Vector3 pos = new Vector3(transform.position.x +0.5f, transform.position.y+0.5f,transform.position.z);
					Vector3 direction = pos - Player.transform.position;
					//direction.Normalize ();
					GameObject bulletClone;
					bulletClone = Instantiate (bullet, pos, transform.rotation) as GameObject;
					bulletClone.GetComponent<Bullet> ().velocity = direction * -0.02f;
					//Debug.LogError ("disparou");
					timer = 0;


				}

			}
			
		}else{
			Player = GameObject.FindGameObjectWithTag ("Player");
		}
	}
	public void onHit(float dmg){
		
			Destroy(gameObject);
		
	}

	public float DamageDone(){
		return 0;


	}
	public void Hit(){
		hit = true;
	}
}
