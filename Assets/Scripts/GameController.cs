using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public float timeLeft;

    public int scoreLimit;

	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
        GameObject.Find("Timer Text").GetComponent<Text>().text = Mathf.Round(timeLeft).ToString(); 
		if (timeLeft < 0) {
			GameOver ();
		}
	}

	void GameOver() {

		Debug.Log ("Game Over!");
	}
}
