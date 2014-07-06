using UnityEngine;
using System.Collections;

public class InstructionController : MonoBehaviour 
{
	private bool correct;
	private static bool created = false;
	
	void Awake() 
	{
		if (!created) 
		{
			// this is the first instance - make it persist
			DontDestroyOnLoad(this.gameObject);
			created = true;
		} 
		else 
		{
			// this must be a duplicate from a scene reload - DESTROY!
			Destroy(this.gameObject);
		} 
	}

	// Use this for initialization
	void Start () 
	{
		correct = true;
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
				MoveControls ();
				return;
			}
			if (Input.GetKeyDown (KeyCode.E)) 
			{
				correct = true;
				MoveControls ();
				return;
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				correct = true;
				MoveControls ();
				return;
			}
			correct = false;
			MoveControls ();
		} 
	}

	void MoveControls()
	{
		if (correct == false) 
		{
			iTween.MoveTo (gameObject, iTween.Hash ("z", -7.8F, "easetype", "easeOutBounce"));
		} 
		if (correct == true)
		{
			iTween.MoveTo (gameObject, iTween.Hash ("z", -22F, "easetype", "easeOutBounce"));
		}
	}
}
