using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement {

	private const float FPS = 60.0f;

	PlayerHorizontal playerHorizontal;
	PlayerVertical playerVertical;

	// Use this for initialization
	public PlayerMovement (GameObject player, float speed, float initialJumpVelocity) {

		playerHorizontal = new PlayerHorizontal (player, speed);
		playerVertical = new PlayerVertical(player, initialJumpVelocity);
	
	}


	//Player Horizontal Methods
	public void move(){
	
		playerHorizontal.move ();
	
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

}
