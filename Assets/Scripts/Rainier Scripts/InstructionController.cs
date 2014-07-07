using UnityEngine;
using System.Collections;

public class InstructionController : MonoBehaviour 
{
	private bool correct;
	private Vector3 toCameraPosition;
	private Vector3 toCameraPositionOut;
	private GameObject inScreen;
	private GameObject outScreen;
	private bool rotateInProgress;


	// Use this for initialization
	void Start () 
	{
		correct = true;
		inScreen = GameObject.FindWithTag ("In Screen");
		outScreen = GameObject.FindWithTag ("Out Screen");
		toCameraPosition = inScreen.transform.position;
		toCameraPositionOut = outScreen.transform.position;
		rotateInProgress = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.anyKeyDown) 
		{
			Debug.Log ("hit a key");


			if (Input.GetKeyDown (KeyCode.A)) 
			{
				correct = true;
				MoveControls ();
				return;
			}
			if (Input.GetKeyDown (KeyCode.S)) 
			{
				correct = true;
				MoveControls ();
				return;
			}
			if (Input.GetKeyDown (KeyCode.W)) 
			{
				correct = true;
				MoveControls ();
				return;
			}
			if (Input.GetKeyDown (KeyCode.D)) 
			{
				correct = true;
				MoveControls ();
				return;
			}
			if (Input.GetKeyDown (KeyCode.Q)) 
			{
				correct = true;
				rotateInProgress = true;
				MoveControls ();
				return;
			}
			if (Input.GetKeyDown (KeyCode.E)) 
			{
				correct = true;
				rotateInProgress = true;
				MoveControls ();
				return;
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				correct = true;
				MoveControls ();
				return;
			}
			if (Input.GetKeyDown(KeyCode.Escape)) {
				Application.LoadLevel("Menu");
			}
			correct = false;
			MoveControls ();
		} 
	}

	void MoveControls()
	{
		toCameraPosition = inScreen.transform.position;
		toCameraPositionOut = outScreen.transform.position;
		if (correct == false) 
		{
			iTween.MoveTo (this.gameObject, iTween.Hash ("position", toCameraPosition, "easetype", "easeOutBounce"));
		} 
		if (correct == true && rotateInProgress != true)
		{
			iTween.MoveTo (this.gameObject, iTween.Hash ("position", toCameraPositionOut, "easetype", "easeOutBounce"));
		}
		if (correct == true && rotateInProgress == true) 
		{
			rotateInProgress = false;
			toCameraPositionOut = outScreen.transform.position;
			iTween.MoveTo (this.gameObject, iTween.Hash ("position", toCameraPositionOut, "easetype", "easeOutBounce"));
		}
			
		}
}
