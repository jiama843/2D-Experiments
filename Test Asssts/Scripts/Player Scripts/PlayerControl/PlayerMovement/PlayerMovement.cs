using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Stdlib;

public class PlayerMovement {

	private GameObject player;

	private PlayerHorizontal playerHorizontal;
	private PlayerVertical playerVertical;

	// Use this for initialization
	public PlayerMovement (GameObject player, float speed, float initialJumpVelocity) {

		this.player = player;

		playerHorizontal = new PlayerHorizontal (player, speed);
		playerVertical = new PlayerVertical(player, initialJumpVelocity);
	
	}


	//Player Horizontal Methods
	//Called on every update
	public void move(){
	
		playerHorizontal.move ();

		if (Input.GetButtonDown ("Dash")) {

			playerHorizontal.dash (getDirection());

		}
	
	}

	public float getSpeed(){

		return playerHorizontal.getSpeed();

	}

	public bool isLeft(){

		return playerHorizontal.isLeft();

	}

	public bool isRight(){

		return playerHorizontal.isRight();

	}

	public float getDirection(){

		if (isRight ()) {

			return Direction.RIGHT;

		} else {

			return Direction.LEFT;

		}

	}


	//Player Vertical Methods
	public void jump(){

		playerVertical.jump ();

	}

	public void resetJump(){

		playerVertical.resetJump ();

	}

	public float getJumpTime(){

		return playerVertical.getJumpTime ();

	}

	public float getMaxAirTime ()	{

		return playerVertical.getMaxAirTime ();

	}

	public bool IsGrounded(){

		return playerVertical.IsGrounded ();

	}

	public bool CanDoubleJump(){

		return playerVertical.CanDoubleJump ();

	}

	//Player misc movement methods

	public void knockback(float xSpeed, float ySpeed){

		player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (xSpeed, ySpeed);

	}

}
