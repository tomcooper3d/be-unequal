using UnityEngine;
using System.Collections;

public class SphereSpawn : MonoBehaviour {

	public bool waitForButtonPress;
	public GameObject halo;

	public float asendFromHeight = 20.0f;

	private bool hasSpawned = false;

	void Start () {
		this.transform.position = new Vector3(transform.position.x, transform.position.y + asendFromHeight, transform.position.z );
		this.GetComponent<CharacterMotor>().canControl = false;	
	}

	void Update () {
		if ((waitForButtonPress && Input.anyKey) || (!waitForButtonPress && !hasSpawned )) {
			iTween.MoveBy(this.gameObject, iTween.Hash("y", -asendFromHeight, "easeType", "easeInOutExpo", "oncomplete", "hideHalo"));
			waitForButtonPress = false;
			hasSpawned = true;
		}
	}

	void hideHalo() {
		this.GetComponent<CharacterMotor>().canControl = true;
		this.GetComponent<CharacterMotor>().movement.maxFallSpeed = 20.0f;
		GameObject.Destroy (halo);
	}
}
