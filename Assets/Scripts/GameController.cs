using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public float timeLeft;
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			GameOver ();
		}
	}

	void GameOver() {
		Debug.Log ("Game Over!");
	}
}
