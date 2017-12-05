using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerStats: MonoBehaviour {

	public int health;
	public int defense;

	public float speed;

	public GameObject weapon;

	private GameObject player;

	void awake(){

		player = gameObject;

	}

	public void save(){

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/playerData.dat", FileMode.Open);

		PlayerData data = new PlayerData ();
		data.health = health;
		data.defense = defense;
		data.speed = speed;

		data.weapon = weapon;

		bf.Serialize (file, data);
		file.Close ();

	}

	public int getHealth(){

		return health;

	}

	public int getDefense(){

		return defense;

	}

	public float getSpeed(){

		return speed;

	}

	public GameObject getWeapon(){

		return weapon;

	}

}

[System.Serializable]
class PlayerData{

	public int health;
	public int defense;

	public float speed;

	public GameObject weapon;

}