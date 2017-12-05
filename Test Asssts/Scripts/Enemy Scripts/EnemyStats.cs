using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

	public int health;
	public int attack;
	public int defense;

	private GameObject boss;

	void awake(){

		boss = gameObject;

	}

	public void takeDamage(int attack){

		health -= Mathf.Max((attack - defense), 0);

	}

	public int getHealth(){

		return health;

	}

	public int getAttack(){

		return attack;

	}

	public int getDefense(){

		return defense;

	}

	/*public void save(){

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/playerData.dat", FileMode.Open);

		PlayerData data = new PlayerData ();
		data.health = health;
		data.attack = attack;
		data.defense = defense;

		bf.Serialize (file, data);
		file.Close ();

	}*/

}
