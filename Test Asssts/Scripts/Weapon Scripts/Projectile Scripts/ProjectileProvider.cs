using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileProvider : MonoBehaviour {

	ProjectileController projectileController;

	// Use this for initialization
	void Start () {

	}

	//Provider Methods
	public int getAttack (){

		projectileController = gameObject.GetComponent<ProjectileController> ();
		return projectileController.getAttack ();

	}

	public float getShootingSpeed (){

		projectileController = gameObject.GetComponent<ProjectileController> ();
		return projectileController.getShootingSpeed ();

	}

	/*public bool isDestructible(){

		projectileController = gameObject.GetComponent<ProjectileController> ();
		return projectileController.isDestructible ();

	}*/

}
