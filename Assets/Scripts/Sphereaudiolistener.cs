using UnityEngine;
using System.Collections;

public class Sphereaudiolistener : MonoBehaviour {

	public GameObject sphere;

	void Start () {
	
	}

	void Update () {
		this.transform.position = sphere.transform.position;
	}
}
