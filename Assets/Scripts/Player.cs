using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
 
   public float moveSpeed = 6;

 


    Vector3 velocity;

    Controller2D controller;
	public GameObject bar;
	public float life = 100;
	public float lifeMax = 100;
    void Start()
    {
        controller = GetComponent<Controller2D>();
		bar = GameObject.FindGameObjectWithTag ("PlayerBar");
    }

    void Update()
    {
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		velocity = new Vector3 (x, y,0);

        controller.Move(velocity * Time.deltaTime*moveSpeed);
	
}
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Enemy") {
			float damage = col.gameObject.GetComponent<IEnemy> ().DamageDone();
			col.gameObject.GetComponent<IEnemy> ().Hit();
			life -= damage;
			bar.GetComponent<healthBar> ().TakeDamage (damage);
			if (life < 0f) {
				Destroy (gameObject);

			}
		}
		if (col.gameObject.tag == "Bullet") {
			float damage = col.gameObject.GetComponent<Bullet> ().damage;
			life -= damage;
			bar.GetComponent<healthBar> ().TakeDamage (damage);
			if (life < 0f) {
				Destroy (gameObject);

			
			}

		}
		if(col.gameObject.tag == "Respawn") {
				float heal = col.gameObject.GetComponent<HealthObject> ().health;
				float plusHealth = life + heal;
				if (plusHealth > lifeMax) {
					life = lifeMax;
				} else {
					life = plusHealth;
				}
				bar.GetComponent<healthBar> ().Heal(life);
				Destroy (col.gameObject);
	}
}
}

