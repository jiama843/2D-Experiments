using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//public bool isGrounded;
	//public bool canDoubleJump;

	private const float RIGHT = 1.0f;
	private const float LEFT = -1.0f;

	private GameObject player;
	private GameObject weapon;

	private PlayerMovement playerMove;

	private PlayerShoot playerShoot;

	private PlayerStats playerStats;

	private float speed = 1.0f;

	public float initialJumpVelocity = 5.0f;

	// Use this for initialization
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

			playerShoot.shoot (RIGHT);

		} else {

			playerShoot.shoot (LEFT);

		}

	}

	public void resetJumpIfGrounded(Collision2D groundObj){

		playerMove.resetJump ();
		//Debug.Log ("Detected ground object: " + groundObj);

	}

	public void destroy(){



	}

}
