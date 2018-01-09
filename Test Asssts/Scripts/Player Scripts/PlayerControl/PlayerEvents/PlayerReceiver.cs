using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReceiver : MonoBehaviour {

	// Use this for initialization
	void start () {

	}

	void OnCollisionEnter2D(Collision2D col){

		PlayerController playerControl = gameObject.GetComponent<PlayerController> ();

		if (col.collider.tag == "Ground") {

			playerControl.resetJumpIfGrounded (col);

		} else if (col.collider.tag == "Weapon") {


		} else if (col.collider.tag == "Projectile") {

			ProjectileProvider projP = col.collider.gameObject.GetComponent<ProjectileProvider> ();
			int attack = projP.getAttack ();

			playerControl.knockback (0.0f, 0.0f);
			//playerControl.destroy ();

			playerControl.getHit (attack);

		} else if (col.collider.tag == "Boss") {

			EnemyProvider enemyP = col.collider.gameObject.GetComponent<EnemyProvider> ();
			// NEEDS TO BE IMPLEMENTED ~ int attack = enemyP.getAttack ();

			playerControl.knockback (0.0f, 0.0f);
			playerControl.getHit (0);

		}

	}

	void OnCollisionStay2D(Collision2D col){



	}

}
