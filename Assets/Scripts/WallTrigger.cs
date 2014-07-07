using UnityEngine;
using System.Collections;

public class WallTrigger : MonoBehaviour {

	public GameObject mapParentObject; 
	private MapParent mapParent;

	public GameObject topColliderObject;
	public GameObject bottomColliderObject;
	public GameObject leftColliderObject;
	public GameObject rightColliderObject;

	public GameObject topArrivalColliderObject;
	public GameObject bottomArrivalColliderObject;
	public GameObject leftArrivalColliderObject;
	public GameObject rightArrivalColliderObject;
	
	private bool transitionInEffect = false;
	private GameObject blockingColliderUntilExit;

	void Start () {
		mapParent = mapParentObject.GetComponent<MapParent> ();
	}

	public void updateColliders(Frame frame) {
		topColliderObject = frame.topColliderObject;
		bottomColliderObject = frame.bottomColliderObject;
		leftColliderObject = frame.leftColliderObject;
		rightColliderObject = frame.rightColliderObject;
	}

	public void updateArrivals(Frame frame) {
		leftArrivalColliderObject = frame.leftArrivalColliderObject;
		rightArrivalColliderObject = frame.rightArrivalColliderObject;
		topArrivalColliderObject = frame.topArrivalColliderObject;
		bottomArrivalColliderObject = frame.bottomArrivalColliderObject;
	}

	IEnumerator enableCollisions() {
		yield return new WaitForSeconds(0.01f);
		transitionInEffect = false;
	}

	void OnTriggerEnter(Collider collisionInfo) {
		if (transitionInEffect) {
			return;
		}
		if (collisionInfo.gameObject == topColliderObject) {
			transitionInEffect = true;
			mapParent.moveTop ();
			transform.position = new Vector3(topArrivalColliderObject.transform.position.x, topArrivalColliderObject.transform.position.y, transform.position.z);
			mapParent.finishUp();
			StartCoroutine(enableCollisions());
		} else if (collisionInfo.gameObject == bottomColliderObject) {
			transitionInEffect = true;
			mapParent.moveBottom ();
			transform.position = new Vector3(bottomArrivalColliderObject.transform.position.x, bottomArrivalColliderObject.transform.position.y, transform.position.z);
			mapParent.finishUp();
			StartCoroutine(enableCollisions());
		} else if (collisionInfo.gameObject == leftColliderObject) {
			transitionInEffect = true;
			mapParent.moveLeft ();
			transform.position = new Vector3(transform.position.x, rightArrivalColliderObject.transform.position.y, rightArrivalColliderObject.transform.position.z);
			mapParent.finishUp();
			StartCoroutine(enableCollisions());
		} else if (collisionInfo.gameObject == rightColliderObject) {
			transitionInEffect = true;
			mapParent.moveRight ();
			transform.position = new Vector3(transform.position.x, leftArrivalColliderObject.transform.position.y, leftArrivalColliderObject.transform.position.z);
			mapParent.finishUp();
			StartCoroutine(enableCollisions());
		} else { } 
	}

}