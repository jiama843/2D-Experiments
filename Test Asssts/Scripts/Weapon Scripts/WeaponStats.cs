using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour {

	public int attack;
	public float meleeSpeed;
	public float shootingSpeed;

	// Use this for initialization
	void Start () {
		
	}

	public int getAttack(){

		return attack;

	}

	public float getMeleeSpeed(){

		return meleeSpeed;

	}

	public float getShootingSpeed(){

		return shootingSpeed;

	}

}
