using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {

	public GameObject dd;
	public AudioSource source;
	private bool inTransition;
	private bool currentAngle;

	private float initalYAngle = 315.0f;
	private float currentYAngle = 315.0f;

	// Update is called once per frame
	void Update () {
		if (!inTransition) {
			if (Input.GetKeyDown (KeyCode.Q)) {
				inTransition = true;
				StartCoroutine(rotate(true));
			}
			if (Input.GetKeyDown (KeyCode.E)) {
				inTransition = true;
				StartCoroutine(rotate(false));
			}
		}
	}

	IEnumerator rotate(bool left) {
		bool enabled = true;
		float last = transform.localEulerAngles.y;
		float dest = (transform.localEulerAngles.y + (left ? 90 : -90)) % 360;
		float total = 0.0f;
		float val = 225.0f;
		source.Play();
		while (enabled) {
			float deltaAngle = (left ? val : -val) * Time.deltaTime;
			
			if (total > 90) {
				deltaAngle = dest - last;
				enabled = false;
			}

			total += Mathf.Abs(deltaAngle);
			transform.RotateAround (dd.transform.position, Vector3.up, deltaAngle);
			last = transform.localEulerAngles.y;
			val -= (500.0f * (total / 80.0f)) * Time.deltaTime;
			Debug.Log (val);
			yield return null;
		}

		inTransition = false;
	}
}
