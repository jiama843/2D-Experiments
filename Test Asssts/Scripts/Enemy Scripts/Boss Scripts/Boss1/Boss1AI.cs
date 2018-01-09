using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Stdlib;

public class Boss1AI : MonoBehaviour {

	private EnemyController enemyControl;

	private GameObject boss1;

	private Transform boss1Transform;

	private Rigidbody2D boss1RBody;

	private PlayerProvider playerProvider;

	private int attackPattern;

	private bool patternRunning;

	public GameObject bossBullet;
	public GameObject bossSlash;
	public GameObject bossLargeBullet;

	public GameObject player;

	public GameObject cutscene2;

	// Use this for initialization
	void awake(){

		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;

	}

	void Start () {

		boss1 = gameObject;
		boss1Transform = boss1.GetComponent<Transform> ();
		boss1RBody = boss1.GetComponent<Rigidbody2D> ();
		attackPattern = 1;
		patternRunning = false;

		StartCoroutine(aIController());

	}
	
	// Update is called once per frame
	void Update () {
		
		//aIController ();

	}

	//AI Controller Enum
	IEnumerator aIController(){

		//Use math.random to choose attack pattern
		//yield return StartCoroutine(startAttack());
		//yield return new WaitForSeconds (1.0f);
		//yield return StartCoroutine (conversation2 ());
		yield return new WaitForSeconds (0.5f);
		yield return StartCoroutine (attackPattern1 ());

		Debug.Log ("Dialogue finished");

		//Start Next Attack Pattern Here

		/*if (!patternRunning) {

			//teleportToLocation (Random.Range (1, 5));

			attackPattern = Random.Range (1, 3);
			patternRunning = true;

			/*if (attackPattern == 1) {

				allDirectionShootPattern ();

			} else if (attackPattern == 2) {

				downwardAttackPattern ();

			}

		}*/

	}

	//Enumerators for Main AttackPatterns
	IEnumerator startAttack(){

		StartCoroutine (teleportToLocation (5));		//allDirectionShootPattern ();

		yield return new WaitForSeconds (30.0f * Time.deltaTime);

		for (int i = 0; i < 3; i++) {


			yield return StartCoroutine(shockwave(-75.0f));
			//Debug.Log (Time.deltaTime);
		
		}

		yield return new WaitForSeconds (10.0f * Time.deltaTime);//Useless wait

		yield return StartCoroutine (teleportToLocation (6));

		yield return StartCoroutine(allDirectionShootPattern (3.0f));

		for(int a = 0; a < 5; a++){

			for (int i = 0; i < 20; i++) {

				shootPlayer (20.0f);
				yield return new WaitForSeconds (5.0f * Time.deltaTime);

			}
				
			int[] locations = { 2, 4, 6, 2, 6 };
			StartCoroutine (teleportToLocation (locations [a]));

		}

		yield break;

	}
		
	IEnumerator attackPattern1(){

		yield return StartCoroutine (BottomShootPlayerPattern (20.0f));
		yield return new WaitForSeconds (1.0f);
		yield return StartCoroutine (teleportToLocation (5));
		yield return new WaitForSeconds (1.0f);
		yield return StartCoroutine (sideShootPattern (30.0f, Direction.LEFT));
		yield return new WaitForSeconds (1.0f);
		yield return StartCoroutine (teleportToLocation (1));
		yield return new WaitForSeconds (0.7f);
		yield return StartCoroutine (sideShootPattern (40.0f, Direction.RIGHT));
		yield return new WaitForSeconds (2.0f);
		yield return StartCoroutine (teleportToLocation (2));
		yield return StartCoroutine (eightDirShootPattern (10.0f, 3));
		yield return StartCoroutine (teleportToLocation (4));
		yield return StartCoroutine (eightDirShootPattern (10.0f, 3));
		yield return StartCoroutine (teleportToLocation (5));
		yield return StartCoroutine (eightDirShootPattern (10.0f, 3));
		yield return StartCoroutine (teleportToLocation (6));
		yield return new WaitForSeconds (3.0f);
		StartCoroutine (eightDirLargeShootPattern (1.0f, 50, 3.0f));
		yield return new WaitForSeconds (1.0f);
		StartCoroutine (eightDirLargeShootPattern (3.0f, 50, -5.0f));
		yield return new WaitForSeconds (35.0f);
		StartCoroutine (teleportToLocation (3));
		yield return new WaitForSeconds (5.0f);

	}

