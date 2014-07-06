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

	public void updateTriggersWithFrame(Frame frame) {
		topColliderObject = frame.topColliderObject;
		bottomColliderObject = frame.bottomColliderObject;
		leftColliderObject = frame.leftColliderObject;
		rightColliderObject = frame.rightColliderObject;

		leftArrivalColliderObject = frame.leftArrivalColliderObject;
		rightArrivalColliderObject = frame.rightArrivalColliderObject;
		topArrivalColliderObject = frame.topArrivalColliderObject;
		bottomArrivalColliderObject = frame.bottomArrivalColliderObject;
	}

	void OnTriggerEnter(Collider collisionInfo) {

		if (collisionInfo.gameObject == topColliderObject) {
			mapParent.moveTop ();
			transform.position = new Vector3(topArrivalColliderObject.transform.position.x, transform.position.y, transform.position.z);
			Debug.Log(transform.position);
		} else if (collisionInfo.gameObject == bottomColliderObject) {
			mapParent.moveBottom ();
			transform.position = new Vector3(bottomArrivalColliderObject.transform.position.x, transform.position.y, transform.position.z);
		} else if (collisionInfo.gameObject == leftColliderObject) {
			mapParent.moveLeft ();
			transform.position = new Vector3(transform.position.x, transform.position.y, rightArrivalColliderObject.transform.position.z);
		} else if (collisionInfo.gameObject == rightColliderObject) {
			mapParent.moveRight ();
			transform.position = new Vector3(transform.position.x, transform.position.y, leftArrivalColliderObject.transform.position.z);
		} else { } 
	}

}