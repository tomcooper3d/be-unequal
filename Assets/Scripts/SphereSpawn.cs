﻿using UnityEngine;
using System.Collections;

public class SphereSpawn : MonoBehaviour {

	public bool waitForButtonPress;
	public TransitionBackgroundPlane plane;
	public GameObject halo;
	public AudioClip spawingSound;

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
			audio.PlayOneShot(spawingSound, 0.6F);
		}
	}

	void hideHalo() {
		this.GetComponent<CharacterMotor>().canControl = true;
		this.GetComponent<CharacterMotor>().movement.maxFallSpeed = 20.0f;
		iTween.FadeTo (halo, iTween.Hash ("amount", 0.0f, "oncomplete", "disableHalo", "time", 0.3f));
	}

	void disableHalo() {
		halo.SetActive(false);
	}

	public void win () {
		audio.PlayOneShot(spawingSound, 0.6F);
		halo.SetActive(true);
		this.GetComponent<CharacterMotor>().canControl = false;	
		this.GetComponent<CharacterMotor>().movement.maxFallSpeed = 0.0f;
		iTween.FadeTo (halo, iTween.Hash ("amount", 1.0f, "oncomplete", "doHalo", "time", 1.0f, "easetype", iTween.EaseType.easeInCubic));
		iTween.MoveBy(this.gameObject, iTween.Hash("y", asendFromHeight, "easeType", "easeInOutExpo", "oncomplete", "hideHalo","time", 1.5f));
		plane.GetComponent<TransitionBackgroundPlane> ().fadeInRoundEnded();
	}
}
