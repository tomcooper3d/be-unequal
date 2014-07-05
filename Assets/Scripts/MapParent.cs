using UnityEngine;
using System.Collections;

public class MapParent : MonoBehaviour {

	public GameObject[] allTiles;
	public int width = 2;
	public int height = 2;
	public int startX;
	public int startY;

	private GameObject[,] tileMap;
	private int currentX;
	private int currentY;
	
	void Start () {
		tileMap = new GameObject[width, height];
		currentX = startX;
		currentY = startY;

		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				GameObject tile = allTiles[tileMapCoordToOther(i, j)];

				int mapIdxY = i - currentX;
				int mapIdxX = j - currentY;

				tile.transform.position =  new Vector3( mapIdxX * 5, tile.transform.position.y, mapIdxY * 5);
				tileMap[i,j] = tile;
			}
		}
	}

	void Update () {
	
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
						tile.transform.position = Vector3.zero;
					} else {
						tile.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, tile.transform.position.z+5);
					}
				}
			}
		}
	}
	
	public void moveRight() {
		if (currentX < width-1) {
			Debug.Log("Moving right");
			currentX += 1;
			
			for (int i = 0; i < width; i++) {
				for (int j = 0; j < height; j++) {
					GameObject tile = allTiles[tileMapCoordToOther(i, j)];

					if (i == currentX && j == currentY) {
						tile.transform.position = Vector3.zero;
					} else {
						tile.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, tile.transform.position.z-5);
					}
				}
			}
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
						tile.transform.position = Vector3.zero;
					} else {
						tile.transform.position = new Vector3(tile.transform.position.x -5, tile.transform.position.y, tile.transform.position.z);
					}
				}
			}
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
						tile.transform.position = Vector3.zero;
					} else {
						tile.transform.position = new Vector3(tile.transform.position.x + 5, tile.transform.position.y, tile.transform.position.z);
					}
				}
			}
		}		
	}
}
