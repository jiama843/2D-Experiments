using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileReceiver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag != "Projectile") {
			
			ProjectileController projectileController = gameObject.GetComponent<ProjectileController> ();

			projectileController.destroyByCollision ();

		}

	}

}
