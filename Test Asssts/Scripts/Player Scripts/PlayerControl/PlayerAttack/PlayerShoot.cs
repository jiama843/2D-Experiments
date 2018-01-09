using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot {

	private GameObject projectile;

	private Rigidbody2D projectileRBody;
	private Rigidbody2D playerRBody;

	private Transform playerTransform;

	public PlayerShoot(GameObject player, GameObject projectile){

		this.projectile = projectile;
		this.projectileRBody = projectile.GetComponent<Rigidbody2D> ();
		this.playerRBody = player.GetComponent<Rigidbody2D>();
		this.playerTransform = player.GetComponent<Transform>();

	}

	public void shoot(float direction) {

		if (Input.GetButtonDown ("Fire1")) {
			
			float shootingSpeed = projectile.GetComponent<ProjectileProvider> ().getShootingSpeed ();

			GameObject projectileInstance = 
				GameObject.Instantiate (projectile, playerTransform.position, playerTransform.rotation)
				as GameObject;

			Rigidbody2D projectileInstanceRBody = projectileInstance.GetComponent<Rigidbody2D> ();

			//Physics2D.IgnoreCollision (projectileInstance.GetComponent<Collider2D> (), playerRBody.GetComponent<Collider2D> ());
			projectileInstanceRBody.velocity = new Vector2 (shootingSpeed * direction, 0);

		}

	}

}
