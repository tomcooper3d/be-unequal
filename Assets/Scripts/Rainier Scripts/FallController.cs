using UnityEngine;
using System.Collections;

public class FallController : MonoBehaviour 
{
	private GameObject player;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Floor") 
		{
			player.transform.position = new Vector3(-0.6F,1.18F,1F);	
		}
	}
}
