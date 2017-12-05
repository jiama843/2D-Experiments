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


		} else if (col.collider.tag == "Boss") {


		}

	}

	void OnCollisionStay2D(Collision2D col){



	}

}
