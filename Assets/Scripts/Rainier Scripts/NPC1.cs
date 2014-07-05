﻿using UnityEngine;
using System.Collections;

public class NPC1 : MonoBehaviour 
{
	private int randomNumber;
	private bool randomRunning;
	private GameObject npcScript;
	private GameObject boundries;
	private NPCController npcController;
	private bool delayBehaviorNPC1Switch;

	public int npc1UpOnly;
	public int npc1Up;
	public int npc1Forward;

	// Use this for initialization
	void Start () 
	{
		npcScript = GameObject.FindWithTag("NPC Script");
		npcController = npcScript.GetComponent<NPCController>();
		boundries = GameObject.FindWithTag("Boundries");
		randomRunning = false;
		delayBehaviorNPC1Switch = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (randomRunning == false && npcController.randomizeNPC1 == true)
		{
			StartCoroutine (randomNumberCreator());
		}
		behaviorNPC1();
	}

	void OnTriggerStay(Collider other) 
	{
		if (other.tag == "Boundries") 
		{
			iTween.LookTo(gameObject, iTween.Hash ("looktarget", boundries.transform.position, "axis", "y"));
			Debug.Log ("im out");
		}
	}


	IEnumerator randomNumberCreator()
	{
		randomRunning = true;
		npc1Up = Random.Range (1, 3);
		npc1Forward = Random.Range (1, 3);
		npc1UpOnly = Random.Range (1, 4);
		yield return new WaitForSeconds(14);
		randomRunning = false;
	}

	void behaviorNPC1()
	{
		if (delayBehaviorNPC1Switch == false) 
		{
			iTween.MoveAdd (gameObject, iTween.Hash ("y", npc1Up, "easeType", "easeInOutExpo","delay", 1));
			StartCoroutine (delayBehaviorNPC1());
		}
		else
		{
			iTween.MoveAdd (gameObject, iTween.Hash ("y", npc1UpOnly, "easeType", "easeInOutExpo", "delay", 1));
		}
	}
	
	IEnumerator delayBehaviorNPC1()
	{
		yield return new WaitForSeconds(5);
		delayBehaviorNPC1Switch = true;
		yield return new WaitForSeconds(5);
		delayBehaviorNPC1Switch = false;
	}
}
