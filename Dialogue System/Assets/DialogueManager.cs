using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Co che hoat dong:
 * Lay cau phan tu Dialoue
 * Xoa bo Text hien tai
 * _Methor StartDialogeu se chay
 * them tung phan tu string[] cua Dialogue vao hang doi Queue (foreach { Queue.Enqueue } )
 * _Methor DislayNextSentence se chay
 * 
 * {
 *      Neu phan tu Hang doi Queue == 0 thi Ket thuc
 *      
 *      Lay 1 string moi sentence = 1 element thoat ra tu Queue(Dequeue)
 *      (sentence moi = phan tu bi xoa khoi hang doi queue(Queue.Dequeue))
 *      Dung moi Methor
 *      Chi chay Methor TypeOfSentence(sentence)
 *          //Tao ra kieu hien chu dan dan
 *          {
 *              Tao IEnumerator TyprOfSentence(string sentence)
 *                  Cho dialogeuText = "" 
 *                  Them tung char vao dialogeuText (dialogeutext += char) bang foreach va tra ve yeild return null(tra ve kieu them tung phan vao null(Tra ve List Khong ton tai Vi khong can lay List ra))
 *          }
 *      Thu duoc dialogText         
 *      
 *     End (Khi Queue.Cont == 0 Methor DislayNextSentence() se return)
 * 
 * }
 */


public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	public Animator animator;

    //tao hang doi Queue
	private Queue<string> sentences;





	// Use this for initialization
	void Start ()
    {
        //Tao Instance cua Queue<string> sentence
		sentences = new Queue<string>();
	}







	public void StartDialogue (Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

        //Add string[] sentence vao Queue sentence
		foreach (string sentence in dialogue.sentences)
		{
            //them 1 phan tu vao hang doi Queue = string sentence
			sentences.Enqueue(sentence);
		}

        //thuc hien
		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
        //Neu sentence.Conunt = 0 (so luong Element trong hang doi Queue = 0) thi End it
		if (sentences.Count == 0)
		{
            //Tat animations
			EndDialogue();
            //Return khoi ham( Thoat ham)
			return;
		}

        //Tao 1 string sentence moi = phan tu hang doi Queue bi xoa
		string sentence = sentences.Dequeue();
        //Dung tat ca cac Methor
		StopAllCoroutines();
        //Bat Methor TypeOfSentence
		StartCoroutine(TypeSentence(sentence));
	}


    //Tao TypeSente(string) dang interface IEnumerator de duyet foreach voi kieu tra ve yeild return
	IEnumerator TypeSentence (string sentence)
	{
        //dialogueText.text = ""
		dialogueText.text = "";

        //tao vong lap foreach duyet Ky tu trong mang sentence vua tach ra duoc tu Dialogue.string[] sentence
		foreach (char letter in sentence.ToCharArray()/*chuyen string sentence thanh mang*/)
		{
            //Them tung ky tu(letter) vao dialogueText.Text
			dialogueText.text += letter;
            //Tra ve null va chay lai cho den khi het foreach
			yield return null;
		}
	}

    //Methor End Dialogue
	void EndDialogue()
	{
        //Tat animation
		animator.SetBool("IsOpen", false);
	}

}
