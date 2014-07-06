using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {

	public GameObject dd;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(dd.transform.position, Vector3.up, 60 * Time.deltaTime);
	}
}