	IEnumerator eightDirShootPattern(float speed, int numTimes){

		Vector2 dir1 = getDirection (new Vector2 (1.0f, 0.0f), new Vector2 (0.0f, 0.0f));
		Vector2 dir2 = getDirection (new Vector2 (1.0f, -1.0f), new Vector2 (0.0f, 0.0f));
		Vector2 dir3 = getDirection (new Vector2 (0.0f, -1.0f), new Vector2 (0.0f, 0.0f));
		Vector2 dir4 = getDirection (new Vector2 (-1.0f, -1.0f), new Vector2 (0.0f, 0.0f));
		Vector2 dir5 = getDirection (new Vector2 (-1.0f, 0.0f), new Vector2 (0.0f, 0.0f));
		Vector2 dir6 = getDirection (new Vector2 (-1.0f, 1.0f), new Vector2 (0.0f, 0.0f));
		Vector2 dir7 = getDirection (new Vector2 (0.0f, 1.0f), new Vector2 (0.0f, 0.0f));
		Vector2 dir8 = getDirection (new Vector2 (1.0f, 1.0f), new Vector2 (0.0f, 0.0f));

		Vector2[] eightDirs = { dir1, dir2, dir3, dir4, dir5, dir6, dir7, dir8 };

		for (int i = 0; i < numTimes; i++) {

			foreach (Vector2 dir in eightDirs) {

				GameObject projectileInstance =
					GameObject.Instantiate (bossBullet, boss1Transform.localPosition, boss1Transform.rotation)
				as GameObject;

				Transform projectileInstanceTransform = projectileInstance.GetComponent<Transform> ();

				projectileInstance.GetComponent<Rigidbody2D> ().velocity = dir * speed;

			}

			yield return new WaitForSeconds (0.3f);
		
		}

		yield break;

	}


	//Easy to abstract especially with above method
	IEnumerator eightDirLargeShootPattern(float speed, int numTimes, float degree){

		Vector2 dir1 = getDirection (new Vector2 (1.0f, 0.0f), new Vector2 (0.0f, 0.0f));
		Vector2 dir2 = getDirection (new Vector2 (1.0f, -1.0f), new Vector2 (0.0f, 0.0f));
		Vector2 dir3 = getDirection (new Vector2 (0.0f, -1.0f), new Vector2 (0.0f, 0.0f));
		Vector2 dir4 = getDirection (new Vector2 (-1.0f, -1.0f), new Vector2 (0.0f, 0.0f));
		Vector2 dir5 = getDirection (new Vector2 (-1.0f, 0.0f), new Vector2 (0.0f, 0.0f));
		Vector2 dir6 = getDirection (new Vector2 (-1.0f, 1.0f), new Vector2 (0.0f, 0.0f));
		Vector2 dir7 = getDirection (new Vector2 (0.0f, 1.0f), new Vector2 (0.0f, 0.0f));
		Vector2 dir8 = getDirection (new Vector2 (1.0f, 1.0f), new Vector2 (0.0f, 0.0f));

		Vector2[] eightDirs = { dir1, dir2, dir3, dir4, dir5, dir6, dir7, dir8 };

		for (int i = 0; i < numTimes; i++) {

			for (int a = 0; a < eightDirs.Length; a++) {

				GameObject projectileInstance =
					GameObject.Instantiate (bossBullet, boss1Transform.localPosition, boss1Transform.rotation)
					as GameObject;

				projectileInstance.GetComponent<ProjectileController> ().lifespan += 200.0f;

				Transform projectileInstanceTransform = projectileInstance.GetComponent<Transform> ();

				//eightDirs [a].x += 1.0f;

				eightDirs [a] = rotateVector (eightDirs [a], degree);

				projectileInstance.GetComponent<Rigidbody2D> ().velocity = eightDirs [a] * speed;

			}

			yield return new WaitForSeconds (0.8f);

		}

		yield break;

	}

