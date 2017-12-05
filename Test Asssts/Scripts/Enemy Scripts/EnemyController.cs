using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	/* Controller functions
	 * 	Destroy Enemy (Different Script)
	 * 	Modify/Use EnemyStats
	 */
	private EnemyStats enemyStats;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		destroyByHealth ();

	}

	//Provider Methods
	public int getAttack(){

		enemyStats = gameObject.GetComponent<EnemyStats> ();
		return enemyStats.getAttack ();

	}

	//Receiver Methods
	public void takeDamage(int attack){

		enemyStats = gameObject.GetComponent<EnemyStats> ();
		enemyStats.takeDamage (attack);

	}

	public void destroyByHealth (){

		enemyStats = gameObject.GetComponent<EnemyStats> ();

		if (enemyStats.getHealth() <= 0) {

			Destroy (gameObject);

		}

	}

}
