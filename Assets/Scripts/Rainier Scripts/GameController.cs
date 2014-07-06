using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	private int currentLevel;
	private float totalTime;

	private bool switch1;
	private bool switch2;
	private bool switch3;
	private bool switch4;
	private bool switch5;
	private bool switch6;
	private GameObject switch1Object;
	private GameObject switch2Object;
	private GameObject switch3Object;
	private GameObject switch4Object;
	private GameObject switch5Object;
	private GameObject switch6Object;
	private GameObject firstParticle;
	private GameObject secondParticle;
	private ParticleSystem fParticle;
	private ParticleSystem sParticle;

	private GameObject[] switchArrayPlaceHolders;
	private GameObject[] switchArray;


	void Awake () 
	{
		switch1Object = GameObject.FindWithTag ("Switch 1");
		switch2Object = GameObject.FindWithTag ("Switch 2");
		switch3Object = GameObject.FindWithTag ("Switch 3");
		switch4Object = GameObject.FindWithTag ("Switch 4");
		switch5Object = GameObject.FindWithTag ("Switch 5");
		switch6Object = GameObject.FindWithTag ("Switch 6");
		switchArray = new GameObject[6];
		
		for(int i=0; i< switchArray.Length; i++)
		{
			if(switchArray[i] == null)
			{
				array[i] = switchObject
			}
		}

		switchArrayPlaceHolders  = GameObject.FindGameObjectsWithTag("Switch");
		if (switchArrayPlaceHolders.Length < 1) 
		{
			Debug.Log ("Not enough Switches are placed!");
		} 
		else 
		{
			for(int i = 0; i < switchArrayPlaceHolders.Length; i++)
			{

			}
		}
	}

	// Use this for initialization
	void Start () 
	{
		switch1 = false;
		switch2 = false;
		switch3 = false;
		switch4 = false;
		switch5 = false;
		switch6 = false;

		firstParticle = GameObject.FindWithTag ("First Particle");
		secondParticle = GameObject.FindWithTag ("Second Particle");
		fParticle = (ParticleSystem)firstParticle.GetComponent("ParticleSystem");
		sParticle = (ParticleSystem)secondParticle.GetComponent("ParticleSystem");

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (switch1 == true) 
		{

		} 
		else 
		{

		}
	}
}
