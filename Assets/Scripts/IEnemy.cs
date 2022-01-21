using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{

	float DamageDone ();
	void onHit(float dmg);
	void Hit();

}
