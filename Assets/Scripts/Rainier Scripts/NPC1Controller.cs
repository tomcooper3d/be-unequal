using UnityEngine;
using System.Collections;

//NPC 1 AI script 
//By: Rainier Robichaud
//July 5th 2014

//Cubes that want to dance/hope toghether and avoid any other shapes in the world

public class NPC1Controller : MonoBehaviour 
{
	private GameObject currentCube;
	private GameObject[] NPC1Array;
	private GameObject[] NPC2Array;
	private GameObject[] NPC3Array;
	private GameObject[] NPC4Array;
	private GameObject[] NPC5Array;
	private bool tempSwitch;

	// Use this for initialization
	void Start () 
	{
		tempSwitch = true;
		NPC1Array  = GameObject.FindGameObjectsWithTag("NPC 1");
		NPC2Array  = GameObject.FindGameObjectsWithTag("NPC 2");
		NPC3Array  = GameObject.FindGameObjectsWithTag("NPC 3");
		NPC4Array  = GameObject.FindGameObjectsWithTag("NPC 4");
		NPC5Array  = GameObject.FindGameObjectsWithTag("NPC 5");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (tempSwitch) 
		{
			FindNPC1();
			FindNPC2();
			FindNPC3();
			FindNPC4();
			FindNPC5();
			tempSwitch = false;
		}

	}

	void FindNPC1()
	{
		//Looks at player when he get close and jumps with friends
		NPC1Array = GameObject.FindGameObjectsWithTag("NPC 1");
		foreach (GameObject NPC in NPC1Array)
		{
			currentCube = NPC;
			iTween.MoveBy (currentCube, iTween.Hash ("y", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
		}
	}

	void FindNPC2()
	{
		//plays tag while avoiding the player
		NPC2Array = GameObject.FindGameObjectsWithTag("NPC 2");
	}

	void FindNPC3()
	{
		//tackles each other and the player
		NPC3Array = GameObject.FindGameObjectsWithTag("NPC 3");
	}

	void FindNPC4()
	{

		NPC4Array = GameObject.FindGameObjectsWithTag("NPC 4");
	}

	void FindNPC5()
	{
		NPC5Array = GameObject.FindGameObjectsWithTag("NPC 5");
	}
	
}
