using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProvider : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {

		player = gameObject;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject getPlayer(){

		return player;

	}

	public Rigidbody2D getRBody(){

		return player.GetComponent<Rigidbody2D> ();

	}

	public Transform getTransform(){
	
		return player.GetComponent<Transform> ();
	
	}

	public Vector3 getSize(){

		return player.GetComponent<Transform> ().localScale;

	}

	public Vector2 getPos(){

		return player.GetComponent<Transform> ().localPosition;

	}

	public float getPosX(){

		Debug.Log ("PosX is called");
		return player.GetComponent<Transform> ().localPosition.x;

	}

	public float getPosY(){
		
		return player.GetComponent<Transform> ().localPosition.y;

	}

}
