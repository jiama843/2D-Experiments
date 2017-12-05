using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHorizontal {

	private Transform playerTransform;

	private Rigidbody2D playerRBody;

	private const float FPS = 60.0f;

	private float speed;

	private bool faceLeft = false;

	public PlayerHorizontal(GameObject player, float speed){

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
