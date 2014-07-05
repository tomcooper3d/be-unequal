using UnityEngine;
using System.Collections;

public class WallTrigger : MonoBehaviour {

	public GameObject mapParentObject; 
	private MapParent mapParent;

	public GameObject topColliderObject;
	public GameObject bottomColliderObject;
	public GameObject leftColliderObject;
	public GameObject rightColliderObject;

	private bool transitionInEffect = false;
	private GameObject blockingColliderUntilExit;
	void Start () {
		mapParent = mapParentObject.GetComponent<MapParent> ();
	}
	void OnTriggerEnter(Collider collisionInfo) {
		if (transitionInEffect) return;
		if (collisionInfo.gameObject == topColliderObject) {
			transitionInEffect = true;
			blockingColliderUntilExit = bottomColliderObject;
			transform.position = new Vector3(-transform.position.x-2.0f, transform.position.y, transform.position.z);
			mapParent.moveTop ();
		} else if (collisionInfo.gameObject == bottomColliderObject) {
			transitionInEffect = true;
			blockingColliderUntilExit = topColliderObject;
			transform.position = new Vector3(-transform.position.x-0.5f, -transform.position.y, transform.position.z);
			mapParent.moveBottom ();
		} else if (collisionInfo.gameObject == leftColliderObject) {
			transitionInEffect = true;
			transform.position = new Vector3(transform.position.x, transform.position.y, -transform.position.z+2.0f);
			blockingColliderUntilExit = rightColliderObject;
			mapParent.moveLeft ();
		} else if (collisionInfo.gameObject == rightColliderObject) {
			transitionInEffect = true;
			transform.position = new Vector3(transform.position.x, transform.position.y, -transform.position.z+1.5f);
			blockingColliderUntilExit = leftColliderObject;
			mapParent.moveRight ();
		} else { } 
	}
	void OnTriggerExit(Collider collisionInfo) {
		if (collisionInfo.gameObject == blockingColliderUntilExit) {
			transitionInEffect = false;
		}
	}
}