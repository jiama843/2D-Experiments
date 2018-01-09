using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerHorizontal {

	private GameObject player;

	private Transform playerTransform;

	private Rigidbody2D playerRBody;

	private float speed;

	private bool faceLeft = false;

	public PlayerHorizontal(GameObject player, float speed){

		this.player = player;
		this.playerTransform = player.GetComponent<Transform> ();
		this.playerRBody = player.GetComponent<Rigidbody2D> ();
		this.speed = speed;

	}

	public void move(){

		Vector2 playerPos = playerTransform.localPosition;

		if (Input.GetAxisRaw ("Horizontal") > 0) {

			faceLeft = false;
			playerPos.x += speed * Time.deltaTime;

		} else if (Input.GetAxisRaw ("Horizontal") < 0) {

			faceLeft = true;
			playerPos.x -= speed * Time.deltaTime;

		}

		playerTransform.localPosition = playerPos;

	}

	public void dash(float direction){

		PlayerDash playerDash = player.GetComponent<PlayerDash> ();
		playerDash.dash (direction);

	}

	public float getSpeed(){

		return speed;

	}

	public bool isLeft(){

		return faceLeft;

	}

	public bool isRight(){

		return !faceLeft;

	}

}
