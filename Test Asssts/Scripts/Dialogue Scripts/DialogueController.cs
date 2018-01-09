using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {
	
	private Queue<Dialogue.CharacterDialogue> characterDialogues = new Queue<Dialogue.CharacterDialogue> ();

	private Text nameText;
	private Text dialogueText;

	// Use this for initialization
	//Since this is instantiated, you cannot use start

	/*void Update(){

		if (characterDialogues.Count != 0 && Input.GetKeyDown ("z")) {

			displayNextSentence ();

		}

	}*/

	public IEnumerator startDialogue(Dialogue dialogue){

		//this.characterDialogues.Enqueue (dialogue.characterDialogues[0]);

		characterDialogues.Clear ();

		foreach(Dialogue.CharacterDialogue characterDialogue in dialogue.characterDialogues){

			this.characterDialogues.Enqueue (characterDialogue);

		}

		yield return StartCoroutine (runCharacterDialogue ());

	}

	IEnumerator displayNextSentence(){

		/*if (characterDialogues.Count == 0) {

			characterDialogues.Clear ();
			endDialogue ();

		}*/
			
		Dialogue.CharacterDialogue charDialogueElement = characterDialogues.Dequeue ();

		//Replace the Logs with UI SetText methods
		nameText = gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Text>();
		dialogueText = gameObject.GetComponent<Transform>().GetChild(1).GetComponent<Text>();

		nameText.text = charDialogueElement.name;
		dialogueText.text = "";

		yield return StartCoroutine (displaySentenceByCharacters (charDialogueElement.sentences));

	}

	IEnumerator displaySentenceByCharacters(string s){

		char[] dialogueCharArray = s.ToCharArray ();

		for (int i = 0; i < dialogueCharArray.Length; i++) {

			yield return new WaitForSeconds (0.05f);
			dialogueText.text += dialogueCharArray [i];

		}

		yield break;

	}

	public void endDialogue(){

		//Time.timeScale = 1;
		Destroy (gameObject);

	}

	IEnumerator runCharacterDialogue(){
		
		while (characterDialogues.Count != 0) {
			//Debug.Log (characterDialogues.Count);

			yield return StartCoroutine(displayNextSentence ());
			yield return new WaitForSeconds (0.1f);
			yield return new WaitUntil (nextKeyPressed);

		}

		endDialogue ();
		yield break;

	}

	//If display next
	private bool nextKeyPressed(){

		return Input.GetKeyDown ("z");

	}

}