	IEnumerator sideShootPattern(float speed, float directionFacing){

		//Need bullets with longer lifespan
		//Find a method that returns array length
		GameObject[] bullets = new GameObject[20];

		for (int i = 0; i < bullets.Length; i++) {

			GameObject projectileInstance =
				GameObject.Instantiate (bossBullet, boss1Transform.localPosition, boss1Transform.rotation)
				as GameObject;

			Transform projectileInstanceTransform = projectileInstance.GetComponent<Transform> ();

			float startX = Random.Range (boss1Transform.localPosition.x + 2.0f * directionFacing,
				               boss1Transform.localPosition.x + 3.0f * directionFacing);

			float startY = Random.Range (boss1Transform.localPosition.y - 2.0f,
				               boss1Transform.localPosition.y + 2.0f);

			Vector2 startPos = new Vector2 (startX, startY);

			yield return StartCoroutine (moveTo (projectileInstanceTransform, startPos));

			projectileInstance.GetComponent<ProjectileController> ().lifespan += 200.0f;

			bullets [i] = projectileInstance;

		}

		for (int i = 0; i < bullets.Length; i++) {

			if (bullets [i] == null) continue;

			yield return new WaitForSeconds (0.1f);
			Vector2 direction = getDirection (player.GetComponent<Transform> ().localPosition,
				                    bullets [i].GetComponent<Transform> ().localPosition);
			
			bullets [i].GetComponent<Rigidbody2D> ().velocity = direction * speed;

		}

	}

	IEnumerator BottomShootPlayerPattern(float speed){

		Vector2 pos1 = new Vector2 (boss1Transform.localPosition.x - 8.0f, boss1Transform.localPosition.y + 3.0f);
		Vector2 pos2 = new Vector2 (boss1Transform.localPosition.x + 8.0f, boss1Transform.localPosition.y + 3.0f);
		Vector2 pos3 = new Vector2 (boss1Transform.localPosition.x - 14.0f, boss1Transform.localPosition.y + 6.0f);
		Vector2 pos4 = new Vector2 (boss1Transform.localPosition.x + 14.0f, boss1Transform.localPosition.y + 6.0f);
		//Vector2 pos5 = new Vector2 (boss1Transform.localPosition.x, boss1Transform.localPosition.y + 5.0f);

		Vector2[] bulletPos = { pos1, pos2, pos3, pos4 };//, pos5 };
		GameObject[] bullets = new GameObject[4];

		for (int i = 0; i < bullets.Length; i++){// change to 5 if pos5 is added

			GameObject projectileInstance =
				GameObject.Instantiate (bossLargeBullet, bulletPos[i], boss1Transform.rotation)
				as GameObject;

			Rigidbody2D projectileInstanceRBody = projectileInstance.GetComponent<Rigidbody2D> ();

			bullets [i] = projectileInstance;
			yield return new WaitForSeconds (0.2f);

		}

		for (int i = 0; i < bullets.Length; i++){// change to 5 if pos5 is added

			if (bullets [i] == null) continue;

			Vector2 direction = getDirection(player.GetComponent<Transform>().localPosition, 
				bullets [i].GetComponent<Transform>().localPosition);

			bullets [i].GetComponent<Rigidbody2D> ().velocity = direction * speed;

			//yield return new WaitForSeconds (0.3f);

		} 

		patternRunning = false;
		yield break;

	}

	//Enumerators for Helper attack patterns
	IEnumerator allDirectionShootPattern(float seconds){

		float time = 0.0f;
		while (time <= seconds){

			//Debug.Log ("Actually Yielding...");
			yield return new WaitForSeconds(1.0f * Time.deltaTime);
			allDirectionShoot();
			time += 1.0f * Time.deltaTime;

		}

		patternRunning = false;

	}

