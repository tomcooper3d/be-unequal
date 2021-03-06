﻿using UnityEngine;
using System.Collections;

//NPC 1 AI script 
//By: Rainier Robichaud
//July 5th 2014

//Cubes that want to dance/hope toghether and avoid any other shapes in the world

public class NPCController : MonoBehaviour 
{
	private GameObject currentCube;
	private GameObject[] NPC1Array;
	private GameObject[] NPC2Array;
	private GameObject[] NPC3Array;
	private bool tempSwitch;


	public bool randomizeNPC1;


	// Use this for initialization
	void Start () 
	{
		tempSwitch = true;
		NPC1Array  = GameObject.FindGameObjectsWithTag("NPC 1");
		NPC2Array  = GameObject.FindGameObjectsWithTag("NPC 2");
		NPC3Array  = GameObject.FindGameObjectsWithTag("NPC 3");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (tempSwitch) 
		{
			FindNPC1();
			FindNPC2();
			FindNPC3();
			tempSwitch = false;
		}
	}

	//-------------------------------------------------------------------------------------NPC 1 BEHAVIOR START
	void FindNPC1()
	{
		//Looks at player when he get close and jumps with friends
		NPC1Array = GameObject.FindGameObjectsWithTag("NPC 1");
	}
	//-------------------------------------------------------------------------------------NPC 1 BEHAVIOR END

	//-------------------------------------------------------------------------------------NPC 2 BEHAVIOR START
	
	void FindNPC2()
	{
		//plays tag while avoiding the player
		NPC2Array = GameObject.FindGameObjectsWithTag("NPC 2");
	}

	IEnumerator behaviorNPC2()
	{
		foreach (GameObject NPC in NPC2Array)
		{
			currentCube = NPC;
			iTween.MoveAdd (currentCube, iTween.Hash ("y", 2, "easeType", "easeInOutExpo", "loopType", "none", "delay", 1));
		}
		yield return new WaitForSeconds(5);
	}

	//-------------------------------------------------------------------------------------NPC 2 BEHAVIOR END

	//-------------------------------------------------------------------------------------NPC 3 BEHAVIOR START

	void FindNPC3()
	{
		//tackles each other and the player
		NPC3Array = GameObject.FindGameObjectsWithTag("NPC 3");
	}

	IEnumerator behaviorNPC3()
	{
		foreach (GameObject NPC in NPC3Array)
		{
			currentCube = NPC;
			iTween.MoveAdd (currentCube, iTween.Hash ("y", 2, "easeType", "easeInOutExpo", "loopType", "none", "delay", 1));
		}
		yield return new WaitForSeconds(5);
	}

	//-------------------------------------------------------------------------------------NPC 3 BEHAVIOR END

}
