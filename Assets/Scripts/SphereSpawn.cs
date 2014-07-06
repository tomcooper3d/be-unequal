using UnityEngine;
using System.Collections;

public class SphereSpawn : MonoBehaviour {

	public bool waitForButtonPress;
	public GameObject halo;

	public float asendFromHeight = 20.0f;

	void Start () {
		if (waitForButtonPress) {
			this.GetComponent<CharacterMotor>().canControl = false;
			this.transform.position = new Vector3(transform.position.x, transform.position.y + asendFromHeight, transform.position.z );
		}
	}

	void Update () {
		if (waitForButtonPress && Input.anyKey) {
			iTween.MoveBy(this.gameObject, iTween.Hash("y", -asendFromHeight, "easeType", "easeInOutExpo", "oncomplete", "hideHalo"));
			waitForButtonPress = false;
		}
	}

	void hideHalo() {
		this.GetComponent<CharacterMotor>().canControl = true;
		this.GetComponent<CharacterMotor>().movement.maxFallSpeed = 20.0f;
		GameObject.Destroy (halo);
	}
}
