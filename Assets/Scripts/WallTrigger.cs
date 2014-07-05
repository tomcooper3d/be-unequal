using UnityEngine;
using System.Collections;

public class WallTrigger : MonoBehaviour {

	public GameObject mapParentObject; 
	private MapParent mapParent;

	public GameObject topColliderObject;
	public GameObject bottomColliderObject;
	public GameObject leftColliderObject;
	public GameObject rightColliderObject;

	void Start () {
		mapParent = mapParentObject.GetComponent<MapParent> ();
	}
	void OnTriggerExit(Collider collisionInfo) {
		if (collisionInfo.gameObject == topColliderObject) {
			mapParent.moveTop ();
		} else if (collisionInfo.gameObject == bottomColliderObject) {
			mapParent.moveBottom ();
		} else if (collisionInfo.gameObject == leftColliderObject) {
			mapParent.moveLeft ();
		} else if (collisionInfo.gameObject == rightColliderObject) {
			mapParent.moveRight ();
		} else { } 
	}
}