using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Stdlib;

public class PlayerController : MonoBehaviour {

	private GameObject player;
	private GameObject weapon;

	private PlayerMovement playerMove;

	private PlayerShoot playerShoot;

	private PlayerStats playerStats;

	private float speed = 1.0f;

	public float initialJumpVelocity = 5.0f;

	// Use this for initialization
	void awake(){

		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;

	}

	void Start () {

		player = gameObject;

		playerStats = player.GetComponent<PlayerStats> ();
		weapon = playerStats.getWeapon ();
		speed = playerStats.getSpeed ();

		playerMove = new PlayerMovement (player, speed, initialJumpVelocity);
		playerShoot = new PlayerShoot (player, weapon);

	}

	void fixedUpdate () {

		weapon = playerStats.getWeapon ();
		speed = playerStats.getSpeed ();

	}

	// Update is called once per frame
	void Update () {

		//Debugging calls
		//isGrounded = playerMove.IsGrounded ();
		//canDoubleJump = playerMove.CanDoubleJump ();
		//Debug.Log("Time of Jump: "+playerMove.getJumpTime ()+" / "+playerMove.getMaxAirTime());

		move ();
		jump ();
		shoot ();

	}

	void move(){

		playerMove.move ();

	}

	void jump(){

		playerMove.jump ();

	}

	void shoot(){

		if (playerMove.isRight()) {

			playerShoot.shoot (Direction.RIGHT);

		} else {

			playerShoot.shoot (Direction.LEFT);

		}

	}

	public void resetJumpIfGrounded(Collision2D groundObj){

		playerMove.resetJump ();
		//Debug.Log ("Detected ground object: " + groundObj);

	}

	public void getHit(int attack){
	
		PlayerInvulnerability playerInv = player.GetComponent<PlayerInvulnerability> ();
		playerInv.setInvincible (1.0f);
	
		takeDamage (attack);

	}

	public void knockback(float xSpeed, float ySpeed){

		float direction = playerMove.getDirection ();
		playerMove.knockback (xSpeed * direction, ySpeed);

	}

	public void takeDamage(int attack){

		//Take damage script

	}

	public void destroy(){

		Destroy (player);

	}

}
