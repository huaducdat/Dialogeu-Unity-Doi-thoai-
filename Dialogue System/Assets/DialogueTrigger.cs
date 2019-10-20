using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scrip Dung nut de kich hoat
public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	public void TriggerDialogue ()
	{
        //tao cau truc add scrip vao nut
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

}
