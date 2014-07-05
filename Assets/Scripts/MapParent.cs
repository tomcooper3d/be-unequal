﻿using UnityEngine;
using System.Collections;

public class MapParent : MonoBehaviour {

	public GameObject[] allTiles;
	public int width = 2;
	public int height = 2;
	public int startX;
	public int startY;
	public GameObject startTile;

	private GameObject[,] tileMap;
	private int currentX;
	private int currentY;
	private Vector3 currentPos;

	void Start () {
		tileMap = new GameObject[width, height];
		currentX = startX;
		currentY = startY;
		currentPos = startTile.transform.position;

		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				GameObject tile = allTiles[tileMapCoordToOther(i, j)];

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
						tile.SetActive(true);
					} else {
						tile.SetActive(false);
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
						tile.SetActive(true);
					} else {
						tile.SetActive(false);
					}
				}
			}
			Debug.Log("x " + currentX + "y " + currentY);
			allTiles[tileMapCoordToOther(currentX, currentY)].renderer.enabled = true;
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
		}		
	}
}
