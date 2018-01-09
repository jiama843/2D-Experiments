using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

	[System.Serializable]
	public struct CharacterDialogue{
		
		public string name;
		public string sentences;

	}

	public CharacterDialogue[] characterDialogues;

}
