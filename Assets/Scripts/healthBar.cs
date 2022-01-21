using UnityEngine;
using System.Collections;

public class healthBar : MonoBehaviour {
	public float TotalHp=100;
	public float CurrentHp;
	public float x = 20;

	void Start(){
		CurrentHp = TotalHp;
		transform.localScale = new Vector3 ((CurrentHp / TotalHp)*transform.localScale.x, transform.localScale.y, 1);

	}

	void Update()
	{
		
	}
	public void TakeDamage(float damage)
	{
		CurrentHp -=damage;
		transform.localScale = new Vector3 ((CurrentHp / TotalHp)*transform.localScale.x, transform.localScale.y, 1);
	}
	public void Heal(float hp)
	{
		CurrentHp = hp;
		
		transform.localScale = new Vector3 ((CurrentHp/TotalHp)*x, transform.localScale.y, 1);
	}
}