using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (AudioSource))]

public class SwitchController : MonoBehaviour 
{
	private int currentLevel;
	private float totalTime;

	private bool switch1;
	private bool switch2;
	private bool switch3;
	private bool switch4;
	private bool switch5;
	private bool switch6;
	private GameObject switch1Object;
	private GameObject switch2Object;
	private GameObject switch3Object;
	private GameObject switch4Object;
	private GameObject switch5Object;
	private GameObject switch6Object;
	private GameObject firstParticle;
	private GameObject secondParticle;
	private GameObject thirdParticle;
	private ParticleSystem fParticle;
	private ParticleSystem sParticle;
	private ParticleSystem tParticle;
	public float switch1Value;
	public float switch2Value;
	public float switch3Value;
	public float switch4Value;
	public float switch5Value;
	public float switch6Value;
	private float switchCurrentValue;
	private float otherCurrentValue;
	private Color onColor;
	private Color offColor;
	public bool levelWin;

	public AudioClip switch1Clip;
	public AudioClip switch2Clip;
	public AudioClip switch3Clip;
	public AudioClip switch4Clip;
	public AudioClip switch5Clip;
	public AudioClip switch6Clip;

	private GameObject[] switchArrayPlaceHolders;
	private GameObject[] switchArray;


	void Awake () 
	{
		switch1Object = GameObject.FindWithTag ("Switch 1");
		switch2Object = GameObject.FindWithTag ("Switch 2");
		switch3Object = GameObject.FindWithTag ("Switch 3");
		switch4Object = GameObject.FindWithTag ("Switch 4");
		switch5Object = GameObject.FindWithTag ("Switch 5");
		switch6Object = GameObject.FindWithTag ("Switch 6");

		switchArrayPlaceHolders  = GameObject.FindGameObjectsWithTag("Switch");
		if (switchArrayPlaceHolders.Length < 1 || switchArrayPlaceHolders.Length > 5) 
		{
			Debug.Log ("Not enough Switches are placed! OR to many. (6:Max/1:Min)");
		} 
	}

	// Use this for initialization
	void Start () 
	{
		switch1 = false;
		switch2 = false;
		switch3 = false;
		switch4 = false;
		switch5 = false;
		switch6 = false;
		switchCurrentValue = 0;
		otherCurrentValue = 100;
		levelWin = false;
		onColor = new Color(0F, 1F, 0F, 0.5F);
		offColor = new Color(1F, 0F, 0F, 0.5F);

		firstParticle = GameObject.FindWithTag ("First Particle");
		secondParticle = GameObject.FindWithTag ("Second Particle");
		thirdParticle = GameObject.FindWithTag ("Third Particle");
		fParticle = (ParticleSystem)firstParticle.GetComponent("ParticleSystem");
		sParticle = (ParticleSystem)secondParticle.GetComponent("ParticleSystem");
		tParticle = (ParticleSystem)thirdParticle.GetComponent("ParticleSystem");
		ParticleSytemChange ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (switchCurrentValue == 100 && !levelWin) {
			this.GetComponent<SphereSpawn>().win();
			levelWin = true;
		}	
	}

