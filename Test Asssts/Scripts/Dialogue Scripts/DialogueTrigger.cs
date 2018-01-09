using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	private DialogueController dialogueController;

	// Update is called once per frame
	public IEnumerator startDialogue(){

		//Time.timeScale = 0;
		dialogueController = gameObject.GetComponent<DialogueController> ();
		yield return StartCoroutine (dialogueController.startDialogue (dialogue));

	}

}
