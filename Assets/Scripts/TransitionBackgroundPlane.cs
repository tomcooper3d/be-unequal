using UnityEngine;
using System.Collections;

public class TransitionBackgroundPlane : MonoBehaviour {

	public string nextLevelName;

	void Awake () {
		iTween.FadeTo (this.gameObject, 0.0f, 0.0f);
	}

	public void flash () {
		iTween.FadeTo (this.gameObject, iTween.Hash("amount", 0.75f, "oncomplete", "doneFlash", "time", 0.01f));
	}

	void doneFlash() {
		iTween.FadeTo (this.gameObject, iTween.Hash("amount", 0.0f, "time", 0.7f));
	}

	public void fadeInRoundEnded () {
		iTween.FadeTo (this.gameObject, iTween.Hash("amount", 1.0f, "time", 2.0f, "easetype", iTween.EaseType.easeInQuad, "oncomplete", "loadNextLevel"));
	}

	void loadNextLevel() {
		Application.LoadLevel (nextLevelName);
	}
}