	void OnTriggerEnter(Collider other) 
	{
		if(levelWin == false)
		{
			if (other.tag == "Switch 1") 
			{
				Debug.Log ("I Hit Switch 1");
				if (!switch1) {
						switch1 = true;
						switch1Object.renderer.material.color = onColor;
						iTween.ScaleTo(switch1Object, iTween.Hash ("y", 0.66F, "easeType", "easeInOutExpo", "time", 1F));
						switchCurrentValue += switch1Value;
						OtherParticle();
						ParticleSytemChange ();

				} else {
						switch1 = false;
						switch1Object.renderer.material.color = offColor; 
						iTween.ScaleTo(switch1Object, iTween.Hash ("y", 5F, "easeType", "easeInOutExpo", "time", 1F));
						switchCurrentValue -= switch1Value;
						OtherParticle();
						ParticleSytemChange ();
				}
				switchCurrentValue = 100;
			}
			if (other.tag == "Switch 2") 
			{

				audio.clip = switch2Clip;
				audio.Play();

				Debug.Log("I Hit Switch 2");
				if(!switch2)
				{
					switch2 = true;
					switch2Object.renderer.material.color = onColor;
					iTween.ScaleTo(switch2Object, iTween.Hash ("y", 0.66F, "easeType", "easeInOutExpo", "time", 1F));
					switchCurrentValue += switch2Value;
					OtherParticle();
					ParticleSytemChange();
					
				}
				else
				{
					switch2 = false;
					switch2Object.renderer.material.color = offColor;
					iTween.ScaleTo(switch2Object, iTween.Hash ("y", 5F, "easeType", "easeInOutExpo", "time", 1F));
					switchCurrentValue -= switch2Value;
					OtherParticle();
					ParticleSytemChange();
				}
			}
			if (other.tag == "Switch 3") 
			{
				audio.clip = switch3Clip;
				audio.Play();
				
				Debug.Log("I Hit Switch 3");
				if(!switch3)
				{
					switch3 = true;
					switch3Object.renderer.material.color = onColor;
					iTween.ScaleTo(switch3Object, iTween.Hash ("y", 0.66F, "easeType", "easeInOutExpo", "time", 1F));
					switchCurrentValue += switch3Value;
					OtherParticle();
					ParticleSytemChange();
					
				}
				else
				{
					switch3 = false;
					switch3Object.renderer.material.color = offColor ;
					iTween.ScaleTo(switch3Object, iTween.Hash ("y", 5F, "easeType", "easeInOutExpo", "time", 1F));
					switchCurrentValue -= switch3Value;
					OtherParticle();
					ParticleSytemChange();
				}
			}
			if (other.tag == "Switch 4") 
			{
				audio.clip = switch4Clip;
				audio.Play();
				
				Debug.Log("I Hit Switch 4");
				if(!switch4)
				{
					switch4 = true;
					switch4Object.renderer.material.color = onColor;
					iTween.ScaleTo(switch4Object, iTween.Hash ("y", 0.66F, "easeType", "easeInOutExpo", "time", 1F));
					switchCurrentValue += switch4Value;
					OtherParticle();
					ParticleSytemChange();
					
				}
				else
				{
					switch4 = false;
					switch4Object.renderer.material.color = offColor;
					iTween.ScaleTo(switch4Object, iTween.Hash ("y", 5F, "easeType", "easeInOutExpo", "time", 1F));
					switchCurrentValue -= switch4Value;
					OtherParticle();
					ParticleSytemChange();
				}
			}
			if (other.tag == "Switch 5") 
			{
				audio.clip = switch5Clip;
				audio.Play();
				
				Debug.Log("I Hit Switch 5");
				if(!switch5)
				{
					switch5 = true;
					switch5Object.renderer.material.color = onColor; 
					iTween.ScaleTo(switch5Object, iTween.Hash ("y", 0.66F, "easeType", "easeInOutExpo", "time", 1F));
					switchCurrentValue += switch5Value;
					OtherParticle();
					ParticleSytemChange();
					
				}
				else
				{
					switch5 = false;
					switch5Object.renderer.material.color = offColor;
					iTween.ScaleTo(switch5Object, iTween.Hash ("y", 5F, "easeType", "easeInOutExpo", "time", 1F));
					switchCurrentValue -= switch5Value;
					OtherParticle();
					ParticleSytemChange();
				}
			}
			if (other.tag == "Switch 6") 
			{
				audio.clip = switch6Clip;
				audio.Play();

				Debug.Log("I Hit Switch 6");
				if(!switch6)
				{
					switch6 = true;
					switch6Object.renderer.material.color = onColor;
					iTween.ScaleTo(switch6Object, iTween.Hash ("y", 0.66F, "easeType", "easeInOutExpo", "time", 1F));
					switchCurrentValue += switch6Value;
					OtherParticle();
					ParticleSytemChange();
					
				}
				else
				{
					switch6 = false;
					switch6Object.renderer.material.color = offColor;
					iTween.ScaleTo(switch6Object, iTween.Hash ("y", 5F, "easeType", "easeInOutExpo", "time", 1F));
					switchCurrentValue -= switch6Value;
					OtherParticle();
					ParticleSytemChange();
				}
			}
		}
	}

	void OtherParticle()
	{
		Debug.Log ("Other ran");
		if (switchCurrentValue < 100) 
		{
			otherCurrentValue = 100 - switchCurrentValue;
		} 
		else 
		{
			otherCurrentValue = 0;
		}
	}

	void ParticleSytemChange()
	{
		float switchCurrentValuePercentage = (switchCurrentValue/100);
		float otherCurrentValuePercentage = (otherCurrentValue/100);
		sParticle.emissionRate = (fParticle.emissionRate * switchCurrentValuePercentage) + (tParticle.emissionRate * otherCurrentValuePercentage);
		sParticle.gravityModifier = (fParticle.gravityModifier * switchCurrentValuePercentage) + (tParticle.gravityModifier  * otherCurrentValuePercentage);
		sParticle.maxParticles = fParticle.maxParticles;
		sParticle.simulationSpace = fParticle.simulationSpace;
		sParticle.startColor = fParticle.startColor;
		sParticle.startDelay = (fParticle.startDelay * switchCurrentValuePercentage) + (tParticle.startDelay * otherCurrentValuePercentage);
		sParticle.startLifetime = (fParticle.startLifetime * switchCurrentValuePercentage) + (tParticle.startLifetime * otherCurrentValuePercentage);
		sParticle.startRotation = (fParticle.startRotation * switchCurrentValuePercentage) + (tParticle.startRotation * otherCurrentValuePercentage);
		sParticle.startSize = (fParticle.startSize * switchCurrentValuePercentage) + (tParticle.startSize * otherCurrentValuePercentage);
		sParticle.startSpeed = (fParticle.startSpeed * switchCurrentValuePercentage) + (tParticle.startSpeed * otherCurrentValuePercentage);
		sParticle.renderer.material = fParticle.renderer.material;
	}
	
}
