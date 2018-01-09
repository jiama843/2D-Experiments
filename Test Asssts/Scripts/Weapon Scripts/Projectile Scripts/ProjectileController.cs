using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

	private GameObject projectile;

	private WeaponStats weaponStats;

	private const float FPS = 60.0f;

	public float lifespan;
	public float life;

	public bool destructible;

	void awake(){

		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;

	}

	void Start () {

		projectile = gameObject;
		lifespan *= FPS;
		life = 0;

	}
	
	// Update is called once per frame
	void Update () {

		destroyByLifeSpan ();

	}

	void destroyByLifeSpan(){

		life += 1.0f;

		if(life >= lifespan){

			Destroy (projectile);

		}

	}
		
	//Provider Methods
	public int getAttack(){

		weaponStats = gameObject.GetComponent<WeaponStats> ();
		return weaponStats.getAttack ();

	}

	public float getMeleeSpeed(){

		weaponStats = gameObject.GetComponent<WeaponStats> ();
		return weaponStats.getMeleeSpeed ();

	}

	public float getShootingSpeed(){

		weaponStats = gameObject.GetComponent<WeaponStats> ();
		return weaponStats.getShootingSpeed ();

	}

	public bool isDestructible(){

		return destructible;

	}

	//Receiver Methods
	public void destroyByCollision(){

		Destroy (gameObject);

	}

}
