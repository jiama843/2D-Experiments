using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReceiver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter2D(Collision2D col){

		EnemyController enemyControl = gameObject.GetComponent<EnemyController> ();

		if (col.gameObject.tag == "Projectile") {

			ProjectileProvider projectileProvider = col.gameObject.GetComponent<ProjectileProvider> ();

			int attack = projectileProvider.getAttack ();
			enemyControl.takeDamage (attack);

		}

	}

}
