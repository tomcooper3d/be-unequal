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

		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				int idx = tileMapCoordToOther(i, j);
				if (idx >= allTiles.Length) {
					break;
				}
				GameObject tile = allTiles[idx];

				int mapIdxY = i - currentX;
				int mapIdxX = j - currentY;
				tile.transform.position = currentPos;

				if (i == 0 && j == 0) {
					tile.SetActive(true);
				} else {
					tile.SetActive(false);
				}
				tileMap[i,j] = tile;
			}
		}
		updateWallTriggers ();
	}

	void Update () {
	
	}

	void updateWallTriggers () {
		Debug.Log("x " + currentX + "y " + currentY);
		GameObject tile = allTiles[tileMapCoordToOther(currentX, currentY)];
		Frame frame = tile.GetComponent<Frame> ();
		wallTrigger.updateTriggersWithFrame (frame);
	}

	int tileMapCoordToOther (int i, int j) {
		return i * width + j;
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
