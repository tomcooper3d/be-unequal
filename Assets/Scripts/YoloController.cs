using UnityEngine;
using System.Collections;

public class YoloController : MonoBehaviour {

	public float maxSpeed = 0.4f;
	public float acceleration = 0.25f; 

	public bool isJumping = false;

	void Update () {
		if (Input.GetKey(KeyCode.A)) {
			transform.Translate((Vector3.left * maxSpeed) * Time.deltaTime);
		} else if (Input.GetKey(KeyCode.D)) {
			transform.Translate((Vector3.right * maxSpeed) * Time.deltaTime);
		} else if (Input.GetKey(KeyCode.W)) {
			transform.Translate((Vector3.forward * maxSpeed) * Time.deltaTime);
		} else if (Input.GetKey(KeyCode.S)) {
			transform.Translate((Vector3.back * maxSpeed) * Time.deltaTime);
		}
	}
}
