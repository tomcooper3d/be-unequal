using UnityEngine;
using System.Collections;

public class MapParent : MonoBehaviour {

	public GameObject[] allTiles;
	public int width;
	public int height;
	public int startX;
	public int startY;
	public GameObject startTile;
	public GameObject sphereObject;
	public GameObject sphereParticleSystem;
	public GameObject transitionBackgroundPlane;

	private GameObject[,] tileMap;
	private int currentX;
	private int currentY;
	private Vector3 currentPos;
	private WallTrigger wallTrigger;

	void Start () {
		tileMap = new GameObject[width, height];
		currentX = startX;
		currentY = startY;
		currentPos = startTile.transform.position;
		wallTrigger = sphereObject.GetComponent<WallTrigger> ();
		Debug.Log (allTiles.Length);
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				int idx = tileMapCoordToOther(i, j);

				Debug.Log ("dd" + idx);
				if (idx >= allTiles.Length) {
					break;
				}
				GameObject tile = allTiles[idx];

				tile.transform.position = currentPos;

				if (i == startX && j == startY) {
					tile.SetActive(true);
				} else {
					tile.SetActive(false);
				}
				tileMap[i,j] = tile;
			}
		}
		updateWallTriggers ();
		finishUp();
	}

	void Update () {
	
	}

	public void finishUp () {
		GameObject tile = allTiles[tileMapCoordToOther(currentX, currentY)];
		Frame frame = tile.GetComponent<Frame> ();
		wallTrigger.updateColliders (frame);
	}

	void updateWallTriggers () {
		TransitionBackgroundPlane p = transitionBackgroundPlane.GetComponent<TransitionBackgroundPlane> ();
		transitionBackgroundPlane.SetActive (true);
		p.flash ();
		GameObject tile = allTiles[tileMapCoordToOther(currentX, currentY)];
		Frame frame = tile.GetComponent<Frame> ();
		wallTrigger.updateArrivals (frame);
		sphereParticleSystem.particleSystem.Clear ();
		sphereParticleSystem.particleSystem.Stop ();
		StartCoroutine (waitForSecondsAndStartParticleSystem (0.01f));
	}

	IEnumerator waitForSecondsAndStartParticleSystem (float seconds) {
		yield return new WaitForSeconds (seconds);
		sphereParticleSystem.particleSystem.Play ();
	}

	int tileMapCoordToOther (int i, int j) {
		return i * height + j;
	}

	public void moveLeft() {
		if (currentX > 0) {
			Debug.Log("Moving left");
			currentX -= 1;

			for (int i = 0; i < width; i++) {
				for (int j = 0; j < height; j++) {
					GameObject tile = allTiles[tileMapCoordToOther(i, j)];

					if (i == currentX && j == currentY) {
						tile.SetActive(true);
					} else {
						tile.SetActive(false);
					}
				}
			}
			updateWallTriggers ();
		}
	}
	
	public void moveRight() {
		if (currentX < width-1) {
			Debug.Log("Moving right");
			currentX += 1;
			
			for (int i = 0; i < width; i++) {
				for (int j = 0; j < height; j++) {
					int idx = tileMapCoordToOther(i, j);
					if (idx >= allTiles.Length) {
						break;
					}
					GameObject tile = allTiles[idx];

					if (i == currentX && j == currentY) {
						tile.SetActive(true);
					} else {
						tile.SetActive(false);
					}
				}
			}
			updateWallTriggers ();
		}		
	}
	
	public void moveTop() {
		if (currentY > 0) {

			Debug.Log("Moving up");
			currentY -= 1;
			
			for (int i = 0; i < width; i++) {
				for (int j = 0; j < height; j++) {

					GameObject tile = allTiles[tileMapCoordToOther(i, j)];

					if (i == currentX && j == currentY) {
						tile.SetActive(true);
					} else {
						tile.SetActive(false);
					}
				}
			}
			updateWallTriggers ();
		}		
	}

	public void moveBottom() {
		if (currentY < height-1) {
			Debug.Log("Moving down");
			currentY += 1;
			
			for (int i = 0; i < width; i++) {
				for (int j = 0; j < height; j++) {
					GameObject tile = allTiles[tileMapCoordToOther(i, j)];

					if (i == currentX && j == currentY) {
						tile.SetActive(true);
					} else {
						tile.SetActive(false);
					}
				}
			}
			updateWallTriggers ();
		}		
	}
}
