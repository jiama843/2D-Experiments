using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVertical {

	private Transform playerTransform;

	private Rigidbody2D playerRBody;

	private const float FPS = 60.0f;
	private const float GRAVITY = -9.8f;

	private float time = 0.0f;
	private float maxAirTime = 0.2f * FPS;
	private float initialJumpVelocity;

	private float finalYVelocity = 0.0f;
	private float currYVelocity = 0.0f;

	private bool isGrounded = true;
	private bool canDoubleJump = false;

	public PlayerVertical(GameObject player, float initialJumpVelocity){

		this.playerTransform = player.GetComponent<Transform> ();
		this.playerRBody = player.GetComponent<Rigidbody2D> ();
		this.initialJumpVelocity = initialJumpVelocity;

	}

	public void setNewCurrYVelocity(float finalYVelocity, float initialYVelocity, float currTime, float maxTime){

		float t = maxTime - currTime;

		float changeInHeight = ((initialYVelocity - finalYVelocity) * t) + (0.5f * GRAVITY * t * t);
		currYVelocity = (changeInHeight - 0.5f * GRAVITY * t * t) / t;

	}

	//Jump Methods
	public void resetJump(){

		isGrounded = true;
		canDoubleJump = false;
		maxAirTime = 0.5f * FPS;
		time = 0.0f;

		//Debug.Log ("isGrounded is: "+isGrounded+" Expected result: true");

	}

	public void jump(){

		if (isGrounded) {

			startJump ();

		} else {

			continueJump ();

		}

	}

	private void startJump(){

		if(Input.GetButtonDown("Jump")){

			//Debug.Log ("JumpGetDown");
			if (isGrounded) {
				currYVelocity = initialJumpVelocity;
				isGrounded = false;
				canDoubleJump = true;
			} else if (canDoubleJump) {
				currYVelocity = initialJumpVelocity / 2;
				resetJump ();
				isGrounded = false;
				time = 0.0f;
				maxAirTime /= 2;
			}

			time += 1.0f;
			finalYVelocity = 0.0f;

			Vector2 currVelocity = playerRBody.velocity;
			currVelocity.y = currYVelocity;
			playerRBody.velocity = currVelocity;

		}currYVelocity = initialJumpVelocity;

	}


	private void continueJump(){

		time += 1.0f;

		//Debug.Log ("JustJumpGet");
		if (Input.GetButton("Jump") && time < maxAirTime) {

			Vector2 currVelocity = playerRBody.velocity;
			setNewCurrYVelocity (finalYVelocity, currYVelocity, time, maxAirTime);
			currVelocity.y = currYVelocity;
			playerRBody.velocity = currVelocity;

		}

		if (canDoubleJump) {
			startJump ();
		}

	}

	public float getJumpTime ()	{

		return time;

	}

	public float getMaxAirTime ()	{

		return maxAirTime;

	}


	public bool IsGrounded(){

		return isGrounded;

	}

	public bool CanDoubleJump(){

		return canDoubleJump;

	}

}
