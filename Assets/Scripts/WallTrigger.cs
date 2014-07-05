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

	void Start () {
		mapParent = mapParentObject.GetComponent<MapParent> ();
	}
	void OnTriggerEnter(Collider collisionInfo) {
		if (transitionInEffect) return;
		if (collisionInfo.gameObject == topColliderObject) {
			transitionInEffect = true;
			transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
			mapParent.moveTop ();
		} else if (collisionInfo.gameObject == bottomColliderObject) {
			transitionInEffect = true;
			transform.position = new Vector3(-transform.position.x, -transform.position.y, transform.position.z);
			mapParent.moveBottom ();
		} else if (collisionInfo.gameObject == leftColliderObject) {
			transitionInEffect = true;
			mapParent.moveLeft ();
		} else if (collisionInfo.gameObject == rightColliderObject) {
			transitionInEffect = true;
			mapParent.moveRight ();
		} else { } 
	}
	void OnTriggerExit(Collider collisionInfo) {
		if (collisionInfo.gameObject == topColliderObject || collisionInfo.gameObject == bottomColliderObject || collisionInfo.gameObject == leftColliderObject || collisionInfo.gameObject == rightColliderObject) {
			transitionInEffect = false;
		}
	}
}