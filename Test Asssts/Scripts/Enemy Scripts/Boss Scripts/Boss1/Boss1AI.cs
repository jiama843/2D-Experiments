using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1AI : MonoBehaviour {

	private const float FPS = 60.0f;

	private EnemyController enemyControl;

	private GameObject boss1;

	private Transform boss1Transform;

	private int attackPattern;

	private bool patternRunning;

	public GameObject projectile;

	// Use this for initialization
	void Start () {

		boss1 = gameObject;
		boss1Transform = boss1.GetComponent<Transform> ();
		attackPattern = 1;
		patternRunning = false;
		//allDirectionShootPattern ();

	}
	
	// Update is called once per frame
	void Update () {
		
		aIController ();

	}

	void aIController(){

		//Use math.random to choose attack pattern
		if (!patternRunning) {
			
			patternRunning = true;

			if (attackPattern == 1) {

				allDirectionShootPattern ();

			}

		}

	}

	//Pattern methods
	void allDirectionShootPattern(){

		//Debug.Log ("Starting another Coroutine...");
		StartCoroutine (allDirShoot());

	}

	//Enumerators
	IEnumerator allDirShoot(){

		float time = 0.0f;
		while (time <= 60.0f){

			//Debug.Log ("Actually Yielding...");
			yield return new WaitForSeconds(0.1f);
			allDirectionShoot();
			time += 1.0f * Time.deltaTime;

		}

		patternRunning = false;

	}

	//Function methods
	void allDirectionShoot(){

		int rand = Random.Range (1, 5);

		GameObject projectileInstance = 
			GameObject.Instantiate (projectile, boss1Transform.position, boss1Transform.rotation)
			as GameObject;

		float shootingSpeed = projectileInstance.GetComponent<ProjectileProvider> ().getShootingSpeed ();

		Rigidbody2D projectileInstanceRBody = projectileInstance.GetComponent<Rigidbody2D> ();

		Physics2D.IgnoreCollision (projectileInstance.GetComponent<Collider2D> (), boss1Transform.GetComponent<Collider2D> ());

		if (rand == 1) {
			projectileInstanceRBody.velocity = new Vector2 (shootingSpeed, 0);
		} else if (rand == 2) {
			projectileInstanceRBody.velocity = new Vector2 (shootingSpeed, shootingSpeed);
		} else if (rand == 3) {
			projectileInstanceRBody.velocity = new Vector2 (-shootingSpeed, 0);
		} else {
			projectileInstanceRBody.velocity = new Vector2 (-shootingSpeed, shootingSpeed);
		}

	}

}