	/*IEnumerator downwardAttackPattern(){

		float time = 0.0f;
		while (time <= 0.1f){

			//Debug.Log ("Actually Yielding...");
			yield return new WaitForSeconds(0.5f);
			teleportOnTop();
			yield return new WaitForSeconds(0.2f);
			boss1RBody.velocity = new Vector2 (0, -20);

			//allDirectionShoot();
			time += 1.0f * Time.deltaTime;

		}

		yield return new WaitForSeconds(1.0f);
		patternRunning = false;

	}*/

	//FIX THIS ~ HAVING DIALOGUE ENUMERATORS IN AI CLASS
	//Dialogue Enumerators
	IEnumerator conversation2(){

		GameObject cutscene2Instance =
			GameObject.Instantiate (cutscene2)
			as GameObject;

		DialogueTrigger trigger = cutscene2Instance.GetComponent<DialogueTrigger> ();
		yield return StartCoroutine (trigger.startDialogue ());

	}

	//Helper Enumerators
	IEnumerator teleport(Vector2 targetPos){

		//Debug.Log ("teleport start");
		yield return StartCoroutine(moveTo(boss1Transform, targetPos));

		patternRunning = false;

	}

	IEnumerator shockwave(float speed){

		float z = Random.Range (75.0f, 100.0f);

		Vector3 rotation = new Vector3 (0.0f, 0.0f, z);
			
		GameObject projectileInstance =
			GameObject.Instantiate (bossSlash, boss1Transform.position, Quaternion.Euler (rotation))
			as GameObject;

		Rigidbody2D projectileInstanceRBody = projectileInstance.GetComponent<Rigidbody2D> ();

		projectileInstanceRBody.velocity = new Vector2 (speed, 0.0f);

		yield return new WaitForSeconds (0.8f);//50.0f * Time.deltaTime);

	}

	IEnumerator moveTo(Transform trans, Vector2 targetPos){

		Vector2 currPos = trans.localPosition;
		Vector2 direction = getDirection (targetPos, currPos);

		bool travelling = true;

		while (travelling) {

			yield return new WaitForSeconds (0.1f * Time.deltaTime);

			//float arithmetic doesn't work if the value being subtracted is less than 10^-6

			if (direction.x < 0) {
				currPos.x += Mathf.Min(direction.x, -0.000001f);
			} else {
				currPos.x += Mathf.Max(direction.x, 0.000001f);
			}

			if (direction.y < 0) {
				currPos.y += Mathf.Min(direction.y, -0.000001f);
			} else {
				currPos.y += Mathf.Max(direction.y, 0.000001f);
			}

			trans.localPosition = currPos;

			travelling = isTravelling (currPos, targetPos, direction.x, direction.y);

		}

	}

	//attack helper functions
	void shootPlayer(float speed){

		playerProvider = player.GetComponent<PlayerProvider> ();

		Vector2 targetPos = playerProvider.getPos ();
		Vector2 startPos = boss1Transform.localPosition;

		Vector2 direction = getDirection (targetPos, startPos);

		GameObject projectileInstance =
			GameObject.Instantiate (bossBullet, boss1Transform.position, boss1Transform.rotation)
			as GameObject;

		Rigidbody2D projectileInstanceRBody = projectileInstance.GetComponent<Rigidbody2D> ();

		projectileInstanceRBody.velocity = direction * speed;

	}

	void allDirectionShoot(){

		float randX = Random.Range (-15.0f, 15.0f);
		float randY = Random.Range (-15.0f, 15.0f);

		GameObject projectileInstance = 
			GameObject.Instantiate (bossBullet, boss1Transform.position, boss1Transform.rotation)
			as GameObject;

		Rigidbody2D projectileInstanceRBody = projectileInstance.GetComponent<Rigidbody2D> ();

		//Physics2D.IgnoreCollision (projectileInstance.GetComponent<Collider2D> (), boss1Transform.GetComponent<Collider2D> ());

		projectileInstanceRBody.velocity = new Vector2 (randX, randY);

	}

