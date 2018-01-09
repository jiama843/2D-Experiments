using UnityEngine;
using System.Collections;

public class PlayerDash : MonoBehaviour
{
	
	private GameObject player;

	private Transform playerTransform;

	private Rigidbody2D playerRBody;

	// Use this for initialization
	void Start ()
	{
		
		player = gameObject;
		playerTransform = player.GetComponent<Transform> ();
		playerRBody = player.GetComponent<Rigidbody2D> ();

	}

	public void dash(float direction){

		StartCoroutine (dashRoutine (direction));
	
	}

	IEnumerator dashRoutine(float direction){

		PlayerInvulnerability playerInv = player.GetComponent<PlayerInvulnerability> ();
		playerInv.setInvincible ();

		float time = 0.0f;
		while (time <= 0.15f){

			Vector2 playerPos = playerTransform.localPosition;
			Vector2 dashSpeed = new Vector2(0.5f, 0);

			playerPos.x += dashSpeed.x * direction;
			playerTransform.localPosition = playerPos;
			time += 1.0f * Time.deltaTime;
			yield return new WaitForSeconds (0.1f * Time.deltaTime);

		}

		playerInv.removeInvincible ();

		yield break;

	}

}