	/* Accepts integer from 1-5 and moves character to respective position
	 * 1 ~ Bottom Left
	 * 2 ~ Top Left
	 * 3 ~ Center
	 * 4 ~ Top Right
	 * 5 ~ Bottom Right
	 * 6 (Only use once) ~ High center
	 */
	IEnumerator teleportToLocation(int location){
		
		//Debug.Log (location);
		switch (location){

		case 1:
			StartCoroutine (teleport (new Vector2 (-15.0f, 3.0f)));
			break;
		
		case 2:
			StartCoroutine (teleport (new Vector2 (-8.0f, 8.0f)));
			break;

		case 3:
			StartCoroutine (teleport (new Vector2 (0.0f, 4.0f)));
			break;

		case 4:
			StartCoroutine (teleport (new Vector2 (8.0f, 8.0f)));
			break;

		case 5:
			StartCoroutine (teleport (new Vector2 (15.0f, 3.0f)));
			break;

		case 6:
			StartCoroutine (teleport (new Vector2 (0.0f, 8.0f)));
			break;

		}

		yield break;

	}

	void teleportOnTop(){

		player = GameObject.FindWithTag ("Player");
		PlayerProvider playerProvider = player.GetComponent<PlayerProvider> ();
		//GameObject.Find("Player").GetComponent<PlayerProvider> ();

		//Debug.Log (player);
		//Debug.Log (playerProvider);
		//Debug.Log ("PosX is about to be called");

		float posX = playerProvider.getPosX ();
		float posY = 5.0f;//playerProvider.getSize ().y * 3;

		boss1.transform.localPosition = new Vector2 (posX, posY);

	}

	bool isTravelling(Vector2 currPos, Vector2 targetPos, float changeX, float changeY){

		if (changeX < 0) {
			if (changeY < 0) {
				if (currPos.x <= targetPos.x && currPos.y <= targetPos.y) return false;
			} else if (changeY >= 0) {
				if (currPos.x <= targetPos.x && currPos.y >= targetPos.y) return false;
			}
		} else if (changeX >= 0) {
			if (changeY < 0) {
				if (currPos.x >= targetPos.x && currPos.y <= targetPos.y) return false;
			} else if (changeY >= 0) {
				if (currPos.x >= targetPos.x && currPos.y >= targetPos.y) return false;
			}
		}

		return true;

	}

	//Helper functions
	private Vector2 getDirection(Vector2 targetPos, Vector2 startPos){

		float changeX = targetPos.x - startPos.x;
		float changeY = targetPos.y - startPos.y;

		float scalarXY = Mathf.Sqrt (Mathf.Pow(changeX, 2) + Mathf.Pow(changeY, 2));

		float dirX = changeX / scalarXY;
		float dirY = changeY / scalarXY;

		Vector2 direction = new Vector2 (dirX, dirY);

		return direction;

	}

	private Vector2 rotateVector(Vector2 dir, float degree){

		float[,] rotationMatrix = new float[2, 2];

		/* [cosx	-sinx]
		 * [sinx	cosx]
		 * 
		 * [0,0	0,1]
		 * [1,0	1,1]
		 * 
		 * Correspondence
		 */
		rotationMatrix [0, 0] = Mathf.Cos (degree);
		rotationMatrix [0, 1] = -Mathf.Sin (degree);
		rotationMatrix [1, 0] = Mathf.Sin (degree);
		rotationMatrix [1, 1] = Mathf.Cos (degree);

		float newDirX = rotationMatrix [0, 0] * dir.x + rotationMatrix [0, 1] * dir.y;
		float newDirY = rotationMatrix [1, 0] * dir.x + rotationMatrix [1, 1] * dir.y;

		Vector2 newDir = new Vector2 (newDirX, newDirY);

		return newDir;

	}

}
